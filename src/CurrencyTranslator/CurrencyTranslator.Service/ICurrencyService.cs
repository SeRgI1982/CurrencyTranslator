using System.ServiceModel;

namespace CurrencyTranslator.Service
{
    [ServiceContract]
    public interface ICurrencyService
    {

        [OperationContract]
        string TranslateIntoWords(string numberText);
    }
}
