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
    public class ImplicitConversionTests
    {
        [Test]
        public void ImplicitConversion()
        {
            // arrange
            const int n = 25;

            // action
            Rational rational = n;

            // assert
            Assert.AreEqual(new BigInteger(25), rational.Numerator);
            Assert.AreEqual(new BigInteger(1), rational.Denominator);
        }

        [Test]
        public void ImplicitConversion_Zero()
        {
            // arrange
            const int n = 0;

            // action
            Rational rational = n;

            // assert
            Assert.AreEqual(Rational.Zero, rational);
        }
    }
}