namespace CurrencyTranslator.Business.Contracts
{
    public interface ICurrencyTranslator
    {
        /// <summary>
        /// Translates number value represent by text to number value in words.
        /// </summary>
        /// <param name="numberText">Number value represent by text</param>
        /// <returns>Number value in words</returns>
        string Translate(string numberText);
    }
}