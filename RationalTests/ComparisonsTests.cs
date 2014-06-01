using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rationals;

namespace RationalTests
{
    [TestFixture]
    public class ComparisonsTests
    {
        [Test]
        public void Comparisons1()
        {
            // arrange
            var a = new Rational(1, 3);
            var b = new Rational(1, 2);
            var c = new Rational(2, 4);

            // assert
            Assert.IsTrue(a < b);
            Assert.IsTrue(a < c);
            Assert.IsFalse(a > b);
            Assert.IsFalse(a > c);

            Assert.IsFalse(b < a);
            Assert.IsFalse(c < a);
            Assert.IsTrue(b > a);
            Assert.IsTrue(c > a);

            Assert.IsTrue(a <= b);
            Assert.IsTrue(a <= c);
            Assert.IsFalse(a >= b);
            Assert.IsFalse(a >= c);

            Assert.IsFalse(b <= a);
            Assert.IsFalse(c <= a);
            Assert.IsTrue(b >= a);
            Assert.IsTrue(c >= a);

            Assert.IsTrue(b <= c);
            Assert.IsTrue(b >= c);
            Assert.IsTrue(c <= b);
            Assert.IsTrue(c >= b);
        }

        [Test]
        public void Comparisons2()
        {
            // arrange
            var a = new Rational(32);
            var b = new Rational(2, -1);

            // assert
            Assert.IsTrue(a > b);
            Assert.IsTrue(a >= b);
            Assert.IsFalse(a < b);
            Assert.IsFalse(a <= b);

            Assert.IsFalse(b > a);
            Assert.IsFalse(b >= a);
            Assert.IsTrue(b < a);
            Assert.IsTrue(b <= a);
        }

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
            const int q = 2;

            // assert
            Assert.IsTrue(p == q);
        }

        [Test]
        public void Equals1()
        {
            // arrange
            var p = new Rational(4, 2);
            const int q = 2;

            // assert
            Assert.IsTrue(p.Equals(q));
        }

        [Test]
        public void Equals2()
        {
            // arrange
            var p = new Rational(4, 2);
            const string q = "hello";

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

        [Test]
        public void Sorting_ListSort()
        {
            // arrange
            var rationals = new List<Rational> { 2, 32, -1, 0, 2, (Rational) 4 / 5, (Rational) 3 / 4, (Rational) 2 / -1, 32 / 2, 64 / 4, (Rational) 2 / 3 };

            // action
            rationals.Sort();

            // assert
            var expected = new[] { -2, -1, 0, (Rational) 2 / 3, (Rational) 3 / 4, (Rational) 4 / 5, 2, 2, 16, 16, 32 };
            CollectionAssert.AreEqual(expected, rationals);
        }

        [Test]
        public void Sorting_OrderBy()
        {
            // arrange
            var rationals = new List<Rational> { (Rational)2 / 3, (Rational)4 / 3, (Rational)0 / 2, (Rational)0 / 3, 1, (Rational)4 / 10, -1, (Rational)2 / -3, -(Rational)4 / 3, (Rational)0 / -2, -(Rational)0 / 3, -(Rational)4 / 10, -1 };

            // action
            var sorted = rationals.OrderBy(x => x).ToList();

            // assert
            var expected = new[] { -(Rational)4 / 3, -1, -1, -(Rational)2 / 3, -(Rational)2 / 5, 0, 0, 0, 0, (Rational)2 / 5, (Rational)2 / 3, 1, (Rational)4 / 3 };
            CollectionAssert.AreEqual(expected, sorted);
        }
    }
}