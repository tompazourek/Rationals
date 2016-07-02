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
    public class FormattingTests
    {
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

        [Test]
        [TestCase(3, 4, "3/4")]
        [TestCase(3, -4, "3/-4")]
        [TestCase(-3, -4, "-3/-4")]
        [TestCase(6, 2, "6/2")]
        [TestCase(12, 1, "12")]
        [TestCase(12, -1, "12/-1")]
        [TestCase(0, 50, "0")]
        public void Format(long numerator, long denominator, string expectedResult)
        {
            // arrange
            var rational = new Rational(numerator, denominator);

            // action
            var result = rational.ToString();

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(3, 4, "3/4")]
        [TestCase(3, -4, "-3/4")]
        [TestCase(-3, -4, "3/4")]
        [TestCase(6, 2, "3")]
        [TestCase(12, 1, "12")]
        [TestCase(12, -1, "-12")]
        [TestCase(0, 50, "0")]
        public void Format_C(long numerator, long denominator, string expectedResult)
        {
            // arrange
            var rational = new Rational(numerator, denominator);

            // action
            var result = rational.ToString("C");

            // assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(15, 7, "2 + 1/7")]
        [TestCase(-15, 7, "-3 + 6/7")]
        [TestCase(3, 4, "3/4")]
        [TestCase(3, -4, "-1 + 1/4")]
        [TestCase(-3, -4, "3/4")]
        [TestCase(6, 2, "3")]
        [TestCase(12, 1, "12")]
        [TestCase(12, -1, "-12")]
        [TestCase(0, 50, "0")]
        [TestCase(4, 3, "1 + 1/3")]
        [TestCase(4, -3, "-2 + 2/3")]
        [TestCase(-4, -3, "1 + 1/3")]
        public void Format_W(long numerator, long denominator, string expectedResult)
        {
            // arrange
            var rational = new Rational(numerator, denominator);

            // action
            var result = rational.ToString("W");

            // assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}