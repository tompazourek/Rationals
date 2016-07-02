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
    public class BaseTests
    {
        [Test]
        public void Constructor()
        {
            // arrange
            var rational = new Rational(new BigInteger(1), new BigInteger(2));

            // action
            var numerator = rational.Numerator;
            var denominator = rational.Denominator;

            // assert
            Assert.AreEqual(new BigInteger(1), numerator);
            Assert.AreEqual(new BigInteger(2), denominator);
        }

        [Test]
        public void Constructor_DenominatorZero()
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Catch(() => new Rational(new BigInteger(1), new BigInteger(0)));
        }

        [Test]
        public void Constructor_Whole()
        {
            // arrange
            var rational = new Rational(3);

            // action
            var numerator = rational.Numerator;
            var denominator = rational.Denominator;

            // assert
            Assert.AreEqual(new BigInteger(3), numerator);
            Assert.AreEqual(new BigInteger(1), denominator);
        }

        [Test]
        public void Constructor_WholeZero()
        {
            // arrange
            var rational = new Rational(0);

            // action
            var numerator = rational.Numerator;
            var denominator = rational.Denominator;

            // assert
            Assert.AreEqual(new BigInteger(0), numerator);
            Assert.AreEqual(new BigInteger(1), denominator);
        }
    }
}