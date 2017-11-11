using System.Globalization;
using Xunit;

namespace Rationals.Tests
{
    [Trait("Category", "Parsing")]
    public class ParsingTests
    {
        [Theory]
        [InlineData(@"3/4", true, 3, 4)]
        [InlineData(@"3\4", false, 0, 0)]
        [InlineData(@"3|4", false, 0, 0)]
        [InlineData(@"-25/-2310832109823", true, -25, -2310832109823)]
        [InlineData(@"  Hello, I am dog!  ", false, 0, 0)]
        [InlineData(@"", false, 0, 0)]
        [InlineData(@"0", true, 0, 1)]
        [InlineData(@"0/0", false, 0, 0)]
        [InlineData(@" 12/12 ", true, 12, 12)]
        [InlineData(@"12+1/5", true, 61, 5)]
        [InlineData(@"12 - 1/5", false, 0, 0)]
        [InlineData(@"132", true, 132, 1)]
        [InlineData(@"-1", true, -1, 1)]
        [InlineData(@"-4/6", true, -4, 6)]
        [InlineData(@"-1 + 2/3", true, -1, 3)]
        public void Parse(string input, bool expectedSuccess, long numerator, long denominator)
        {
            // arrange
            var expectedResult = expectedSuccess ? (Rational)numerator / denominator : default(Rational);

            // action
            var success = Rational.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out var result);

            // assert
            Assert.Equal(expectedSuccess, success);
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(@"0.75", 0, true, 3, 4)]
        [InlineData(@"0A75", 0, false, 0, 0)]
        [InlineData(@"1.33333333333", 0.0000001, true, 4, 3)]
        [InlineData(@"1.33", 0, true, 133, 100)]
        [InlineData(@"  Hello, I am dog!  ", 0, false, 0, 0)]
        [InlineData(@"", 0, false, 0, 0)]
        [InlineData(@"-1", 0, true, -1, 1)]
        public void ParseDecimal(string input, double tolerance, bool expectedSuccess, long numerator, long denominator)
        {
            // arrange
            var expectedResult = expectedSuccess ? (Rational)numerator / denominator : default(Rational);

            // action
            var success = Rational.TryParseDecimal(input, NumberStyles.Float, CultureInfo.InvariantCulture, out var result, (decimal)tolerance);

            // assert
            Assert.Equal(expectedSuccess, success);
            Assert.Equal(expectedResult, result);
        }
    }
}