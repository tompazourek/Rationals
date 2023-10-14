using Xunit;

namespace Rationals.Tests
{
    public class WholeAndFractionTests
    {
        [Theory]
        [InlineData(1, 2, 1, 2)]
        [InlineData(-5, 10, 5, 10)]
        [InlineData(-49, 10, 1, 10)]
        [InlineData(0, 5, 0, 1)]
        [InlineData(213, 1, 0, 1)]
        [InlineData(456, 456, 0, 1)]
        [InlineData(45, 9, 0, 1)]
        [InlineData(45, 10, 5, 10)]
        [InlineData(-4, -3, 1, 3)]
        [InlineData(-3, -4, 3, 4)]
        public void FractionPart(int numerator, int denominator, int fractionPartNumerator, int fractionPartDenominator)
        {
            // arrange
            var p = (Rational)numerator / denominator;

            // assert
            Assert.Equal(new Rational(fractionPartNumerator, fractionPartDenominator), p.FractionPart);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(-5, 10)]
        [InlineData(-49, 10)]
        [InlineData(0, 5)]
        [InlineData(213, 1)]
        [InlineData(456, 456)]
        [InlineData(45, 9)]
        [InlineData(45, 10)]
        [InlineData(-4, -3)]
        [InlineData(-3, -4)]
        public void WholeAndFraction_Sum(int numerator, int denominator)
        {
            // arrange
            var p = (Rational)numerator / denominator;

            // action
            var wholePart = p.WholePart;
            var fractionPart = p.FractionPart;

            // assert
            Assert.Equal(p, wholePart + fractionPart);
        }

        [Theory]
        [InlineData(1, 2, 0)]
        [InlineData(-5, 10, -1)]
        [InlineData(-49, 10, -5)]
        [InlineData(0, 5, 0)]
        [InlineData(213, 1, 213)]
        [InlineData(456, 456, 1)]
        [InlineData(45, 9, 5)]
        [InlineData(45, 10, 4)]
        [InlineData(-4, -3, 1)]
        [InlineData(-3, -4, 0)]
        public void WholePart(int numerator, int denominator, int wholePart)
        {
            // arrange
            var p = (Rational)numerator / denominator;

            // assert
            Assert.Equal(wholePart, p.WholePart);
        }
    }
}
