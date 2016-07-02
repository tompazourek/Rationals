#region License

// Copyright (C) Tomáš Pažourek, 2016
// All rights reserved.
// 
// Distributed under MIT license as a part of project Rationals.
// https://github.com/tompazourek/Rationals

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using NUnit.Framework;
using Rationals;

namespace RationalTests
{
    [TestFixture]
    public class WholeAndFractionTests
    {
        [Test]
        [TestCase(1, 2, 1, 2)]
        [TestCase(-5, 10, 5, 10)]
        [TestCase(-49, 10, 1, 10)]
        [TestCase(0, 5, 0, 1)]
        [TestCase(213, 1, 0, 1)]
        [TestCase(456, 456, 0, 1)]
        [TestCase(45, 9, 0, 1)]
        [TestCase(45, 10, 5, 10)]
        [TestCase(-4, -3, 1, 3)]
        [TestCase(-3, -4, 3, 4)]
        public void FractionPart(int numerator, int denominator, int fractionPartNumerator, int fractionPartDenominator)
        {
            // arrange
            var p = (Rational) numerator / denominator;

            // assert
            Assert.AreEqual(new Rational(fractionPartNumerator, fractionPartDenominator), p.FractionPart);
        }

        [Test]
        [TestCase(1, 2)]
        [TestCase(-5, 10)]
        [TestCase(-49, 10)]
        [TestCase(0, 5)]
        [TestCase(213, 1)]
        [TestCase(456, 456)]
        [TestCase(45, 9)]
        [TestCase(45, 10)]
        [TestCase(-4, -3)]
        [TestCase(-3, -4)]
        public void WholeAndFraction_Sum(int numerator, int denominator)
        {
            // arrange
            var p = (Rational) numerator / denominator;

            // action
            var wholePart = p.WholePart;
            var fractionPart = p.FractionPart;

            // assert
            Assert.AreEqual(p, wholePart + fractionPart);
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
        [TestCase(-4, -3, 1)]
        [TestCase(-3, -4, 0)]
        public void WholePart(int numerator, int denominator, int wholePart)
        {
            // arrange
            var p = (Rational) numerator / denominator;

            // assert
            Assert.AreEqual((BigInteger) wholePart, p.WholePart);
        }
    }
}