#region License

// Copyright (C) Tomáš Pažourek, 2016
// All rights reserved.
// 
// Distributed under MIT license as a part of project Rationals.
// https://github.com/tompazourek/Rationals

#endregion

using System.Numerics;
using NUnit.Framework;
using Rationals;

namespace RationalTests
{
    [TestFixture(Category = "Canonical Form")]
    public class CanonicalTests
    {
        [Test]
        public void CanonicalForm()
        {
            // arrange
            var rational = new Rational(2, 4);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.AreEqual(new BigInteger(1), canonical.Numerator);
            Assert.AreEqual(new BigInteger(2), canonical.Denominator);
        }


        [Test]
        public void CanonicalForm_BothNegative()
        {
            // arrange
            var rational = new Rational(-2, -4);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.AreEqual(new BigInteger(1), canonical.Numerator);
            Assert.AreEqual(new BigInteger(2), canonical.Denominator);
        }

        [Test]
        public void CanonicalForm_Irreducible()
        {
            // arrange
            var rational = new Rational(4, 3);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.AreEqual(new BigInteger(4), canonical.Numerator);
            Assert.AreEqual(new BigInteger(3), canonical.Denominator);
        }

        [Test]
        public void CanonicalForm_NegativeDenominator()
        {
            // arrange
            var rational = new Rational(2, -4);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.AreEqual(new BigInteger(-1), canonical.Numerator);
            Assert.AreEqual(new BigInteger(2), canonical.Denominator);
        }

        [Test]
        public void CanonicalForm_NegativeNumerator()
        {
            // arrange
            var rational = new Rational(-2, 4);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.AreEqual(new BigInteger(-1), canonical.Numerator);
            Assert.AreEqual(new BigInteger(2), canonical.Denominator);
        }

        [Test]
        public void CanonicalForm_ZeroNumerator()
        {
            // arrange
            var rational = new Rational(0, -4);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.AreEqual(new BigInteger(0), canonical.Numerator);
            Assert.AreEqual(new BigInteger(1), canonical.Denominator);
        }
    }
}