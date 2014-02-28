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
    public class OperationsTests
    {
        [Test]
        public void Addition1()
        {
            // arrange
            Rational left = (Rational) 1 / 2;
            Rational right = (Rational) 1 / 4;

            // action
            Rational sum = left + right;

            // assert
            Assert.AreEqual((Rational) 3 / 4, sum);
        }

        [Test]
        public void Addition2()
        {
            // arrange
            Rational left = (Rational) 1 / 2;
            Rational right = (Rational) 0 / 4;

            // action
            Rational sum = left + right;

            // assert
            Assert.AreEqual((Rational) 1 / 2, sum);
        }

        [Test]
        public void Addition3()
        {
            // arrange
            Rational left = (Rational) 32 / 16;
            Rational right = (Rational) 4 / 8;

            // action
            Rational sum = left + right;

            // assert
            Assert.AreEqual((Rational) 5 / 2, sum);
        }

        [Test]
        public void Addition4()
        {
            // arrange
            Rational left = (Rational) 32 / 16;
            Rational right = -(Rational) 4 / 8;

            // action
            Rational sum = left + right;

            // assert
            Assert.AreEqual((Rational) 3 / 2, sum);
        }

        [Test]
        public void Negation1()
        {
            // arrange
            var p = new Rational(1, 2);

            // action
            Rational q = -p;

            // assert
            Assert.AreEqual(-(Rational) 1 / 2, q);
        }

        [Test]
        public void Negation2()
        {
            // arrange
            var p = new Rational(-1, 2);

            // action
            Rational q = -p;

            // assert
            Assert.AreEqual((Rational) 1 / 2, q);
        }

        [Test]
        public void Negation3()
        {
            // arrange
            var p = new Rational(1, -2);

            // action
            Rational q = -p;

            // assert
            Assert.AreEqual((Rational) 1 / 2, q);
        }

        [Test]
        public void Negation4()
        {
            // arrange
            var p = new Rational(-1, -2);

            // action
            Rational q = -p;

            // assert
            Assert.AreEqual(-(Rational) 1 / 2, q);
        }

        [Test]
        public void Negation5()
        {
            // arrange
            var p = new Rational(0, 10);

            // action
            Rational q = -p;

            // assert
            Assert.AreEqual(p, q);
        }
    }
}