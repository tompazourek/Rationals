using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rationals;
using System.Numerics;

namespace RationalTests
{
    [TestFixture]
    public class OperationsTests
    {
        [Test]
        public void Addition1()
        {
            // arrange
            var left = new Rational(1, 2);
            var right = new Rational(1, 4);

            // action
            var sum = left + right;

            // assert
            Assert.AreEqual(new BigInteger(3), sum.Numerator);
            Assert.AreEqual(new BigInteger(4), sum.Denominator);
        }

        [Test]
        public void Addition2()
        {
            // arrange
            var left = new Rational(1, 2);
            var right = new Rational(0, 4);

            // action
            var sum = left + right;

            // assert
            Assert.AreEqual(new BigInteger(1), sum.Numerator);
            Assert.AreEqual(new BigInteger(2), sum.Denominator);
        }

        [Test]
        public void Addition3()
        {
            // arrange
            var left = new Rational(32, 16);
            var right = new Rational(4, 8);

            // action
            var sum = left + right;

            // assert
            Assert.AreEqual(new BigInteger(5), sum.Numerator);
            Assert.AreEqual(new BigInteger(2), sum.Denominator);
        }

        [Test]
        public void Addition4()
        {
            // arrange
            var left = new Rational(32, 16);
            var right = new Rational(-4, 8);

            // action
            var sum = left + right;

            // assert
            Assert.AreEqual(new BigInteger(3), sum.Numerator);
            Assert.AreEqual(new BigInteger(2), sum.Denominator);
        }

        [Test]
        public void Negation1()
        {
            // arrange
            var p = new Rational(1, 2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual(new BigInteger(-1), q.Numerator);
            Assert.AreEqual(new BigInteger(2), q.Denominator);
        }

        [Test]
        public void Negation2()
        {
            // arrange
            var p = new Rational(-1, 2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual(new BigInteger(1), q.Numerator);
            Assert.AreEqual(new BigInteger(2), q.Denominator);
        }

        [Test]
        public void Negation3()
        {
            // arrange
            var p = new Rational(1, -2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual(new BigInteger(1), q.Numerator);
            Assert.AreEqual(new BigInteger(2), q.Denominator);
        }

        [Test]
        public void Negation4()
        {
            // arrange
            var p = new Rational(-1, -2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual(new BigInteger(-1), q.Numerator);
            Assert.AreEqual(new BigInteger(2), q.Denominator);
        }

        [Test]
        public void Negation5()
        {
            // arrange
            var p = new Rational(0, 10);

            // action
            var q = -p;

            // assert
            Assert.AreEqual(p, q);
        }
    }
}