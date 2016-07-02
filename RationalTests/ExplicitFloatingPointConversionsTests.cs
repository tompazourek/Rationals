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
    public class ExplicitFloatingPointConversionsTests
    {
        private const double doubleDelta = 1.0E-15d;
        private const float floatDelta = 1.0E-6f;

        [Test]
        public void ToDecimal1()
        {
            // arrange
            var rational = (Rational) 1 / 2;
            const decimal d = (decimal) 1 / 2;

            // action
            var converted = (decimal) rational;

            // assert
            Assert.AreEqual(d, converted);
        }

        [Test]
        public void ToDecimal2()
        {
            // arrange
            var rational = new Rational(9283179832312321307, 7283179832312121317);
            const decimal d = 1.274605329821339747580867376182701966618626893951518748813482M;

            // action
            var converted = (decimal) rational;

            // assert
            Assert.AreEqual(d, converted);
        }

        [Test]
        public void ToDecimal3()
        {
            // arrange
            var rational = new Rational(BigInteger.Parse("999999999999999999999999999999"),
                BigInteger.Parse("10000000000000000000000000000"));
            const decimal d = 99.9999999999999999999999999999M;

            // action
            var converted = (decimal) rational;

            // assert
            Assert.AreEqual(d, converted);
        }

        [Test]
        public void ToDecimal4()
        {
            // arrange
            var rational = -(Rational) 1 / 6;
            const decimal d = -(decimal) 1 / 6;

            // action
            var converted = (decimal) rational;

            // assert
            Assert.AreEqual(d, converted);
        }

        [Test]
        public void ToDecimal5()
        {
            // arrange
            var rational = (Rational) 4 / -3;
            const decimal d = (decimal) 4 / -3;

            // action
            var converted = (decimal) rational;

            // assert
            Assert.AreEqual(d, converted);
        }

        [Test]
        public void ToDouble1()
        {
            // arrange
            var rational = (Rational) 1 / 2;
            const double d = (double) 1 / 2;

            // action
            var converted = (double) rational;

            // assert
            Assert.AreEqual(d, converted, doubleDelta);
        }

        [Test]
        public void ToDouble2()
        {
            // arrange
            var rational = new Rational(9283179832312321307, 7283179832312121317);
            const double d = 1.274605329821339747580867376182701966618626893951518748813482d;

            // action
            var converted = (double) rational;

            // assert
            Assert.AreEqual(d, converted, doubleDelta);
        }

        [Test]
        public void ToDouble3()
        {
            // arrange
            var rational = new Rational(BigInteger.Parse("999999999999999999999999999999"),
                BigInteger.Parse("100000000000000000000000000000"));
            const double d = 9.99999999999999999999999999999d;

            // action
            var converted = (double) rational;

            // assert
            Assert.AreEqual(d, converted, doubleDelta);
        }

        [Test]
        public void ToDouble4()
        {
            // arrange
            var rational = -(Rational) 1 / 6;
            const double d = -(double) 1 / 6;

            // action
            var converted = (double) rational;

            // assert
            Assert.AreEqual(d, converted, doubleDelta);
        }

        [Test]
        public void ToDouble5()
        {
            // arrange
            var rational = (Rational) 4 / -3;
            const double d = (double) 4 / -3;

            // action
            var converted = (double) rational;

            // assert
            Assert.AreEqual(d, converted, doubleDelta);
        }


        [Test]
        public void ToFloat1()
        {
            // arrange
            var rational = (Rational) 1 / 2;
            const float d = (float) 1 / 2;

            // action
            var converted = (float) rational;

            // assert
            Assert.AreEqual(d, converted, floatDelta);
        }

        [Test]
        public void ToFloat2()
        {
            // arrange
            var rational = new Rational(9283179832312321307, 7283179832312121317);
            const float d = 1.274605329821339747580867376182701966618626893951518748813482f;

            // action
            var converted = (float) rational;

            // assert
            Assert.AreEqual(d, converted, floatDelta);
        }

        [Test]
        public void ToFloat3()
        {
            // arrange
            var rational = new Rational(BigInteger.Parse("999999999999999999999999999999"),
                BigInteger.Parse("100000000000000000000000000000"));
            const float d = 9.99999999999999999999999999999f;

            // action
            var converted = (float) rational;

            // assert
            Assert.AreEqual(d, converted, floatDelta);
        }

        [Test]
        public void ToFloat4()
        {
            // arrange
            var rational = -(Rational) 1 / 6;
            const float d = -(float) 1 / 6;

            // action
            var converted = (float) rational;

            // assert
            Assert.AreEqual(d, converted, floatDelta);
        }

        [Test]
        public void ToFloat5()
        {
            // arrange
            var rational = (Rational) 4 / -3;
            const float d = (float) 4 / -3;

            // action
            var converted = (float) rational;

            // assert
            Assert.AreEqual(d, converted, floatDelta);
        }
    }
}