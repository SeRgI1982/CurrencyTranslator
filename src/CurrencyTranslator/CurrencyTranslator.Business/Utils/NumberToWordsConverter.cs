using System;
using System.Globalization;
using Humanizer.Configuration;

namespace CurrencyTranslator.Business.Utils
{
    /// <summary>
    /// Humanizer is known to me, that is way I have decided to use this framework. 
    /// Creating NumberToWrodsConverter from scratch could be unfair because in big percentage 
    /// I could draw inspiration from Humanizer solution.
    /// 
    /// According to SOLID principles, always we can provide our own implementation of INumberToWrodsConverter (not dependednt on external solutions)
    /// </summary>
    public class NumberToWordsConverter : INumberToWordsConverter
    {
        private readonly Humanizer.Localisation.NumberToWords.INumberToWordsConverter _converter;

        public NumberToWordsConverter()
        {
            var usCulture = CultureInfo.CreateSpecificCulture("en-US");
            _converter = Configurator.NumberToWordsConverters.ResolveForCulture(usCulture);
        }

        public string Convert(int number)
        {
            if (number > 999999999)
            {
                throw new IndexOutOfRangeException("The maximum number is 999 999 999.");
            }

            var result = _converter.Convert(number);
            result = result.Replace(" and", "");
            return result;
        }
    }
}