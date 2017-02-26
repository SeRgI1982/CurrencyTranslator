using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using CurrencyTranslator.ServiceLayer;
using Prism.Mvvm;

namespace CurrencyTranslator.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private string _number;
        private string _words;
        private readonly ICurrencyService _currencyService;

        public ShellViewModel(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        
        public string Words
        {
            get { return _words; }
            set { SetProperty(ref _words, value); }
        }

        public string Number
        {
            get { return _number; }
            set
            {
                if (SetProperty(ref _number, value))
                {
                    _currencyService.TranslateIntoWordsAsync(Number).ContinueWith(
                        t =>
                        {
                            if (t.Exception == null)
                            {
                                Words = t.Result;
                            }
                            else
                            {
                                Words = t.Exception.GetBaseException().Message;
                            }
                        });
                }
            }
        }
    }
}
