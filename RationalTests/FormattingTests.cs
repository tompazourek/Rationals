using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rationals;

namespace RationalTests
{
    [TestFixture]
    public class FormattingTests
    {
        [Test]
        public void Format()
        {
            // arrange
            var rational = new Rational(new BigInteger(3), new BigInteger(4));

            // action
            string formatted = rational.ToString();

            // assert
            Assert.AreEqual("3/4", formatted);
        }

        [Test]
        public void Format_C()
        {
            // arrange
            var rational = new Rational(new BigInteger(14), new BigInteger(7));

            // action
            string formatted = rational.ToString("C", CultureInfo.CurrentCulture);

            // assert
            Assert.AreEqual("2", formatted);
        }

        [Test]
        public void Format_W()
        {
            // arrange
            var rational = new Rational(new BigInteger(15), new BigInteger(7));

            // action
            string formatted = rational.ToString("W", CultureInfo.CurrentCulture);

            // assert
            Assert.AreEqual("2 + 1/7", formatted);
        }

        [Test]
        [TestCase(200, 1, "2")]
        [TestCase(1, 2, "5")]
        [TestCase(1, 3, "3333333333")]
        [TestCase(-213, 31, "6870967741")]
        [TestCase(0, 1, "0")]
        [TestCase(1, 10000, "1")]
        public void Digits_Take10(int numerator, int denominator, string expectedDigits)
        {
            // arrange
            var rational = new Rational(numerator, denominator);

            // action
            var digits = new string(rational.Digits.Take(10).ToArray());

            // assert
            Assert.AreEqual(expectedDigits, digits);
        }

    }
}