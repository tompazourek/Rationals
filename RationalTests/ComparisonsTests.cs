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
    public class ComparisonsTests
    {
        [Test]
        public void Equality1()
        {
            // arrange
            var p = new Rational(1, 2);
            var q = new Rational(1, 2);

            // assert
            Assert.IsTrue(p == q);
        }

        [Test]
        public void Equality2()
        {
            // arrange
            var p = new Rational(1, 2);
            var q = new Rational(-1, 2);

            // assert
            Assert.IsFalse(p == q);
        }

        [Test]
        public void Equality3()
        {
            // arrange
            var p = new Rational(1, 2);
            var q = new Rational(2, 4);

            // assert
            Assert.IsTrue(p == q);
        }

        [Test]
        public void Equality4()
        {
            // arrange
            var p = new Rational(0, 1);
            var q = new Rational(0, 5);

            // assert
            Assert.IsTrue(p == q);
        }

        [Test]
        public void Equality5()
        {
            // arrange
            var p = new Rational(2, 3);
            var q = new Rational(2, 4);

            // assert
            Assert.IsFalse(p == q);
        }

        [Test]
        public void Equality6()
        {
            // arrange
            var p = new Rational(4, 2);
            var q = 2;

            // assert
            Assert.IsTrue(p == q);
        }
    }
}