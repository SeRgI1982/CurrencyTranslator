using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CurrencyTranslator.ServiceLayer;
using Prism.Commands;
using Prism.Mvvm;

namespace CurrencyTranslator.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private string _words1;
        private string _words2;
        private string _words3;
        private string _words4;
        private string _words5;
        private string _number1;
        private string _number2;
        private string _number3;
        private readonly ICurrencyService _currencyService;

        public ShellViewModel(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
            
            TranslateCommand = new DelegateCommand(OnTranslate);
            TranslateCurrencyCommand = new DelegateCommand<string>(async x => Words5 = await CalculateNumberInWords(x));
            TranslateWithParameterCommand = new DelegateCommand<string>(OnTranslateWithParameter);
        }

        public ICommand TranslateCommand { get; }

        public ICommand TranslateCurrencyCommand { get; }

        public ICommand TranslateWithParameterCommand { get; }

        public string Words1
        {
            get { return _words1; }
            set { SetProperty(ref _words1, value); }
        }

        public string Words2
        {
            get { return _words2; }
            set { SetProperty(ref _words2, value); }
        }

        public string Words3
        {
            get { return _words3; }
            set { SetProperty(ref _words3, value); }
        }

        public string Words4
        {
            get { return _words4; }
            set { SetProperty(ref _words4, value); }
        }

        public string Words5
        {
            get { return _words5; }
            set { SetProperty(ref _words5, value); }
        }

        public string Number1
        {
            get { return _number1; }
            set
            {
                if (SetProperty(ref _number1, value))
                {
                    CalculateNumberInWords(Number1).ContinueWith(t => Words1 = t.Result);
                }
            }
        }

        public string Number2
        {
            get { return _number2; }
            set
            {
                if (SetProperty(ref _number2, value))
                {
                    CalculateNumberInWords(Number2).ContinueWith(t => Words2 = t.Result);
                }
            }
        }

        public string Number3
        {
            get { return _number3; }
            set { SetProperty(ref _number3, value); }
        }

        // We should avoid constuction 'async void' because we loose an information about Task when operation fail
        // but for this demo purpose I used this construction deliberately because Exception is handled by CalculateNumberInWords method
        private async void OnTranslate()
        {
            Words3 = await CalculateNumberInWords(Number3);
        }

        private async void OnTranslateWithParameter(string parameter)
        {
            Words4 = await CalculateNumberInWords(parameter);
        }

        private async Task<string> CalculateNumberInWords(string number)
        {
            string words;

            try
            {
                words = await _currencyService.TranslateIntoWordsAsync(number);
            }
            catch (Exception ex)
            {
                words = ex.Message;
            }

            return words;
        }
    }
}
