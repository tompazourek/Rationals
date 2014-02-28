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
            int q = 2;

            // assert
            Assert.IsTrue(p == q);
        }

        [Test]
        public void Equals1()
        {
            // arrange
            var p = new Rational(4, 2);
            int q = 2;

            // assert
            Assert.IsTrue(p.Equals(q));
        }

        [Test]
        public void Equals2()
        {
            // arrange
            var p = new Rational(4, 2);
            string q = "hello";

            // assert
            Assert.IsFalse(p.Equals(q));
        }

        [Test]
        public void Equals3()
        {
            // arrange
            var p = new Rational(4, 2);
            var q = new Rational(3, 2);

            // assert
            Assert.IsFalse(p.Equals(q));
        }

        [Test]
        public void GetHashCode_Different()
        {
            // arrange
            var p = new Rational(4, 2);
            var q = new Rational(-2, 1);

            // assert
            Assert.AreNotEqual(p.GetHashCode(), q.GetHashCode());
        }

        [Test]
        public void GetHashCode_Same()
        {
            // arrange
            var p = new Rational(4, -2);
            var q = new Rational(-2, 1);

            // assert
            Assert.AreEqual(p.GetHashCode(), q.GetHashCode());
        }
    }
}