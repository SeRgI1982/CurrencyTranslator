namespace CurrencyTranslator.Business.Utils
{
    public interface INumberToWordsConverter
    {
        /// <summary>
        /// Converts int number value to the number value in words.
        /// </summary>
        /// <param name="number">The number</param>
        /// <returns>Words representation of the number</returns>
        string Convert(int number);
    }
}