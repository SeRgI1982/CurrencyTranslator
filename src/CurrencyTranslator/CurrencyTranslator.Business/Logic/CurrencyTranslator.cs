using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CurrencyTranslator.Business.Contracts;
using CurrencyTranslator.Business.Utils;

namespace CurrencyTranslator.Business.Logic
{
    public class CurrencyTranslator : ICurrencyTranslator
    {
        private readonly INumberParser _parser;
        private readonly INumberToWordsConverter _converter;

        public CurrencyTranslator(INumberParser parser, INumberToWordsConverter converter)
        {
            if (parser == null)
            {
                throw new ArgumentNullException(nameof(parser));
            }

            if (converter == null)
            {
                throw new ArgumentNullException(nameof(converter));
            }

            _parser = parser;
            _converter = converter;
        }

        public string Translate(string numberText)
        {
            if (string.IsNullOrWhiteSpace(numberText))
            {
                return string.Empty;
            }

            var words = new List<string>();
            decimal number = _parser.Parse(numberText);
            string[] endings = { "dollar", "cent" };
            int[] numberParts = GetNumberParts(number);

            for (int i = 0; i < numberParts.Length; i++)
            {
                var part = numberParts[i];
                var partInWords = _converter.Convert(part);
                words.Add($"{partInWords} {endings[i]}{(part == 1 ? "" : "s")}");
            }

            var result = words.Aggregate((dolars, cents) => dolars + " and " + cents);
            return result;
        }

        private static int[] GetNumberParts(decimal number)
        {
            var result = new List<int> { (int)number};

            decimal fraction = number - Math.Truncate(number);

            if (fraction > 0)
            {
                var fractionText = fraction.ToString(CultureInfo.InvariantCulture);
                fractionText = fractionText.Substring(fractionText.IndexOf('.') + 1);

                if (fractionText.Length > 2)
                {
                    throw new NotSupportedException("Translator doesn't support more than 2 places");
                }

                result.Add(int.Parse(fractionText.Length == 1 ? fractionText +  "0" : fractionText));
            }

            return result.ToArray();
        }
    }
}
