using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rationals;

namespace RationalTests
{
    [TestFixture]
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
            Assert.AreEqual(new Rational(1, 2), canonical);
        }

        [Test]
        public void CanonicalForm_Irreducible()
        {
            // arrange
            var rational = new Rational(4, 3);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.AreEqual(rational, canonical);
        }

        [Test]
        public void CanonicalForm_NegativeNumerator()
        {
            // arrange
            var rational = new Rational(-2, 4);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.AreEqual(new Rational(-1, 2), canonical);
        }


        [Test]
        public void CanonicalForm_BothNegative()
        {
            // arrange
            var rational = new Rational(-2, -4);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.AreEqual(new Rational(1, 2), canonical);
        }

        [Test]
        public void CanonicalForm_NegativeDenominator()
        {
            // arrange
            var rational = new Rational(2, -4);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.AreEqual(new Rational(-1, 2), canonical);
        }

        [Test]
        public void CanonicalForm_ZeroNumerator()
        {
            // arrange
            var rational = new Rational(0, -4);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.AreEqual(new Rational(0, 1), canonical);
        }
    }
}