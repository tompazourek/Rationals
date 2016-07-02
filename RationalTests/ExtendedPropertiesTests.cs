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
    public class ExtendedPropertiesTests
    {
        [Test]
        [TestCase(1, 1, 0)]
        [TestCase(2, 1, 0)]
        [TestCase(0, 1, 0)]
        [TestCase(10, 1, 1)]
        [TestCase(11, 1, 1)]
        [TestCase(11, 2, 0)]
        [TestCase(1, 2, -1)]
        [TestCase(1, 10, -1)]
        [TestCase(1, 11, -2)]
        [TestCase(2654111, 1, 6)]
        [TestCase(1, 2654111, -7)]
        public void Magnitude(int numerator, int denominator, int expectedMagnitude)
        {
            // arrange
            var rational = new Rational(numerator, denominator);

            // action
            var magnitude = rational.Magnitude;

            // assert
            Assert.AreEqual(expectedMagnitude, magnitude);
        }

        [Test]
        public void PowersOfTwo()
        {
            // arrange
            var rationals = new[]
            {1, 0, -1, (Rational) 5 / 4, 2, -2, 4, 8, 16, (Rational) 1 / 2, (Rational) 4 / 16, 64, (Rational) 1024 / 3};

            // action
            var powers = rationals.Where(x => x.IsPowerOfTwo).ToList();

            // assert
            var expected = new[] {1, 2, 4, 8, 16, (Rational) 1 / 2, (Rational) 4 / 16, 64};
            CollectionAssert.AreEqual(expected, powers);
        }

        [Test]
        public void Sign1()
        {
            // arrange
            var p = new Rational(1, 4);

            // assert
            Assert.AreEqual(1, p.Sign);
        }

        [Test]
        public void Sign2()
        {
            // arrange
            var p = new Rational(-1, 4);

            // assert
            Assert.AreEqual(-1, p.Sign);
        }

        [Test]
        public void Sign3()
        {
            // arrange
            var p = new Rational(1, -4);

            // assert
            Assert.AreEqual(-1, p.Sign);
        }

        [Test]
        public void Sign4()
        {
            // arrange
            var p = new Rational(-1, -4);

            // assert
            Assert.AreEqual(1, p.Sign);
        }

        [Test]
        public void Sign5()
        {
            // arrange
            var p = new Rational(0, -4);

            // assert
            Assert.AreEqual(0, p.Sign);
        }

        [Test]
        public void Sign6()
        {
            // arrange
            var p = new Rational(0, 1);

            // assert
            Assert.AreEqual(0, p.Sign);
        }
    }
}