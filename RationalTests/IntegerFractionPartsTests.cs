using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rationals;
using System.Numerics;

namespace RationalTests
{
    [TestFixture]
    public class IntegerFractionPartsTests
    {
        [Test]
        [TestCase(1, 2)]
        [TestCase(-5, 10)]
        [TestCase(-49, 10)]
        [TestCase(0, 5)]
        [TestCase(213, 1)]
        [TestCase(456, 456)]
        [TestCase(45, 9)]
        [TestCase(45, 10)]
        public void IntegerFractionPart_Sum(int numerator, int denominator)
        {
            // arrange
            var p = (Rational)numerator / denominator;

            // action
            var integerPart = p.IntegerPart;
            var fractionPart = p.FractionPart;

            // assert
            Assert.AreEqual(p, integerPart + fractionPart);
        }

        [Test]
        [TestCase(1, 2, 0)]
        [TestCase(-5, 10, -1)]
        [TestCase(-49, 10, -5)]
        [TestCase(0, 5, 0)]
        [TestCase(213, 1, 213)]
        [TestCase(456, 456, 1)]
        [TestCase(45, 9, 5)]
        [TestCase(45, 10, 4)]
        public void IntegerPart(int numerator, int denominator, int integerPart)
        {
            // arrange
            var p = (Rational)numerator / denominator;

            // action
            var computedIntegerPart = p.IntegerPart;

            // assert
            Assert.AreEqual((BigInteger)integerPart, computedIntegerPart);
        }

        [Test]
        [TestCase(1, 2, 1, 2)]
        [TestCase(-5, 10, 5, 10)]
        [TestCase(-49, 10, 1, 10)]
        [TestCase(0, 5, 0, 1)]
        [TestCase(213, 1, 0, 1)]
        [TestCase(456, 456, 0, 1)]
        [TestCase(45, 9, 0, 1)]
        [TestCase(45, 10, 5, 10)]
        public void FractionPart(int numerator, int denominator, int fractionPartNumerator, int fractionPartDenominator)
        {
            // arrange
            var p = (Rational)numerator / denominator;

            // action
            var computedIntegerPart = p.FractionPart;

            // assert
            Assert.AreEqual(new Rational(fractionPartNumerator, fractionPartDenominator), computedIntegerPart);
        }
    }
}