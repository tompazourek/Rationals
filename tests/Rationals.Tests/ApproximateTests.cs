using System;
using System.Globalization;
using Xunit;

namespace Rationals.Tests
{
    public class ApproximateTests
    {
        [Theory]
        [InlineData(0.333f, 0.0001f, 333, 1000)]
        [InlineData(-0.333f, 0.0001f, -333, 1000)]
        [InlineData(0.333f, 0.001f, 1, 3)]
        [InlineData(-0.333f, 0.001f, -1, 3)]
        [InlineData(2.5f, 0f, 5, 2)]
        [InlineData(-2.5f, 0f, -5, 2)]
        [InlineData(-1f, 0f, -1, 1)]
        [InlineData(1f, 0f, 1, 1)]
        public void ApproximateFloat(float input, float tolerance, int expectedNumerator, int expectedDenominator)
        {
            // action
            var rational = Rational.Approximate(input, tolerance);

            // assert
            Assert.Equal((Rational)expectedNumerator / expectedDenominator, rational);
        }

        [Fact]
        public void ApproximateFloatNaN()
        {
            // action
            var rational = Rational.Approximate(float.NaN);

            // assert
            Assert.Equal(Rational.NaN, rational);
        }

        [Theory]
        [InlineData(0.333d, 0.0001d, 333, 1000)]
        [InlineData(-0.333d, 0.0001d, -333, 1000)]
        [InlineData(0.333d, 0.001d, 1, 3)]
        [InlineData(-0.333d, 0.001d, -1, 3)]
        [InlineData(2.5d, 0d, 5, 2)]
        [InlineData(-2.5d, 0d, -5, 2)]
        [InlineData(-1d, 0d, -1, 1)]
        [InlineData(1d, 0d, 1, 1)]
        public void ApproximateDouble(double input, double tolerance, int expectedNumerator, int expectedDenominator)
        {
            // action
            var rational = Rational.Approximate(input, tolerance);

            // assert
            Assert.Equal((Rational)expectedNumerator / expectedDenominator, rational);
        }

        [Fact]
        public void ApproximateDoubleNaN()
        {
            // action
            var rational = Rational.Approximate(double.NaN);

            // assert
            Assert.Equal(Rational.NaN, rational);
        }

        [Theory]
        [InlineData(3, 1, 1.42E-1)]
        [InlineData(22, 7, 1.27E-3)]
        [InlineData(333, 106, 8.33E-5)]
        [InlineData(355, 113, 2.67E-7)]
        [InlineData(103993, 33102, 5.78E-10)]
        [InlineData(104348, 33215, 3.32E-10)]
        [InlineData(208341, 66317, 1.23E-10)]
        [InlineData(312689, 99532, 2.92E-11)]
        [InlineData(833719, 265381, 8.72E-12)]
        [InlineData(1146408, 364913, 1.62E-12)]
        public void ApproximatePI(int expectedNumerator, int expectedDenominator, double tolerance)
        {
            // action
            var rational = Rational.Approximate(Math.PI, tolerance);

            // assert
            Assert.Equal((Rational)expectedNumerator / expectedDenominator, rational);
        }

        [Theory]
        [InlineData("0.333", "0.0001", 333, 1000)]
        [InlineData("-0.333", "0.0001", -333, 1000)]
        [InlineData("0.333", "0.001", 1, 3)]
        [InlineData("-0.333", "0.001", -1, 3)]
        [InlineData("2.5", "0", 5, 2)]
        [InlineData("-2.5", "0", -5, 2)]
        [InlineData("-1", "0", -1, 1)]
        [InlineData("1", "0", 1, 1)]
        public void ApproximateDecimal(string inputStr, string toleranceStr, int expectedNumerator, int expectedDenominator)
        {
            // arrange
            var input = decimal.Parse(inputStr, CultureInfo.InvariantCulture);
            var tolerance = decimal.Parse(toleranceStr, CultureInfo.InvariantCulture);

            // action
            var rational = Rational.Approximate(input, tolerance);

            // assert
            Assert.Equal((Rational)expectedNumerator / expectedDenominator, rational);
        }
    }
}
