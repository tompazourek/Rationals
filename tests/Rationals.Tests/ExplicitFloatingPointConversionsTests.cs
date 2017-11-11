using System;
using System.Globalization;
using System.Numerics;
using Xunit;

namespace Rationals.Tests
{
    public class ExplicitFloatingPointConversionsTests
    {
        private const int DoublePrecision = 14;
        private const int FloatPrecision = 6;

        [Theory]
        [InlineData(0.5, 1, 2)]
        [InlineData(-0.5, -1, 2)]
        [InlineData(0.0, 0, 1)]
        [InlineData(1.33, 133, 100)]
        [InlineData(-1.33, -133, 100)]
        [InlineData(213213.2132132432, 64057990991, 300441)]
        [InlineData(-213213.2132132432, -64057990991, 300441)]
        [InlineData(3.45, 69, 20)]
        [InlineData(-3.45, -69, 20)]
        public void FromDouble(double input, long expectedNumerator, long expectedDenominator)
        {
            // action
            var rational = (Rational)input;

            // assert
            Assert.Equal((Rational)expectedNumerator / expectedDenominator, rational);
        }

        [Theory]
        [InlineData(double.NegativeInfinity)]
        [InlineData(double.PositiveInfinity)]
        [InlineData(double.NaN)]
        [InlineData(double.Epsilon)]
        public void FromDouble_Throws(double input)
        {
            // ReSharper disable once UnusedVariable
            Assert.Throws<OverflowException>(() =>
            {
                var x = (Rational)input;
            });
        }

        [Theory]
        [InlineData(0.5f, 1, 2)]
        [InlineData(-0.5f, -1, 2)]
        [InlineData(0.0f, 0, 1)]
        [InlineData(1.33f, 133, 100)]
        [InlineData(-1.33f, -133, 100)]
        [InlineData(9843.55f, 196871, 20)]
        [InlineData(-9843.55f, -196871, 20)]
        [InlineData(3.45f, 69, 20)]
        [InlineData(-3.45f, -69, 20)]
        public void FromFloat(float input, long expectedNumerator, long expectedDenominator)
        {
            // action
            var rational = (Rational)input;

            // assert
            Assert.Equal((Rational)expectedNumerator / expectedDenominator, rational);
        }

        [Theory]
        [InlineData(float.NegativeInfinity)]
        [InlineData(float.PositiveInfinity)]
        [InlineData(float.NaN)]
        [InlineData(float.Epsilon)]
        public void FromFloat_Throws(float input)
        {
            // ReSharper disable once UnusedVariable
            Assert.Throws<OverflowException>(() =>
            {
                var x = (Rational)input;
            });
        }

        [Theory]
        [InlineData("0.5", 1, 2)]
        [InlineData("-0.5", -1, 2)]
        [InlineData("0.0", 0, 1)]
        [InlineData("-0.0", 0, 1)]
        [InlineData("1.33", 133, 100)]
        [InlineData("-1.33", -133, 100)]
        [InlineData("9843.55", 196871, 20)]
        [InlineData("-9843.55", -196871, 20)]
        [InlineData("3.45", 69, 20)]
        [InlineData("-3.45", -69, 20)]
        public void FromDecimal(string inputStr, long expectedNumerator, long expectedDenominator)
        {
            // arrange
            var input = decimal.Parse(inputStr, CultureInfo.InvariantCulture);

            // action
            var rational = (Rational)input;

            // assert
            Assert.Equal((Rational)expectedNumerator / expectedDenominator, rational);
        }

        [Fact]
        public void FromDecimal_MaxValue()
        {
            // ReSharper disable once UnusedVariable
            var x = (Rational)decimal.MaxValue;
        }

        [Fact]
        public void FromDecimal_MinValue()
        {
            // ReSharper disable once UnusedVariable
            var x = (Rational)decimal.MinValue;
        }

        [Fact]
        public void FromDouble_MaxValue_Throws()
        {
            // ReSharper disable once UnusedVariable
            Assert.Throws<OverflowException>(() =>
            {
                var x = (Rational)double.MaxValue;
            });
        }

        [Fact]
        public void FromDouble_MinValue_Throws()
        {
            // ReSharper disable once UnusedVariable
            Assert.Throws<OverflowException>(() =>
            {
                var x = (Rational)double.MinValue;
            });
        }


        [Fact]
        public void FromFloat_MaxValue()
        {
            // ReSharper disable once UnusedVariable
            var x = (Rational)float.MaxValue;
        }

        [Fact]
        public void FromFloat_MinValue()
        {
            // ReSharper disable once UnusedVariable
            var x = (Rational)float.MinValue;
        }

        [Fact]
        public void ToDecimal1()
        {
            // arrange
            var rational = (Rational)1 / 2;
            const decimal d = (decimal)1 / 2;

            // action
            var converted = (decimal)rational;

            // assert
            Assert.Equal(d, converted);
        }

        [Fact]
        public void ToDecimal2()
        {
            // arrange
            var rational = new Rational(9283179832312321307, 7283179832312121317);
            const decimal d = 1.274605329821339747580867376182701966618626893951518748813482M;

            // action
            var converted = (decimal)rational;

            // assert
            Assert.Equal(d, converted);
        }

        [Fact]
        public void ToDecimal3()
        {
            // arrange
            var rational = new Rational(BigInteger.Parse("999999999999999999999999999999"),
                BigInteger.Parse("10000000000000000000000000000"));
            const decimal d = 99.9999999999999999999999999999M;

            // action
            var converted = (decimal)rational;

            // assert
            Assert.Equal(d, converted);
        }

        [Fact]
        public void ToDecimal4()
        {
            // arrange
            var rational = -(Rational)1 / 6;
            const decimal d = -(decimal)1 / 6;

            // action
            var converted = (decimal)rational;

            // assert
            Assert.Equal(d, converted);
        }

        [Fact]
        public void ToDecimal5()
        {
            // arrange
            var rational = (Rational)4 / -3;
            const decimal d = (decimal)4 / -3;

            // action
            var converted = (decimal)rational;

            // assert
            Assert.Equal(d, converted);
        }

        [Fact]
        public void ToDouble1()
        {
            // arrange
            var rational = (Rational)1 / 2;
            const double d = (double)1 / 2;

            // action
            var converted = (double)rational;

            // assert
            Assert.Equal(d, converted, DoublePrecision);
        }

        [Fact]
        public void ToDouble2()
        {
            // arrange
            var rational = new Rational(9283179832312321307, 7283179832312121317);
            const double d = 1.274605329821339747580867376182701966618626893951518748813482d;

            // action
            var converted = (double)rational;

            // assert
            Assert.Equal(d, converted, DoublePrecision);
        }

        [Fact]
        public void ToDouble3()
        {
            // arrange
            var rational = new Rational(BigInteger.Parse("999999999999999999999999999999"),
                BigInteger.Parse("100000000000000000000000000000"));
            const double d = 9.99999999999999999999999999999d;

            // action
            var converted = (double)rational;

            // assert
            Assert.Equal(d, converted, DoublePrecision);
        }

        [Fact]
        public void ToDouble4()
        {
            // arrange
            var rational = -(Rational)1 / 6;
            const double d = -(double)1 / 6;

            // action
            var converted = (double)rational;

            // assert
            Assert.Equal(d, converted, DoublePrecision);
        }

        [Fact]
        public void ToDouble5()
        {
            // arrange
            var rational = (Rational)4 / -3;
            const double d = (double)4 / -3;

            // action
            var converted = (double)rational;

            // assert
            Assert.Equal(d, converted, DoublePrecision);
        }

        [Fact]
        public void ToFloat1()
        {
            // arrange
            var rational = (Rational)1 / 2;
            const float d = (float)1 / 2;

            // action
            var converted = (float)rational;

            // assert
            Assert.Equal(d, converted, FloatPrecision);
        }

        [Fact]
        public void ToFloat2()
        {
            // arrange
            var rational = new Rational(9283179832312321307, 7283179832312121317);
            const float d = 1.274605329821339747580867376182701966618626893951518748813482f;

            // action
            var converted = (float)rational;

            // assert
            Assert.Equal(d, converted, FloatPrecision);
        }

        [Fact]
        public void ToFloat3()
        {
            // arrange
            var rational = new Rational(BigInteger.Parse("999999999999999999999999999999"),
                BigInteger.Parse("100000000000000000000000000000"));
            const float d = 9.99999999999999999999999999999f;

            // action
            var converted = (float)rational;

            // assert
            Assert.Equal(d, converted, FloatPrecision);
        }

        [Fact]
        public void ToFloat4()
        {
            // arrange
            var rational = -(Rational)1 / 6;
            const float d = -(float)1 / 6;

            // action
            var converted = (float)rational;

            // assert
            Assert.Equal(d, converted, FloatPrecision);
        }

        [Fact]
        public void ToFloat5()
        {
            // arrange
            var rational = (Rational)4 / -3;
            const float d = (float)4 / -3;

            // action
            var converted = (float)rational;

            // assert
            Assert.Equal(d, converted, FloatPrecision);
        }
    }
}