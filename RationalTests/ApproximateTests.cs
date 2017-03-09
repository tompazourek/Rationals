using System;
using System.Globalization;
using NUnit.Framework;
using Rationals;

namespace RationalTests
{
    [TestFixture]
    public class ApproximateTests
    {
        [TestCase(0.333f, 0.0001f, 333, 1000)]
        [TestCase(-0.333f, 0.0001f, -333, 1000)]
        [TestCase(0.333f, 0.001f, 1, 3)]
        [TestCase(-0.333f, 0.001f, -1, 3)]
        [TestCase(2.5f, 0f, 5, 2)]
        [TestCase(-2.5f, 0f, -5, 2)]
        [TestCase(-1f, 0f, -1, 1)]
        [TestCase(1f, 0f, 1, 1)]
        public void ApproximateFloat(float input, float tolerance, int expectedNumerator, int expectedDenominator)
        {
            // action
            var rational = Rational.Approximate(input, tolerance);

            // assert
            Assert.AreEqual((Rational) expectedNumerator / expectedDenominator, rational);
        }

        [TestCase(0.333d, 0.0001d, 333, 1000)]
        [TestCase(-0.333d, 0.0001d, -333, 1000)]
        [TestCase(0.333d, 0.001d, 1, 3)]
        [TestCase(-0.333d, 0.001d, -1, 3)]
        [TestCase(2.5d, 0d, 5, 2)]
        [TestCase(-2.5d, 0d, -5, 2)]
        [TestCase(-1d, 0d, -1, 1)]
        [TestCase(1d, 0d, 1, 1)]
        public void ApproximateDouble(double input, double tolerance, int expectedNumerator, int expectedDenominator)
        {
            // action
            var rational = Rational.Approximate(input, tolerance);

            // assert
            Assert.AreEqual((Rational) expectedNumerator / expectedDenominator, rational);
        }

        [TestCase(3, 1, 1.42E-1)]
        [TestCase(22, 7, 1.27E-3)]
        [TestCase(333, 106, 8.33E-5)]
        [TestCase(355, 113, 2.67E-7)]
        [TestCase(103993, 33102, 5.78E-10)]
        [TestCase(104348, 33215, 3.32E-10)]
        [TestCase(208341, 66317, 1.23E-10)]
        [TestCase(312689, 99532, 2.92E-11)]
        [TestCase(833719, 265381, 8.72E-12)]
        [TestCase(1146408, 364913, 1.62E-12)]
        public void ApproximatePI(int expectedNumerator, int expectedDenominator, double tolerance)
        {
            // action
            var rational = Rational.Approximate(Math.PI, tolerance);

            // assert
            Assert.AreEqual((Rational) expectedNumerator / expectedDenominator, rational);
        }

        [TestCase("0.333", "0.0001", 333, 1000)]
        [TestCase("-0.333", "0.0001", -333, 1000)]
        [TestCase("0.333", "0.001", 1, 3)]
        [TestCase("-0.333", "0.001", -1, 3)]
        [TestCase("2.5", "0", 5, 2)]
        [TestCase("-2.5", "0", -5, 2)]
        [TestCase("-1", "0", -1, 1)]
        [TestCase("1", "0", 1, 1)]
        public void ApproximateDecimal(string inputStr, string toleranceStr, int expectedNumerator,
            int expectedDenominator)
        {
            // arrange
            var input = decimal.Parse(inputStr, CultureInfo.InvariantCulture);
            var tolerance = decimal.Parse(toleranceStr, CultureInfo.InvariantCulture);

            // action
            var rational = Rational.Approximate(input, tolerance);

            // assert
            Assert.AreEqual((Rational) expectedNumerator / expectedDenominator, rational);
        }
    }
}