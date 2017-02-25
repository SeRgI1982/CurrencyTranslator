using System;
using System.Globalization;

namespace CurrencyTranslator.Business.Utils
{
    // Thanks to that class we are able to introduce in future a shortcuts for ex.: 1M  = 1 000 000, 1K = 1 000
    internal class NumberParser : INumberParser
    {
        public decimal Parse(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            text = text.Replace(" ", "");

            if (text.Length > 0 && (text[0] != '-' && text[0] != '+' && !char.IsDigit(text[0])))
            {
                throw new FormatException(text);
            }

            var containsNumberDecimalSeparator = text.Contains(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
            text = text.Replace(",", CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);

            var result = decimal.Parse(text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture);

            if (containsNumberDecimalSeparator)
            {
                throw new NotSupportedException($"Separator: '{CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator}' is not supported.");
            }

            return result;
        }
    }
}