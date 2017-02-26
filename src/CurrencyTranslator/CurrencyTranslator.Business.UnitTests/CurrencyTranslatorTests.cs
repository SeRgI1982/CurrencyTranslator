using System;
using CurrencyTranslator.Business.Utils;
using NUnit.Framework;

namespace CurrencyTranslator.Business.UnitTests
{
    [TestFixture]
    public class CurrencyTranslatorTests
    {
        private Logic.CurrencyTranslator _translator;
        private NumberParser _parser;
        private NumberToWordsConverter _converter;

        [SetUp]
        public void Setup()
        {
            _parser = new NumberParser();
            _converter = new NumberToWordsConverter();
            _translator = new Logic.CurrencyTranslator(_parser, _converter);
        }

        [Test]
        public void WhenNumberTextIsNullShouldReturnEmptyString()
        {
            // Arrange
            string numberText = null;

            // Act
            var actualWords = _translator.Translate(numberText);

            // Assert
            Assert.That(actualWords, Is.EqualTo(string.Empty));
        }

        [Test]
        public void WhenNumberTextIsEmptyShouldReturnEmptyString()
        {
            // Arrange
            string numberText = string.Empty;

            // Act
            var actualWords = _translator.Translate(numberText);

            // Assert
            Assert.That(actualWords, Is.EqualTo(string.Empty));
        }

        [Test]
        public void WhenNumberTextIsWhiteSpacesShouldReturnEmptyString()
        {
            // Arrange
            string numberText = "   ";

            // Act
            var actualWords = _translator.Translate(numberText);

            // Assert
            Assert.That(actualWords, Is.EqualTo(string.Empty));
        }

        [TestCase("0", "zero dollars")]
        [TestCase("1", "one dollar")]
        [TestCase("25,10", "twenty-five dollars and ten cents")]
        [TestCase("0,01", "zero dollars and one cent")]
        [TestCase("0,1", "zero dollars and ten cents")]
        [TestCase("45 100", "forty-five thousand one hundred dollars")]
        [TestCase("999 999 999,99", "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents")]
        public void WhenNumberTextIsCorrectShouldTranslateToNumberInWords(string numberText, string expectedWords)
        {
            // Arrange

            // Act
            var actualWords = _translator.Translate(numberText);

            // Assert
            Assert.That(actualWords, Is.EqualTo(expectedWords));
        }

        [Test]
        public void WhenFractionPartOfNumberIsGreatherThan99ShouldThrowNotSupportedException()
        {
            // Arrange
            string text = "1,2345";

            // Act

            // Assert
            Assert.Throws<NotSupportedException>(() => _translator.Translate(text));
        }
    }
}