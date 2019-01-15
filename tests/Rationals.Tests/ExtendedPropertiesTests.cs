using System.Linq;
using Xunit;

namespace Rationals.Tests
{
    public class ExtendedPropertiesTests
    {
        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(2, 1, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(10, 1, 1)]
        [InlineData(100, 1, 2)]
        [InlineData(1000, 1, 3)]
        [InlineData(11, 1, 1)]
        [InlineData(11, 2, 0)]
        [InlineData(1, 2, -1)]
        [InlineData(1, 10, -1)]
        [InlineData(1, 11, -2)]
        [InlineData(2654111, 1, 6)]
        [InlineData(1, 2654111, -7)]
        public void Magnitude(int numerator, int denominator, int expectedMagnitude)
        {
            // arrange
            var rational = new Rational(numerator, denominator);

            // action
            var magnitude = rational.Magnitude;

            // assert
            Assert.Equal(expectedMagnitude, magnitude);
        }

        [Fact]
        public void IsZero1()
        {
            // arrange
            var p = new Rational(1, 4);

            // assert
            Assert.False(p.IsZero);
        }
        
        [Fact]
        public void IsZero2()
        {
            // arrange
            var p = new Rational(0, 4);

            // assert
            Assert.True(p.IsZero);
        }
        
        [Fact]
        public void IsOne1()
        {
            // arrange
            var p = new Rational(1, 4);

            // assert
            Assert.False(p.IsOne);
        }
        
        [Fact]
        public void IsOne2()
        {
            // arrange
            var p = new Rational(0, 4);

            // assert
            Assert.False(p.IsOne);
        }
        
        [Fact]
        public void IsOne3()
        {
            // arrange
            var p = new Rational(4, 4);

            // assert
            Assert.True(p.IsOne);
        }
        
        [Fact]
        public void IsOne4()
        {
            // arrange
            var p = new Rational(5, 4);

            // assert
            Assert.False(p.IsOne);
        }

        [Fact]
        public void PowersOfTwo()
        {
            // arrange
            var rationals = new[]
                { 1, 0, -1, (Rational)5 / 4, 2, -2, 4, 8, 16, (Rational)1 / 2, (Rational)4 / 16, 64, (Rational)1024 / 3 };

            // action
            var powers = rationals.Where(x => x.IsPowerOfTwo).ToList();

            // assert
            var expected = new[] { 1, 2, 4, 8, 16, (Rational)1 / 2, (Rational)4 / 16, 64 };
            Assert.Equal(expected, powers);
        }

        [Fact]
        public void Sign1()
        {
            // arrange
            var p = new Rational(1, 4);

            // assert
            Assert.Equal(1, p.Sign);
        }

        [Fact]
        public void Sign2()
        {
            // arrange
            var p = new Rational(-1, 4);

            // assert
            Assert.Equal(-1, p.Sign);
        }

        [Fact]
        public void Sign3()
        {
            // arrange
            var p = new Rational(1, -4);

            // assert
            Assert.Equal(-1, p.Sign);
        }

        [Fact]
        public void Sign4()
        {
            // arrange
            var p = new Rational(-1, -4);

            // assert
            Assert.Equal(1, p.Sign);
        }

        [Fact]
        public void Sign5()
        {
            // arrange
            var p = new Rational(0, -4);

            // assert
            Assert.Equal(0, p.Sign);
        }

        [Fact]
        public void Sign6()
        {
            // arrange
            var p = new Rational(0, 1);

            // assert
            Assert.Equal(0, p.Sign);
        }
    }
}