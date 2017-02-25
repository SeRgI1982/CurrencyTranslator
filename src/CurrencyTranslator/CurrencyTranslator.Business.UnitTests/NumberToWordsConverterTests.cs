using System;
using CurrencyTranslator.Business.Utils;
using NUnit.Framework;

namespace CurrencyTranslator.Business.UnitTests
{
    [TestFixture]
    public class NumberToWordsConverterTests
    {
        private NumberToWordsConverter _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new NumberToWordsConverter();
        }

        [TestCase(0, "zero")]
        [TestCase(1, "one")]
        [TestCase(25, "twenty-five")]
        [TestCase(45100, "forty-five thousand one hundred")]
        [TestCase(999999999, "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine")]
        public void WhenNumberIsPositiveShouldConvertIntoWords(int number, string expectedWords)
        {
            // Arrange

            // Act
            var actualWords = _converter.Convert(number);

            // Assert
            Assert.That(actualWords, Is.EqualTo(expectedWords));
        }

        [TestCase(-0, "zero")]
        [TestCase(-1, "minus one")]
        public void WhenNumberIsNegativeShouldStartWithWordMinus(int number, string expectedWords)
        {
            // Arrange

            // Act
            var actualWords = _converter.Convert(number);

            // Assert
            Assert.That(actualWords, Is.EqualTo(expectedWords));
        }

        [Test]
        public void WhenNumberIsGreatherThan999999999ShouldTrowIndexOutOfRangeException()
        {
            // Arrange
            int number = 1000000000;

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => _converter.Convert(number));
        }
    }
}