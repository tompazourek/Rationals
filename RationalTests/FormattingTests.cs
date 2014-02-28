using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rationals;

namespace RationalTests
{
    [TestFixture]
    public class FormattingTests
    {
        [Test]
        public void Format()
        {
            // arrange
            var rational = new Rational(new BigInteger(3), new BigInteger(4));

            // action
            string formatted = rational.ToString();

            // assert
            Assert.AreEqual("3/4", formatted);
        }

        [Test]
        public void Format_C()
        {
            // arrange
            var rational = new Rational(new BigInteger(14), new BigInteger(7));

            // action
            string formatted = rational.ToString("C", CultureInfo.CurrentCulture);

            // assert
            Assert.AreEqual("2", formatted);
        }

        [Test]
        public void Format_W()
        {
            // arrange
            var rational = new Rational(new BigInteger(15), new BigInteger(7));

            // action
            string formatted = rational.ToString("W", CultureInfo.CurrentCulture);

            // assert
            Assert.AreEqual("2 + 1/7", formatted);
        }
    }
}