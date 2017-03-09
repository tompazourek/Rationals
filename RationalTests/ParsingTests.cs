#region License

// Copyright (C) Tomáš Pažourek, 2016
// All rights reserved.
// 
// Distributed under MIT license as a part of project Rationals.
// https://github.com/tompazourek/Rationals

#endregion

using System.Globalization;
using NUnit.Framework;
using Rationals;

namespace RationalTests
{
    [TestFixture(Category = "Parsing")]
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
            var expectedResult = expectedSuccess ? (Rational) numerator / denominator : default(Rational);
            Rational result;

            // action
            var success = Rational.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out result);

            // assert
            Assert.AreEqual(expectedSuccess, success);
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(@"0.75", 0, true, 3, 4)]
        [TestCase(@"0A75", 0, false, 0, 0)]
        [TestCase(@"1.33333333333", 0.0000001, true, 4, 3)]
        [TestCase(@"1.33", 0, true, 133, 100)]
        [TestCase(@"  Hello, I am dog!  ", 0, false, 0, 0)]
        [TestCase(@"", 0, false, 0, 0)]
        [TestCase(@"-1", 0, true, -1, 1)]
        public void ParseDecimal(string input, double tolerance, bool expectedSuccess, long numerator, long denominator)
        {
            // arrange
            var expectedResult = expectedSuccess ? (Rational)numerator / denominator : default(Rational);
            Rational result;

            // action
            var success = Rational.TryParseDecimal(input, NumberStyles.Float, CultureInfo.InvariantCulture, out result, (decimal)tolerance);

            // assert
            Assert.AreEqual(expectedSuccess, success);
            Assert.AreEqual(expectedResult, result);
        }
    }
}