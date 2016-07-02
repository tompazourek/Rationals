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
    public class ContinuedFractionsTests
    {
        [Test]
        public void FromContinuedFraction()
        {
            // arrange
            var continuedFraction = new BigInteger[] { 2, 1, 1, 8 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.AreEqual((Rational) 43 / 17, rational);
        }

        [Test]
        public void FromContinuedFraction_Big1()
        {
            // arrange
            var continuedFraction = new BigInteger[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.AreEqual((Rational) 7489051 / 5225670, rational);
        }

        [Test]
        public void FromContinuedFraction_Big2()
        {
            // arrange
            var continuedFraction = new BigInteger[] { 10, 9, 8, 7, 6, 5, 4, 3, 3 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.AreEqual((Rational) 7489051 / 740785, rational);
        }

        [Test]
        public void FromContinuedFraction_Empty()
        {
            // arrange
            var continuedFraction = new BigInteger[] { };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.AreEqual(Rational.Zero, rational);
        }

        [Test]
        public void FromContinuedFraction_LessThanOne()
        {
            // arrange
            var continuedFraction = new BigInteger[] { 0, 3 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.AreEqual((Rational) 1 / 3, rational);
        }

        [Test]
        public void FromContinuedFraction_Negative1()
        {
            // arrange
            var continuedFraction = new BigInteger[] { -45, 5, 24 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.AreEqual((Rational) (-5421) / 121, rational);
        }

        [Test]
        public void FromContinuedFraction_Negative2()
        {
            // arrange
            var continuedFraction = new BigInteger[] { -1, 1, 17, 13, 2, 1, 1, 4, 2 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.AreEqual((Rational) 683 / -12345, rational);
        }

        [Test]
        public void FromContinuedFraction_One()
        {
            // arrange
            var continuedFraction = new BigInteger[] { 1 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.AreEqual(Rational.One, rational);
        }

        [Test]
        public void FromContinuedFraction_Zero()
        {
            // arrange
            var continuedFraction = new BigInteger[] { 0 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.AreEqual(Rational.Zero, rational);
        }

        [Test]
        public void ToContinuedFraction()
        {
            // arrange
            var rational = (Rational) 43 / 17;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            CollectionAssert.AreEquivalent(new BigInteger[] { 2, 1, 1, 8 }, continuedFraction);
        }

        [Test]
        public void ToContinuedFraction_Big1()
        {
            // arrange
            var rational = (Rational) 7489051 / 5225670;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            CollectionAssert.AreEquivalent(new BigInteger[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, continuedFraction);
        }

        [Test]
        public void ToContinuedFraction_Big2()
        {
            // arrange
            var rational = (Rational) 7489051 / 740785;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            CollectionAssert.AreEquivalent(new BigInteger[] { 10, 9, 8, 7, 6, 5, 4, 3, 3 }, continuedFraction);
        }

        [Test]
        public void ToContinuedFraction_LessThanOne()
        {
            // arrange
            var rational = (Rational) 1 / 3;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            CollectionAssert.AreEquivalent(new BigInteger[] { 0, 3 }, continuedFraction);
        }

        [Test]
        public void ToContinuedFraction_Negative1()
        {
            // arrange
            var rational = (Rational) (-5421) / 121;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            CollectionAssert.AreEquivalent(new BigInteger[] { -45, 5, 24 }, continuedFraction);
        }

        [Test]
        public void ToContinuedFraction_Negative2()
        {
            // arrange
            var rational = (Rational) 683 / -12345;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            CollectionAssert.AreEquivalent(new BigInteger[] { -1, 1, 17, 13, 2, 1, 1, 4, 2 }, continuedFraction);
        }

        [Test]
        public void ToContinuedFraction_One()
        {
            // arrange
            var rational = Rational.One;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            CollectionAssert.AreEquivalent(new BigInteger[] { 1 }, continuedFraction);
        }

        [Test]
        public void ToContinuedFraction_Zero()
        {
            // arrange
            var rational = Rational.Zero;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            CollectionAssert.AreEquivalent(new BigInteger[] { 0 }, continuedFraction);
        }
    }
}