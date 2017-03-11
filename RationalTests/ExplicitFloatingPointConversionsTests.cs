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
    [TestFixture(Category = "Explicit Floating Point Conversions")]
    public class ExplicitFloatingPointConversionsTests
    {
        private const double doubleDelta = 1.0E-15d;
        private const float floatDelta = 1.0E-6f;

        [TestCase(0.5, 1, 2)]
        [TestCase(-0.5, -1, 2)]
        [TestCase(0.0, 0, 1)]
        [TestCase(-0.0, 0, 1)]
        [TestCase(1.33, 133, 100)]
        [TestCase(-1.33, -133, 100)]
        [TestCase(213213.2132132432, 64057990991, 300441)]
        [TestCase(-213213.2132132432, -64057990991, 300441)]
        [TestCase(3.45, 69, 20)]
        [TestCase(-3.45, -69, 20)]
        public void FromDouble(double input, long expectedNumerator, long expectedDenominator)
        {
            // action
            var rational = (Rational) input;

            // assert
            Assert.AreEqual((Rational) expectedNumerator / expectedDenominator, rational);
        }

        [TestCase(double.NegativeInfinity)]
        [TestCase(double.PositiveInfinity)]
        [TestCase(double.NaN)]
        [TestCase(double.Epsilon)]
        public void FromDouble_Throws(double input)
        {
            // ReSharper disable once UnusedVariable
            Assert.Throws<OverflowException>(() =>
            {
                var x = (Rational) input;
            });
        }

        [TestCase(0.5f, 1, 2)]
        [TestCase(-0.5f, -1, 2)]
        [TestCase(0.0f, 0, 1)]
        [TestCase(-0.0f, 0, 1)]
        [TestCase(1.33f, 133, 100)]
        [TestCase(-1.33f, -133, 100)]
        [TestCase(9843.55f, 196871, 20)]
        [TestCase(-9843.55f, -196871, 20)]
        [TestCase(3.45f, 69, 20)]
        [TestCase(-3.45f, -69, 20)]
        public void FromFloat(float input, long expectedNumerator, long expectedDenominator)
        {
            // action
            var rational = (Rational) input;

            // assert
            Assert.AreEqual((Rational) expectedNumerator / expectedDenominator, rational);
        }

        [TestCase(float.NegativeInfinity)]
        [TestCase(float.PositiveInfinity)]
        [TestCase(float.NaN)]
        [TestCase(float.Epsilon)]
        public void FromFloat_Throws(float input)
        {
            // ReSharper disable once UnusedVariable
            Assert.Throws<OverflowException>(() =>
            {
                var x = (Rational) input;
            });
        }

        [TestCase("0.5", 1, 2)]
        [TestCase("-0.5", -1, 2)]
        [TestCase("0.0", 0, 1)]
        [TestCase("-0.0", 0, 1)]
        [TestCase("1.33", 133, 100)]
        [TestCase("-1.33", -133, 100)]
        [TestCase("9843.55", 196871, 20)]
        [TestCase("-9843.55", -196871, 20)]
        [TestCase("3.45", 69, 20)]
        [TestCase("-3.45", -69, 20)]
        public void FromDecimal(string inputStr, long expectedNumerator, long expectedDenominator)
        {
            // arrange
            var input = decimal.Parse(inputStr);

            // action
            var rational = (Rational) input;

            // assert
            Assert.AreEqual((Rational) expectedNumerator / expectedDenominator, rational);
        }

        [Test]
        public void FromDecimal_MaxValue()
        {
            // ReSharper disable once UnusedVariable
            Assert.DoesNotThrow(() =>
            {
                var x = (Rational) decimal.MaxValue;
            });
        }

        [Test]
        public void FromDecimal_MinValue()
        {
            // ReSharper disable once UnusedVariable
            Assert.DoesNotThrow(() =>
            {
                var x = (Rational) decimal.MinValue;
            });
        }

        [Test]
        public void FromDouble_MaxValue_Throws()
        {
            // ReSharper disable once UnusedVariable
            Assert.Throws<OverflowException>(() =>
            {
                var x = (Rational) double.MaxValue;
            });
        }

        [Test]
        public void FromDouble_MinValue_Throws()
        {
            // ReSharper disable once UnusedVariable
            Assert.Throws<OverflowException>(() =>
            {
                var x = (Rational) double.MinValue;
            });
        }


        [Test]
        public void FromFloat_MaxValue()
        {
            // ReSharper disable once UnusedVariable
            Assert.DoesNotThrow(() =>
            {
                var x = (Rational) float.MaxValue;
            });
        }

        [Test]
        public void FromFloat_MinValue()
        {
            // ReSharper disable once UnusedVariable
            Assert.DoesNotThrow(() =>
            {
                var x = (Rational) float.MinValue;
            });
        }

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