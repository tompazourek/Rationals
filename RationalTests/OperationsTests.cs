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
            var left = (Rational)1/2;
            var right = (Rational)1/4;

            // action
            var sum = left + right;

            // assert
            Assert.AreEqual((Rational)3/4, sum);
        }

        [Test]
        public void Addition2()
        {
            // arrange
            var left = (Rational)1/2;
            var right = (Rational)0/4;

            // action
            var sum = left + right;

            // assert
            Assert.AreEqual((Rational)1/2, sum);
        }

        [Test]
        public void Addition3()
        {
            // arrange
            var left = (Rational)32/16;
            var right = (Rational)4/8;

            // action
            var sum = left + right;

            // assert
            Assert.AreEqual((Rational)5/2, sum);
        }

        [Test]
        public void Addition4()
        {
            // arrange
            var left = (Rational)32/16;
            var right = -(Rational)4/8;

            // action
            var sum = left + right;

            // assert
            Assert.AreEqual((Rational)3/2, sum);
        }

        [Test]
        public void Negation1()
        {
            // arrange
            var p = new Rational(1, 2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual(-(Rational)1/2, q);
        }

        [Test]
        public void Negation2()
        {
            // arrange
            var p = new Rational(-1, 2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual((Rational)1/2, q);
        }

        [Test]
        public void Negation3()
        {
            // arrange
            var p = new Rational(1, -2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual((Rational)1/2, q);
        }

        [Test]
        public void Negation4()
        {
            // arrange
            var p = new Rational(-1, -2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual(-(Rational)1/2, q);
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