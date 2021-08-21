using System;
using Xunit;

namespace Rationals.Tests
{
    public class OperationsTests
    {
        [Fact]
        public void Addition1()
        {
            // arrange
            var left = (Rational)1 / 2;
            var right = (Rational)1 / 4;

            // action
            var sum = left + right;

            // assert
            Assert.Equal((Rational)3 / 4, sum);
        }

        [Fact]
        public void Addition2()
        {
            // arrange
            var left = (Rational)1 / 2;
            var right = (Rational)0 / 4;

            // action
            var sum = left + right;

            // assert
            Assert.Equal((Rational)1 / 2, sum);
        }

        [Fact]
        public void Addition3()
        {
            // arrange
            var left = (Rational)32 / 16;
            var right = (Rational)4 / 8;

            // action
            var sum = left + right;

            // assert
            Assert.Equal((Rational)5 / 2, sum);
        }

        [Fact]
        public void Addition4()
        {
            // arrange
            var left = (Rational)32 / 16;
            var right = -(Rational)4 / 8;

            // action
            var sum = left + right;

            // assert
            Assert.Equal((Rational)3 / 2, sum);
        }

        [Fact]
        public void AdditionNaN()
        {
            // arrange
            var left = (Rational)32 / 16;
            var right = Rational.NaN;

            // action
            var sum = left + right;

            // assert
            Assert.Equal(Rational.NaN, sum);
        }

        [Fact]
        public void Division1()
        {
            // arrange
            var left = (Rational)3 / 4;
            var right = (Rational)1 / 3;

            // action
            var result = left / right;

            // assert
            Assert.Equal((Rational)9 / 4, result);
        }

        [Fact]
        public void Division2()
        {
            // arrange
            var left = (Rational)3 / 4;
            var right = (Rational)0 / 3;

            // action
            // ReSharper disable NotAccessedVariable
            Rational result;

            Assert.Throws<DivideByZeroException>(() => result = left / right);
            // ReSharper restore NotAccessedVariable
        }

        [Fact]
        public void Division3()
        {
            // arrange
            var left = (Rational)0 / 4;
            var right = (Rational)1 / 3;

            // action
            var result = left / right;

            // assert
            Assert.Equal(Rational.Zero, result);
        }

        [Fact]
        public void Division4()
        {
            // arrange
            var left = -(Rational)15 / 4;
            var right = (Rational)1 / 15;

            // action
            var result = left / right;

            // assert
            Assert.Equal(-(Rational)225 / 4, result);
        }

        [Fact]
        public void DivisionNaN()
        {
            // arrange
            var left = -(Rational)15 / 4;
            var right = Rational.NaN;

            // action
            var result = left / right;

            // assert
            Assert.Equal(Rational.NaN, result);
        }

        [Fact]
        public void Exponentiation1()
        {
            // arrange
            var value = (Rational)5 / 4;
            const int exponent = 2;

            // action
            var result = Rational.Pow(value, exponent);

            // assert
            Assert.Equal((Rational)25 / 16, result);
        }

        [Fact]
        public void Exponentiation2()
        {
            // arrange
            var value = (Rational)5 / 4;
            const int exponent = -2;

            // action
            var result = Rational.Pow(value, exponent);

            // assert
            Assert.Equal((Rational)16 / 25, result);
        }

        [Fact]
        public void Exponentiation3()
        {
            // arrange
            var value = (Rational)5 / -4;
            const int exponent = 1;

            // action
            var result = Rational.Pow(value, exponent);

            // assert
            Assert.Equal((Rational)5 / -4, result);
        }

        [Fact]
        public void Exponentiation4()
        {
            // arrange
            var value = Rational.Zero;
            const int exponent = 0;

            // action
            var result = Rational.Pow(value, exponent);

            // assert
            Assert.Equal(Rational.One, result);
        }

        [Fact]
        public void Exponentiation5()
        {
            // arrange
            var value = -(Rational)10 / 2;
            const int exponent = 2;

            // action
            var result = Rational.Pow(value, exponent);

            // assert
            Assert.Equal((Rational)100 / 4, result);
        }

        [Fact]
        public void ExponentiationNaN()
        {
            // arrange
            var value = Rational.NaN;
            const int exponent = 2;

            // action
            var result = Rational.Pow(value, exponent);

            // assert
            Assert.Equal(Rational.NaN, result);
        }

        [Fact]
        public void Inversion1()
        {
            // arrange
            var p = (Rational)1 / 2;

            // action
            var inverted = Rational.Invert(p);

            // assert
            Assert.Equal((Rational)2 / 1, inverted);
        }

        [Fact]
        public void Inversion2()
        {
            // arrange
            var p = (Rational)5 / -3;

            // action
            var inverted = Rational.Invert(p);

            // assert
            Assert.Equal(-(Rational)3 / 5, inverted);
        }

        [Fact]
        public void Inversion3()
        {
            // arrange
            var p = (Rational)0 / 1;

            // action
            Assert.Throws<DivideByZeroException>(() => Rational.Invert(p));
        }

        [Fact]
        public void InversionNaN()
        {
            // arrange
            var p = Rational.NaN;

            // action
            var inverted = Rational.Invert(p);

            // assert
            Assert.Equal(Rational.NaN, inverted);
        }

        [Fact]
        public void Multiplication1()
        {
            // arrange
            var left = (Rational)3 / 4;
            var right = (Rational)1 / 3;

            // action
            var product = left * right;

            // assert
            Assert.Equal((Rational)3 / 12, product);
        }

        [Fact]
        public void Multiplication2()
        {
            // arrange
            var left = (Rational)0 / 4;
            var right = (Rational)1 / 3;

            // action
            var product = left * right;

            // assert
            Assert.Equal(Rational.Zero, product);
        }

        [Fact]
        public void Multiplication3()
        {
            // arrange
            var left = (Rational)7 / 4;
            var right = (Rational)0 / 3;

            // action
            var product = left * right;

            // assert
            Assert.Equal(Rational.Zero, product);
        }

        [Fact]
        public void Multiplication4()
        {
            // arrange
            var left = (Rational)3 / 4;
            var right = (Rational)1 / -3;

            // action
            var product = left * right;

            // assert
            Assert.Equal(-(Rational)3 / 12, product);
        }

        [Fact]
        public void MultiplicationNaN()
        {
            // arrange
            var left = (Rational)3 / 4;
            var right = Rational.NaN;

            // action
            var product = left * right;

            // assert
            Assert.Equal(Rational.NaN, product);
        }

        [Fact]
        public void Negation1()
        {
            // arrange
            var p = new Rational(1, 2);

            // action
            var q = -p;

            // assert
            Assert.Equal(-(Rational)1 / 2, q);
        }

        [Fact]
        public void Negation2()
        {
            // arrange
            var p = new Rational(-1, 2);

            // action
            var q = -p;

            // assert
            Assert.Equal((Rational)1 / 2, q);
        }

        [Fact]
        public void Negation3()
        {
            // arrange
            var p = new Rational(1, -2);

            // action
            var q = -p;

            // assert
            Assert.Equal((Rational)1 / 2, q);
        }

        [Fact]
        public void Negation4()
        {
            // arrange
            var p = new Rational(-1, -2);

            // action
            var q = -p;

            // assert
            Assert.Equal(-(Rational)1 / 2, q);
        }

        [Fact]
        public void Negation5()
        {
            // arrange
            var p = new Rational(0, 10);

            // action
            var q = -p;

            // assert
            Assert.Equal(p, q);
        }
        
        [Fact]
        public void NegationNaN()
        {
            // arrange
            var p = Rational.NaN;

            // action
            var q = -p;

            // assert
            Assert.Equal(Rational.NaN, q);
        }

        [Fact]
        public void Subtraction1()
        {
            // arrange
            var left = (Rational)3 / 4;
            var right = (Rational)1 / 3;

            // action
            var result = left - right;

            // assert
            Assert.Equal((Rational)5 / 12, result);
        }

        [Fact]
        public void Subtraction2()
        {
            // arrange
            var left = (Rational)3 / 4;
            var right = (Rational)4 / 3;

            // action
            var result = left - right;

            // assert
            Assert.Equal(-(Rational)7 / 12, result);
        }

        [Fact]
        public void Subtraction3()
        {
            // arrange
            var left = (Rational)0 / 4;
            var right = (Rational)4 / 3;

            // action
            var result = left - right;

            // assert
            Assert.Equal(-(Rational)4 / 3, result);
        }

        [Fact]
        public void Subtraction4()
        {
            // arrange
            var left = (Rational)5 / 4;
            var right = (Rational)0 / 3;

            // action
            var result = left - right;

            // assert
            Assert.Equal((Rational)5 / 4, result);
        }

        [Fact]
        public void Subtraction5()
        {
            // arrange
            var p = (Rational)5 / 4;

            // action
            var result = p - p;

            // assert
            Assert.Equal(Rational.Zero, result);
        }

        [Fact]
        public void SubtractionNaN()
        {
            // arrange
            var left = (Rational)5 / 4;
            var right = Rational.NaN;

            // action
            var result = left - right;

            // assert
            Assert.Equal(Rational.NaN, result);
        }

        [Fact]
        public void Absolute1()
        {
            // arrange
            var p = new Rational(1, 2);

            // action
            var q = -p;

            // assert
            Assert.Equal((Rational)1 / 2, Rational.Abs(q));
        }

        [Fact]
        public void Absolute2()
        {
            // arrange
            var p = new Rational(-1, 2);

            // action
            var q = -p;

            // assert
            Assert.Equal((Rational)1 / 2, Rational.Abs(q));
        }

        [Fact]
        public void Absolute3()
        {
            // arrange
            var p = new Rational(1, -2);

            // action
            var q = -p;

            // assert
            Assert.Equal((Rational)1 / 2, Rational.Abs(q));
        }

        [Fact]
        public void Absolute4()
        {
            // arrange
            var p = new Rational(-1, -2);

            // action
            var q = -p;

            // assert
            Assert.Equal((Rational)1 / 2, Rational.Abs(q));
        }

        [Fact]
        public void Absolute5()
        {
            // arrange
            var p = new Rational(0, 10);

            // action
            var q = -p;

            // assert
            Assert.Equal(p, Rational.Abs(q));
        }
        
        [Fact]
        public void AbsoluteNaN()
        {
            // arrange
            var input = Rational.NaN;

            // action
            var result = Rational.Abs(input);

            // assert
            Assert.Equal(Rational.NaN, result);
        }

        [Fact]
        public void Base10Logarithm1()
        {
            // arrange
            var value = (Rational)(5.0 / 4.0);

            // action
            var result = Rational.Log10(value);

            // assert
            Assert.Equal(33439844.0 / 345060773.0, result, 7);
        }

        [Fact]
        public void Base10Logarithm2()
        {
            // arrange
            var value = (Rational)(12.0 / 4.0);

            // action
            var result = Rational.Log10(value);

            // assert
            Assert.Equal(53565241.0 / 112267564.0, result, 7);
        }

        [Fact]
        public void Base10Logarithm3()
        {
            // arrange
            var value = (Rational)(10.0 / 4.0);

            // action
            var result = Rational.Log10(value);

            // assert
            Assert.Equal(29241489.0 / 73482154.0, result, 7);
        }

        [Fact]
        public void Base10Logarithm4()
        {
            // arrange
            var value = Rational.Zero;

            // action
            var result = Rational.Log10(value);

            // assert
            Assert.True(double.IsNaN(result));
        }

        [Fact]
        public void Base10Logarithm5()
        {
            // arrange
            var value = (Rational)25 / -2;

            // action
            var result = Rational.Log10(value);

            // assert
            Assert.True(double.IsNaN(result));
        }
        
        [Fact]
        public void Base10LogarithmNaN()
        {
            // arrange
            var value = Rational.NaN;

            // action
            var result = Rational.Log10(value);

            // assert
            Assert.True(double.IsNaN(result));
        }

        [Fact]
        public void NaturalLogarithm1()
        {
            // arrange
            var value = (Rational)(5.0 / 4.0);

            // action
            var result = Rational.Log(value);

            // assert
            Assert.Equal(231848159.0 / 1039009004.0, result, 7);
        }

        [Fact]
        public void NaturalLogarithm2()
        {
            // arrange
            var value = (Rational)(12.0 / 4.0);

            // action
            var result = Rational.Log(value);

            // assert
            Assert.Equal(210545501.0 / 191646774.0, result, 7);
        }

        [Fact]
        public void NaturalLogarithm3()
        {
            // arrange
            var value = (Rational)(10.0 / 4.0);

            // action
            var result = Rational.Log(value);

            // assert
            Assert.Equal(96543057.0 / 105362909.0, result, 7);
        }

        [Fact]
        public void NaturalLogarithm4()
        {
            // arrange
            var value = Rational.Zero;

            // action
            var result = Rational.Log(value);

            // assert
            Assert.True(double.IsNaN(result));
        }

        [Fact]
        public void NaturalLogarithm5()
        {
            // arrange
            var value = (Rational)25 / -2;

            // action
            var result = Rational.Log(value);

            // assert
            Assert.True(double.IsNaN(result));
        }

        [Fact]
        public void NaturalLogarithmNaN()
        {
            // arrange
            var value = Rational.NaN;

            // action
            var result = Rational.Log(value);

            // assert
            Assert.True(double.IsNaN(result));
        }

        [Fact]
        public void Logarithm1()
        {
            // arrange
            var value = (Rational)(5.0 / 4.0);

            // action
            var result = Rational.Log(value, 2);

            // assert
            Assert.Equal(33439844.0 / 103873643.0, result, 7);
        }

        [Fact]
        public void Logarithm2()
        {
            // arrange
            var value = (Rational)(12.0 / 4.0);

            // action
            var result = Rational.Log(value, 2);

            // assert
            Assert.Equal(102225496.0 / 64497107.0, result, 7);
        }

        [Fact]
        public void Logarithm3()
        {
            // arrange
            var value = (Rational)(10.0 / 4.0);

            // action
            var result = Rational.Log(value, 2);

            // assert
            Assert.Equal(78830509.0 / 59632978.0, result, 7);
        }

        [Fact]
        public void Logarithm4()
        {
            // arrange
            var value = Rational.Zero;

            // action
            var result = Rational.Log(value, 2);

            // assert
            Assert.True(double.IsNaN(result));
        }

        [Fact]
        public void Logarithm5()
        {
            // arrange
            var value = (Rational)25 / -2;

            // action
            var result = Rational.Log(value, 2);

            // assert
            Assert.True(double.IsNaN(result));
        }

        [Fact]
        public void LogarithmNaN()
        {
            // arrange
            var value = Rational.NaN;

            // action
            var result = Rational.Log(value, 2);

            // assert
            Assert.True(double.IsNaN(result));
        }

        [Fact]
        public void RationalRoot1()
        {
            // arrange
            var value = (Rational)25 / 16;
            const int radix = 2;

            // action
            var result = Rational.RationalRoot(value, radix);

            // assert
            Assert.Equal((Rational)5 / 4, result);
        }

        [Fact]
        public void RationalRoot2()
        {
            // arrange
            var value = (Rational)16 / 25;
            const int radix = -2;

            // action
            var result = Rational.RationalRoot(value, radix);

            // assert
            Assert.Equal((Rational)5 / 4, result);
        }

        [Fact]
        public void RationalRoot3()
        {
            // arrange
            var value = (Rational)5 / -4;
            const int radix = 1;

            // action
            var result = Rational.RationalRoot(value, radix);

            // assert
            Assert.Equal((Rational)5 / -4, result);
        }

        [Fact]
        public void RationalRoot4()
        {
            // arrange
            var value = Rational.Zero;
            const int radix = 0;

            // action
            Assert.Throws<InvalidOperationException>(() => Rational.RationalRoot(value, radix));
        }

        [Fact]
        public void RationalRoot5()
        {
            // arrange
            var value = -(Rational)100 / 4;
            const int radix = 2;

            // action
            Assert.Throws<InvalidOperationException>(() => Rational.RationalRoot(value, radix));
        }

        [Fact]
        public void RationalRootNaN()
        {
            // arrange
            var value = Rational.NaN;
            const int radix = 2;

            // action
            var result = Rational.RationalRoot(value, radix);

            // assert
            Assert.Equal(Rational.NaN, result);
        }

        [Fact]
        public void Root1()
        {
            // arrange
            var value = (Rational)25 / 16;
            const int radix = 2;

            // action
            var result = Rational.Root(value, radix);

            // assert
            Assert.Equal((double)5 / 4, result);
        }

        [Fact]
        public void Root2()
        {
            // arrange
            var value = (Rational)16 / 25;
            const int radix = -2;

            // action
            var result = Rational.Root(value, radix);

            // assert
            Assert.Equal((double)5 / 4, result);
        }

        [Fact]
        public void Root3()
        {
            // arrange
            var value = (Rational)5 / -4;
            const int radix = 1;

            // action
            var result = Rational.Root(value, radix);

            // assert
            Assert.Equal((double)5 / -4, result);
        }

        [Fact]
        public void Root4()
        {
            // arrange
            var value = Rational.Zero;
            const int radix = 0;

            // action
            Assert.Throws<InvalidOperationException>(() => Rational.Root(value, radix));
        }

        [Fact]
        public void Root5()
        {
            // arrange
            var value = -(Rational)100 / 4;
            const int radix = 2;

            // action
            Assert.Throws<InvalidOperationException>(() => Rational.Root(value, radix));
        }

        [Fact]
        public void RootNaN()
        {
            // arrange
            var value = Rational.NaN;
            const int radix = 2;

            // action
            var result = Rational.Root(value, radix);

            // assert
            Assert.Equal(double.NaN, result);
        }
    }
}
