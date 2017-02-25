using System;
using System.Globalization;
using CurrencyTranslator.Business.Utils;
using NUnit.Framework;

namespace CurrencyTranslator.Business.UnitTests
{
    [TestFixture]
    public class NumberParserTests
    {
        private NumberParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new NumberParser();
        }

        [Test]
        public void WhenTextIsNullShouldThrowArgumentNullException()
        {
            // Arrange
            string text = null;

            // Act
            
            // Assert
            Assert.Throws<ArgumentNullException>(() => _parser.Parse(text));
        }

        [Test]
        public void WhenTextIsEmptyShouldThrowFormatException()
        {
            // Arrange
            string text = string.Empty;

            // Act

            // Assert
            Assert.Throws<FormatException>(() => _parser.Parse(text));
        }

        [TestCase("0", 0d)]
        [TestCase("1", 1d)]
        [TestCase("25 10", 2510d)]
        [TestCase("0,1", 0.1d)]
        [TestCase("45100", 45100d)]
        [TestCase("999 999  99 9 999", 999999999999d)]
        [TestCase("999 999 999 999", 999999999999d)]
        [TestCase("-999", -999d)]
        [TestCase("1,2345", 1.2345d)]
        // TestCase doesn't allow decimals
        public void WhenTextIsNumberShouldParseIntoDecimalValue(string text, decimal intermediateExpectedValue)
        {
            // Arrange
            decimal expectedValue = intermediateExpectedValue;

            // Act
            var actualValue = _parser.Parse(text);

            // Assert
            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void WhenTextIsNubmerGreatherThanDecimaMaxValueShouldThrowOverflowException()
        {
            // Arrange
            string text = decimal.MaxValue.ToString(CultureInfo.InvariantCulture) + "1";

            // Act

            // Assert
            Assert.Throws<OverflowException>(() => _parser.Parse(text));
        }

        [Test]
        public void WhenTextIsNubmerLowerThanDecimaMinValueShouldThrowOverflowException()
        {
            // Arrange
            string text = decimal.MinValue.ToString(CultureInfo.InvariantCulture) + "1";

            // Act

            // Assert
            Assert.Throws<OverflowException>(() => _parser.Parse(text));
        }


        [TestCase("zero")]
        [TestCase("1d")]
        [TestCase("Lorem ipsum")]
        [TestCase("79,228,162,514,264,337,593,543,950,335")]
        [TestCase("1,234,56")]
        [TestCase("1,234.56")]
        [TestCase(",234")]
        public void WhenTextIsNotANumberShouldThrowFormatException(string text)
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<FormatException>(() => _parser.Parse(text));
        }

        [Test]
        public void WhenSeparatorIsNotCommaShouldThrowNotSupportedException()
        {
            // Arrange
            string text = "1.234";

            // Act

            // Assert
            Assert.Throws<NotSupportedException>(() => _parser.Parse(text));
        }
    }
}