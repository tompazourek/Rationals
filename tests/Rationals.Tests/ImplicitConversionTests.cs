using System.Numerics;
using Xunit;

namespace Rationals.Tests
{
    public class ImplicitConversionTests
    {
        [Fact]
        public void ImplicitConversion()
        {
            // arrange
            const int n = 25;

            // action
            Rational rational = n;

            // assert
            Assert.Equal(new BigInteger(25), rational.Numerator);
            Assert.Equal(new BigInteger(1), rational.Denominator);
        }

        [Fact]
        public void ImplicitConversion_Zero()
        {
            // arrange
            const int n = 0;

            // action
            Rational rational = n;

            // assert
            Assert.Equal(Rational.Zero, rational);
        }
    }
}