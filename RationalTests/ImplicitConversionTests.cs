using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
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
