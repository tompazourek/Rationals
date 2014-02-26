using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
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
            Assert.Catch(() => new Rational(new BigInteger(1), new BigInteger(0)));
        }
    }
}