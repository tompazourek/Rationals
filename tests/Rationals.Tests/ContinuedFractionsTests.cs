using System.Linq;
using System.Numerics;
using Xunit;

namespace Rationals.Tests
{
    public class ContinuedFractionsTests
    {
        [Fact]
        public void FromContinuedFraction()
        {
            // arrange
            var continuedFraction = new BigInteger[] { 2, 1, 1, 8 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.Equal((Rational)43 / 17, rational);
        }

        [Fact]
        public void FromContinuedFraction_Big1()
        {
            // arrange
            var continuedFraction = new BigInteger[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.Equal((Rational)7489051 / 5225670, rational);
        }

        [Fact]
        public void FromContinuedFraction_Big2()
        {
            // arrange
            var continuedFraction = new BigInteger[] { 10, 9, 8, 7, 6, 5, 4, 3, 3 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.Equal((Rational)7489051 / 740785, rational);
        }

        [Fact]
        public void FromContinuedFraction_Empty()
        {
            // arrange
            var continuedFraction = new BigInteger[] { };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.Equal(Rational.Zero, rational);
        }

        [Fact]
        public void FromContinuedFraction_LessThanOne()
        {
            // arrange
            var continuedFraction = new BigInteger[] { 0, 3 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.Equal((Rational)1 / 3, rational);
        }

        [Fact]
        public void FromContinuedFraction_Negative1()
        {
            // arrange
            var continuedFraction = new BigInteger[] { -45, 5, 24 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.Equal((Rational)(-5421) / 121, rational);
        }

        [Fact]
        public void FromContinuedFraction_Negative2()
        {
            // arrange
            var continuedFraction = new BigInteger[] { -1, 1, 17, 13, 2, 1, 1, 4, 2 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.Equal((Rational)683 / -12345, rational);
        }

        [Fact]
        public void FromContinuedFraction_One()
        {
            // arrange
            var continuedFraction = new BigInteger[] { 1 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.Equal(Rational.One, rational);
        }

        [Fact]
        public void FromContinuedFraction_Zero()
        {
            // arrange
            var continuedFraction = new BigInteger[] { 0 };

            // action
            var rational = Rational.FromContinuedFraction(continuedFraction);

            // assert
            Assert.Equal(Rational.Zero, rational);
        }

        [Fact]
        public void ToContinuedFraction()
        {
            // arrange
            var rational = (Rational)43 / 17;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            Assert.Equal(new BigInteger[] { 2, 1, 1, 8 }.OrderBy(x => x), continuedFraction.OrderBy(x => x));
        }

        [Fact]
        public void ToContinuedFraction_Big1()
        {
            // arrange
            var rational = (Rational)7489051 / 5225670;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            Assert.Equal(new BigInteger[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.OrderBy(x => x), continuedFraction.OrderBy(x => x));
        }

        [Fact]
        public void ToContinuedFraction_Big2()
        {
            // arrange
            var rational = (Rational)7489051 / 740785;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            Assert.Equal(new BigInteger[] { 10, 9, 8, 7, 6, 5, 4, 3, 3 }.OrderBy(x => x), continuedFraction.OrderBy(x => x));
        }

        [Fact]
        public void ToContinuedFraction_LessThanOne()
        {
            // arrange
            var rational = (Rational)1 / 3;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            Assert.Equal(new BigInteger[] { 0, 3 }.OrderBy(x => x), continuedFraction.OrderBy(x => x));
        }

        [Fact]
        public void ToContinuedFraction_Negative1()
        {
            // arrange
            var rational = (Rational)(-5421) / 121;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            Assert.Equal(new BigInteger[] { -45, 5, 24 }.OrderBy(x => x), continuedFraction.OrderBy(x => x));
        }

        [Fact]
        public void ToContinuedFraction_Negative2()
        {
            // arrange
            var rational = (Rational)683 / -12345;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            Assert.Equal(new BigInteger[] { -1, 1, 17, 13, 2, 1, 1, 4, 2 }.OrderBy(x => x), continuedFraction.OrderBy(x => x));
        }

        [Fact]
        public void ToContinuedFraction_One()
        {
            // arrange
            var rational = Rational.One;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            Assert.Equal(new BigInteger[] { 1 }.OrderBy(x => x), continuedFraction.OrderBy(x => x));
        }

        [Fact]
        public void ToContinuedFraction_Zero()
        {
            // arrange
            var rational = Rational.Zero;

            // action
            var continuedFraction = rational.ToContinuedFraction();

            // assert
            Assert.Equal(new BigInteger[] { 0 }, continuedFraction);
        }
    }
}