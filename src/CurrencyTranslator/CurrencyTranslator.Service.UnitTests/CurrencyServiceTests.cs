using CurrencyTranslator.Business.Contracts;
using NUnit.Framework;
using Rhino.Mocks;

namespace CurrencyTranslator.Service.UnitTests
{
    [TestFixture]
    public class CurrencyServiceTests
    {
        private ICurrencyService _currencyService;
        private ICurrencyTranslator _translator;

        [SetUp]
        public void Setup()
        {
            _translator = MockRepository.GenerateMock<ICurrencyTranslator>();
            _currencyService = new CurrencyService(_translator);
        }

        [Test]
        public void WhenTranslateIntoWordsWasCalledWithProperTextACorrentNumberInWordsReturned()
        {
            // Arrange
            _translator.Expect(t => t.Translate("1")).Return("one dolar");
            var expectedValue = "one dolar";

            // Act
            var actualValue = _currencyService.TranslateIntoWords("1");
            
            // Assert
            Assert.That(actualValue, Is.EqualTo(expectedValue));
            _translator.AssertWasCalled(t => t.Translate("1"));
        }
    }
}
