namespace CurrencyTranslator.Business.Utils
{
    public interface INumberParser
    {
        /// <summary>
        /// Parse number value in text to the decimal value.
        /// </summary>
        /// <param name="text">Number value in text</param>
        /// <returns>Parsed decimal value</returns>
        decimal Parse(string text);
    }
}
