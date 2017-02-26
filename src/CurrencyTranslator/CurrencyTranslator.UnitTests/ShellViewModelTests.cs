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
        public void WhenPropertyNumber1WasChangedTheServiceWasCalled()
        {
            // Arrange
            _service.Expect(x => x.TranslateIntoWordsAsync("Lorem ipsum")).Return(Task.FromResult("AAA"));

            // Act
            _viewModel.Number1 = "Lorem ipsum";

            // Assert
            _service.AssertWasCalled(x => x.TranslateIntoWordsAsync("Lorem ipsum"));
        }

        [Test]
        public void WhenPropertyNumberWasChanged1TheWordsPropertyWasSet()
        {
            // Arrange
            _service.Expect(x => x.TranslateIntoWordsAsync("1"))
                    .Return(Task.FromResult("one dollar"));

            // Act
            _viewModel.Number1 = "1";

            // Assert
            Assert.That(_viewModel.Words1, Is.EqualTo("one dollar"));
        }

        [Test]
        public void WhenNumber3IsNullAndTranslateCommandWasCalledTheWordsPropertyWasSetToStringEmpty()
        {
            // Arrange
            _service.Expect(x => x.TranslateIntoWordsAsync(null))
                    .Return(Task.FromResult(string.Empty));
            _viewModel.Number3 = null;

            // Act
            _viewModel.TranslateCommand.Execute(null);

            // Assert
            Assert.That(_viewModel.Words3, Is.EqualTo(string.Empty));
        }

        [Test]
        public void WhenTranslateCommandWasCalledPropertyWords3WasSet()
        {
            // Arrange
            _service.Expect(x => x.TranslateIntoWordsAsync("1"))
                    .Return(Task.FromResult("one dollar"));
            _viewModel.Number3 = "1";

            // Act
            _viewModel.TranslateCommand.Execute(null);

            // Assert
            Assert.That(_viewModel.Words3, Is.EqualTo("one dollar"));
        }

        [Test]
        public void WhenTranslateWithParameterCommandWasCalledPropertyWords4WasSet()
        {
            // Arrange
            _service.Expect(x => x.TranslateIntoWordsAsync("1"))
                    .Return(Task.FromResult("one dollar"));

            // Act
            _viewModel.TranslateWithParameterCommand.Execute("1");

            // Assert
            Assert.That(_viewModel.Words4, Is.EqualTo("one dollar"));
        }
    }
}
