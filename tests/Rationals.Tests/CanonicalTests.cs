using System.Numerics;
using Xunit;

namespace Rationals.Tests
{
    public class CanonicalTests
    {
        [Fact]
        public void CanonicalForm()
        {
            // arrange
            var rational = new Rational(2, 4);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.Equal(new BigInteger(1), canonical.Numerator);
            Assert.Equal(new BigInteger(2), canonical.Denominator);
        }

        [Fact]
        public void CanonicalForm_BothNegative()
        {
            // arrange
            var rational = new Rational(-2, -4);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.Equal(new BigInteger(1), canonical.Numerator);
            Assert.Equal(new BigInteger(2), canonical.Denominator);
        }

        [Fact]
        public void CanonicalForm_Irreducible()
        {
            // arrange
            var rational = new Rational(4, 3);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.Equal(new BigInteger(4), canonical.Numerator);
            Assert.Equal(new BigInteger(3), canonical.Denominator);
        }

        [Fact]
        public void CanonicalForm_NegativeDenominator()
        {
            // arrange
            var rational = new Rational(2, -4);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.Equal(new BigInteger(-1), canonical.Numerator);
            Assert.Equal(new BigInteger(2), canonical.Denominator);
        }

        [Fact]
        public void CanonicalForm_NegativeNumerator()
        {
            // arrange
            var rational = new Rational(-2, 4);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.Equal(new BigInteger(-1), canonical.Numerator);
            Assert.Equal(new BigInteger(2), canonical.Denominator);
        }

        [Fact]
        public void CanonicalForm_ZeroNumerator()
        {
            // arrange
            var rational = new Rational(0, -4);

            // action
            var canonical = rational.CanonicalForm;

            // assert
            Assert.Equal(new BigInteger(0), canonical.Numerator);
            Assert.Equal(new BigInteger(1), canonical.Denominator);
        }
    }
}