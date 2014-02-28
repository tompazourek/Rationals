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
    }
}