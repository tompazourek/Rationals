using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rationals;

namespace RationalTests
{
    [TestFixture]
    public class ExtendedPropertiesTests
    {
        [Test]
        public void Sign1()
        {
            // arrange
            var p = new Rational(1, 4);

            // assert
            Assert.AreEqual(1, p.Sign);
        }

        [Test]
        public void Sign2()
        {
            // arrange
            var p = new Rational(-1, 4);

            // assert
            Assert.AreEqual(-1, p.Sign);
        }

        [Test]
        public void Sign3()
        {
            // arrange
            var p = new Rational(1, -4);

            // assert
            Assert.AreEqual(-1, p.Sign);
        }

        [Test]
        public void Sign4()
        {
            // arrange
            var p = new Rational(-1, -4);

            // assert
            Assert.AreEqual(1, p.Sign);
        }

        [Test]
        public void Sign5()
        {
            // arrange
            var p = new Rational(0, -4);

            // assert
            Assert.AreEqual(0, p.Sign);
        }

        [Test]
        public void Sign6()
        {
            // arrange
            var p = new Rational(0, 1);

            // assert
            Assert.AreEqual(0, p.Sign);
        }

        [Test]
        public void PowersOfTwo()
        {
            // arrange
            var rationals = new[] { 1, 0, -1, (Rational) 5 / 4, 2, -2, 4, 8, 16, (Rational) 1 / 2, (Rational) 4 / 16, 64, (Rational) 1024 / 3 };

            // action
            var powers = rationals.Where(x => x.IsPowerOfTwo).ToList();

            // assert
            var expected = new[] { 1, 2, 4, 8, 16, (Rational)1 / 2, (Rational)4 / 16, 64 };
            CollectionAssert.AreEqual(expected, powers);
        }
    }
}
