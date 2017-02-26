using System.Threading.Tasks;
using CurrencyTranslator.ServiceLayer;
using CurrencyTranslator.ViewModels;
using NUnit.Framework;
using Rhino.Mocks;

namespace CurrencyTranslator.UnitTests
{
    [TestFixture]
    public class ShellViewModelTests
    {
        private ShellViewModel _viewModel;
        private ICurrencyService _service;

        [SetUp]
        public void Setup()
        {
            _service = MockRepository.GenerateMock<ICurrencyService>();
            _viewModel = new ShellViewModel(_service);
        }

        [Test]
        public void WhenPropertyNumberWasChangedTheServiceWasCalled()
        {
            // Arrange
            _service.Expect(x => x.TranslateIntoWordsAsync("Lorem ipsum")).Return(Task.FromResult("AAA"));

            // Act
            _viewModel.Number = "Lorem ipsum";

            // Assert
            _service.AssertWasCalled(x => x.TranslateIntoWordsAsync("Lorem ipsum"));
        }

        [Test]
        public void WhenPropertyNumberWasChangedTheWordsPropertyWasSet()
        {
            // Arrange
            _service.Expect(x => x.TranslateIntoWordsAsync("1"))
                    .Return(Task.FromResult("one dollar"));

            // Act
            _viewModel.Number = "1";

            // Assert
            Assert.That(_viewModel.Words, Is.EqualTo("one dollar"));
        }
    }
}
