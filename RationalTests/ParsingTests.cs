using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using NUnit.Framework;
using Rationals;

namespace RationalTests
{
    [TestFixture]
    public class ParsingTests
    {
        [TestCase(@"3/4", true, 3, 4)]
        [TestCase(@"3\4", false, 0, 0)]
        [TestCase(@"3|4", false, 0, 0)]
        [TestCase(@"-25/-2310832109823", true, -25, -2310832109823)]
        [TestCase(@"  Hello, I am dog!  ", false, 0, 0)]
        [TestCase(@"", false, 0, 0)]
        [TestCase(@"0", true, 0, 1)]
        [TestCase(@"0/0", false, 0, 0)]
        [TestCase(@" 12/12 ", true, 12, 12)]
        [TestCase(@"12+1/5", true, 61, 5)]
        [TestCase(@"12 - 1/5", false, 0, 0)]
        [TestCase(@"132", true, 132, 1)]
        [TestCase(@"-1", true, -1, 1)]
        [TestCase(@"-4/6", true, -4, 6)]
        [TestCase(@"-1 + 2/3", true, -1, 3)]
        public void Parse(string input, bool expectedSuccess, long numerator, long denominator)
        {
            // arrange
            bool success = false;
            Rational expectedResult = expectedSuccess ? (Rational) numerator / denominator : default(Rational);
            Rational result;

            // action
            success = Rational.TryParse(input, out result);

            // assert
            Assert.AreEqual(expectedSuccess, success);
            Assert.AreEqual(expectedResult, result);
        }

    }
}