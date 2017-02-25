using CurrencyTranslator.Business.Contracts;

namespace CurrencyTranslator.Service
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyTranslator _translator;

        public CurrencyService(ICurrencyTranslator translator)
        {
            _translator = translator;
        }

        public string TranslateIntoWords(string numberText)
        {
            var result = _translator.Translate(numberText);
            return result;
        }
    }
}
