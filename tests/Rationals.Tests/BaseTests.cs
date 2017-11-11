using System;
using System.Numerics;
using Xunit;

namespace Rationals.Tests
{
    public class BaseTests
    {
        [Fact]
        [Trait("Category", "BaseTests")]
        public void Constructor()
        {
            // arrange
            var rational = new Rational(new BigInteger(1), new BigInteger(2));

            // action
            var numerator = rational.Numerator;
            var denominator = rational.Denominator;

            // assert
            Assert.Equal(new BigInteger(1), numerator);
            Assert.Equal(new BigInteger(2), denominator);
        }

        [Fact]
        [Trait("Category", "BaseTests")]
        public void Constructor_DenominatorZero()
        {
            Assert.Throws<DivideByZeroException>(() => new Rational(new BigInteger(1), new BigInteger(0)));
        }

        [Fact]
        [Trait("Category", "BaseTests")]
        public void Constructor_Whole()
        {
            // arrange
            var rational = new Rational(3);

            // action
            var numerator = rational.Numerator;
            var denominator = rational.Denominator;

            // assert
            Assert.Equal(new BigInteger(3), numerator);
            Assert.Equal(new BigInteger(1), denominator);
        }

        [Fact]
        [Trait("Category", "BaseTests")]
        public void Constructor_WholeZero()
        {
            // arrange
            var rational = new Rational(0);

            // action
            var numerator = rational.Numerator;
            var denominator = rational.Denominator;

            // assert
            Assert.Equal(new BigInteger(0), numerator);
            Assert.Equal(new BigInteger(1), denominator);
        }
    }
}