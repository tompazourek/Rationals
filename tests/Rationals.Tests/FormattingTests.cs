using System.Linq;
using Xunit;

namespace Rationals.Tests
{
    public class FormattingTests
    {
        [Theory]
        [InlineData(200, 1, "2")]
        [InlineData(1, 2, "5")]
        [InlineData(1, 3, "3333333333")]
        [InlineData(-213, 31, "6870967741")]
        [InlineData(0, 1, "0")]
        [InlineData(1, 10000, "1")]
        public void Digits_Take10(int numerator, int denominator, string expectedDigits)
        {
            // arrange
            var rational = new Rational(numerator, denominator);

            // action
            var digits = new string(rational.Digits.Take(10).ToArray());

            // assert
            Assert.Equal(expectedDigits, digits);
        }

        [Fact]
        public void Digits_NaN()
        {
            // arrange
            var rational = Rational.NaN;

            // action
            var digits = new string(rational.Digits.Take(10).ToArray());

            // assert
            Assert.Equal(string.Empty, digits);
        }

        [Theory]
        [InlineData(3, 4, "3/4")]
        [InlineData(3, -4, "3/-4")]
        [InlineData(-3, -4, "-3/-4")]
        [InlineData(6, 2, "6/2")]
        [InlineData(12, 1, "12")]
        [InlineData(12, -1, "12/-1")]
        [InlineData(0, 50, "0")]
        public void Format(long numerator, long denominator, string expectedResult)
        {
            // arrange
            var rational = new Rational(numerator, denominator);

            // action
            var result = rational.ToString();

            // assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Format_NaN()
        {
            // arrange
            var rational = Rational.NaN;

            // action
            var result = rational.ToString();

            // assert
            Assert.Equal("NaN", result);
        }

        [Theory]
        [InlineData(3, 4, "3/4")]
        [InlineData(3, -4, "-3/4")]
        [InlineData(-3, -4, "3/4")]
        [InlineData(6, 2, "3")]
        [InlineData(12, 1, "12")]
        [InlineData(12, -1, "-12")]
        [InlineData(0, 50, "0")]
        public void Format_C(long numerator, long denominator, string expectedResult)
        {
            // arrange
            var rational = new Rational(numerator, denominator);

            // action
            var result = rational.ToString("C");

            // assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Format_C_NaN()
        {
            // arrange
            var rational = Rational.NaN;

            // action
            var result = rational.ToString("C");

            // assert
            Assert.Equal("NaN", result);
        }

        [Theory]
        [InlineData(15, 7, "2 + 1/7")]
        [InlineData(-15, 7, "-3 + 6/7")]
        [InlineData(3, 4, "3/4")]
        [InlineData(3, -4, "-1 + 1/4")]
        [InlineData(-3, -4, "3/4")]
        [InlineData(6, 2, "3")]
        [InlineData(12, 1, "12")]
        [InlineData(12, -1, "-12")]
        [InlineData(0, 50, "0")]
        [InlineData(4, 3, "1 + 1/3")]
        [InlineData(4, -3, "-2 + 2/3")]
        [InlineData(-4, -3, "1 + 1/3")]
        public void Format_W(long numerator, long denominator, string expectedResult)
        {
            // arrange
            var rational = new Rational(numerator, denominator);

            // action
            var result = rational.ToString("W");

            // assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Format_W_NaN()
        {
            // arrange
            var rational = Rational.NaN;

            // action
            var result = rational.ToString("W");

            // assert
            Assert.Equal("NaN", result);
        }
    }
}
