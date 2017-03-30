#region License

// Copyright (C) Tomáš Pažourek, 2016
// All rights reserved.
// 
// Distributed under MIT license as a part of project Rationals.
// https://github.com/tompazourek/Rationals

#endregion

using System;
using NUnit.Framework;
using Rationals;

namespace RationalTests
{
    [TestFixture(Category = "Operations")]
    public class OperationsTests
    {
        [Test]
        public void Addition1()
        {
            // arrange
            var left = (Rational) 1 / 2;
            var right = (Rational) 1 / 4;

            // action
            var sum = left + right;

            // assert
            Assert.AreEqual((Rational) 3 / 4, sum);
        }

        [Test]
        public void Addition2()
        {
            // arrange
            var left = (Rational) 1 / 2;
            var right = (Rational) 0 / 4;

            // action
            var sum = left + right;

            // assert
            Assert.AreEqual((Rational) 1 / 2, sum);
        }

        [Test]
        public void Addition3()
        {
            // arrange
            var left = (Rational) 32 / 16;
            var right = (Rational) 4 / 8;

            // action
            var sum = left + right;

            // assert
            Assert.AreEqual((Rational) 5 / 2, sum);
        }

        [Test]
        public void Addition4()
        {
            // arrange
            var left = (Rational) 32 / 16;
            var right = -(Rational) 4 / 8;

            // action
            var sum = left + right;

            // assert
            Assert.AreEqual((Rational) 3 / 2, sum);
        }

        [Test]
        public void Division1()
        {
            // arrange
            var left = (Rational) 3 / 4;
            var right = (Rational) 1 / 3;

            // action
            var result = left / right;

            // assert
            Assert.AreEqual((Rational) 9 / 4, result);
        }

        [Test]
        public void Division2()
        {
            // arrange
            var left = (Rational) 3 / 4;
            var right = (Rational) 0 / 3;

            // action
            // ReSharper disable NotAccessedVariable
            Rational result;

            Assert.Catch(() => result = left / right);
            // ReSharper restore NotAccessedVariable
        }

        [Test]
        public void Division3()
        {
            // arrange
            var left = (Rational) 0 / 4;
            var right = (Rational) 1 / 3;

            // action
            var result = left / right;

            // assert
            Assert.AreEqual(Rational.Zero, result);
        }

        [Test]
        public void Division4()
        {
            // arrange
            var left = -(Rational) 15 / 4;
            var right = (Rational) 1 / 15;

            // action
            var result = left / right;

            // assert
            Assert.AreEqual(-(Rational) 225 / 4, result);
        }

        [Test]
        public void Exponentiation1()
        {
            // arrange
            var value = (Rational) 5 / 4;
            const int exponent = 2;

            // action
            var result = Rational.Pow(value, exponent);

            // assert
            Assert.AreEqual((Rational) 25 / 16, result);
        }

        [Test]
        public void Exponentiation2()
        {
            // arrange
            var value = (Rational) 5 / 4;
            const int exponent = -2;

            // action
            var result = Rational.Pow(value, exponent);

            // assert
            Assert.AreEqual((Rational) 16 / 25, result);
        }

        [Test]
        public void Exponentiation3()
        {
            // arrange
            var value = (Rational) 5 / -4;
            const int exponent = 1;

            // action
            var result = Rational.Pow(value, exponent);

            // assert
            Assert.AreEqual((Rational) 5 / -4, result);
        }

        [Test]
        public void Exponentiation4()
        {
            // arrange
            var value = Rational.Zero;
            const int exponent = 0;

            // action
            var result = Rational.Pow(value, exponent);

            // assert
            Assert.AreEqual(Rational.One, result);
        }

        [Test]
        public void Exponentiation5()
        {
            // arrange
            var value = -(Rational) 10 / 2;
            const int exponent = 2;

            // action
            var result = Rational.Pow(value, exponent);

            // assert
            Assert.AreEqual((Rational) 100 / 4, result);
        }

        [Test]
        public void Inversion1()
        {
            // arrange
            var p = (Rational) 1 / 2;

            // action
            var inverted = Rational.Invert(p);

            // assert
            Assert.AreEqual((Rational) 2 / 1, inverted);
        }

        [Test]
        public void Inversion2()
        {
            // arrange
            var p = (Rational) 5 / -3;

            // action
            var inverted = Rational.Invert(p);

            // assert
            Assert.AreEqual(-(Rational) 3 / 5, inverted);
        }

        [Test]
        public void Inversion3()
        {
            // arrange
            var p = (Rational) 0 / 1;

            // action
            Assert.Catch(() => Rational.Invert(p));
        }

        [Test]
        public void Multiplication1()
        {
            // arrange
            var left = (Rational) 3 / 4;
            var right = (Rational) 1 / 3;

            // action
            var product = left * right;

            // assert
            Assert.AreEqual((Rational) 3 / 12, product);
        }

        [Test]
        public void Multiplication2()
        {
            // arrange
            var left = (Rational) 0 / 4;
            var right = (Rational) 1 / 3;

            // action
            var product = left * right;

            // assert
            Assert.AreEqual(Rational.Zero, product);
        }

        [Test]
        public void Multiplication3()
        {
            // arrange
            var left = (Rational) 7 / 4;
            var right = (Rational) 0 / 3;

            // action
            var product = left * right;

            // assert
            Assert.AreEqual(Rational.Zero, product);
        }

        [Test]
        public void Multiplication4()
        {
            // arrange
            var left = (Rational) 3 / 4;
            var right = (Rational) 1 / -3;

            // action
            var product = left * right;

            // assert
            Assert.AreEqual(-(Rational) 3 / 12, product);
        }

        [Test]
        public void Negation1()
        {
            // arrange
            var p = new Rational(1, 2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual(-(Rational) 1 / 2, q);
        }

        [Test]
        public void Negation2()
        {
            // arrange
            var p = new Rational(-1, 2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual((Rational) 1 / 2, q);
        }

        [Test]
        public void Negation3()
        {
            // arrange
            var p = new Rational(1, -2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual((Rational) 1 / 2, q);
        }

        [Test]
        public void Negation4()
        {
            // arrange
            var p = new Rational(-1, -2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual(-(Rational) 1 / 2, q);
        }

        [Test]
        public void Negation5()
        {
            // arrange
            var p = new Rational(0, 10);

            // action
            var q = -p;

            // assert
            Assert.AreEqual(p, q);
        }

        [Test]
        public void Subtraction1()
        {
            // arrange
            var left = (Rational) 3 / 4;
            var right = (Rational) 1 / 3;

            // action
            var result = left - right;

            // assert
            Assert.AreEqual((Rational) 5 / 12, result);
        }

        [Test]
        public void Subtraction2()
        {
            // arrange
            var left = (Rational) 3 / 4;
            var right = (Rational) 4 / 3;

            // action
            var result = left - right;

            // assert
            Assert.AreEqual(-(Rational) 7 / 12, result);
        }

        [Test]
        public void Subtraction3()
        {
            // arrange
            var left = (Rational) 0 / 4;
            var right = (Rational) 4 / 3;

            // action
            var result = left - right;

            // assert
            Assert.AreEqual(-(Rational) 4 / 3, result);
        }


        [Test]
        public void Subtraction4()
        {
            // arrange
            var left = (Rational) 5 / 4;
            var right = (Rational) 0 / 3;

            // action
            var result = left - right;

            // assert
            Assert.AreEqual((Rational) 5 / 4, result);
        }

        [Test]
        public void Subtraction5()
        {
            // arrange
            var p = (Rational) 5 / 4;

            // action
            var result = p - p;

            // assert
            Assert.AreEqual(Rational.Zero, result);
        }

        [Test]
        public void Absolute1()
        {
            // arrange
            var p = new Rational(1, 2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual((Rational)1 / 2, Rational.Abs(q));
        }

        [Test]
        public void Absolute2()
        {
            // arrange
            var p = new Rational(-1, 2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual((Rational)1 / 2, Rational.Abs(q));
        }

        [Test]
        public void Absolute3()
        {
            // arrange
            var p = new Rational(1, -2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual((Rational) 1 / 2, Rational.Abs(q));
        }

        [Test]
        public void Absolute4()
        {
            // arrange
            var p = new Rational(-1, -2);

            // action
            var q = -p;

            // assert
            Assert.AreEqual((Rational) 1 / 2, Rational.Abs(q));
        }

        [Test]
        public void Absolute5()
        {
            // arrange
            var p = new Rational(0, 10);

            // action
            var q = -p;

            // assert
            Assert.AreEqual(p, Rational.Abs(q));
        }

        [Test]
        public void Base10Logarithm1()
        {
            // arrange
            var value = (Rational)(5.0 / 4.0);

            // action
            var result = Rational.Log10(value);

            // assert
            Assert.AreEqual(33439844.0 / 345060773.0, result, 0.0000001);
        }

        [Test]
        public void Base10Logarithm2()
        {
            // arrange
            var value = (Rational)(12.0 / 4.0);

            // action
            var result = Rational.Log10(value);

            // assert
            Assert.AreEqual(53565241.0 / 112267564.0, result, 0.0000001);
        }

        [Test]
        public void Base10Logarithm3()
        {
            // arrange
            var value = (Rational)(10.0 / 4.0);

            // action
            var result = Rational.Log10(value);

            // assert
            Assert.AreEqual(29241489.0 / 73482154.0, result, 0.0000001);
        }

        [Test]
        public void Base10Logarithm4()
        {
            // arrange
            var value = Rational.Zero;

            // action
            var result = Rational.Log10(value);

            // assert
            Assert.IsTrue(double.IsNaN(result));
        }

        [Test]
        public void Base10Logarithm5()
        {
            // arrange
            var value = (Rational)25 / -2;

            // action
            var result = Rational.Log10(value);

            // assert
            Assert.IsTrue(double.IsNaN(result));
        }

        [Test]
        public void NaturalLogarithm1()
        {
            // arrange
            var value = (Rational)(5.0 / 4.0);

            // action
            var result = Rational.Log(value);

            // assert
            Assert.AreEqual(231848159.0 / 1039009004.0, result, 0.0000001);
        }

        [Test]
        public void NaturalLogarithm2()
        {
            // arrange
            var value = (Rational)(12.0 / 4.0);

            // action
            var result = Rational.Log(value);

            // assert
            Assert.AreEqual(210545501.0 / 191646774.0, result, 0.0000001);
        }

        [Test]
        public void NaturalLogarithm3()
        {
            // arrange
            var value = (Rational)(10.0 / 4.0);

            // action
            var result = Rational.Log(value);

            // assert
            Assert.AreEqual(96543057.0 / 105362909.0, result, 0.0000001);
        }

        [Test]
        public void NaturalLogarithm4()
        {
            // arrange
            var value = Rational.Zero;

            // action
            var result = Rational.Log(value);

            // assert
            Assert.IsTrue(double.IsNaN(result));
        }

        [Test]
        public void NaturalLogarithm5()
        {
            // arrange
            var value = (Rational)25 / -2;

            // action
            var result = Rational.Log(value);

            // assert
            Assert.IsTrue(double.IsNaN(result));
        }

        [Test]
        public void Logarithm1()
        {
            // arrange
            var value = (Rational)(5.0 / 4.0);

            // action
            var result = Rational.Log(value, 2);

            // assert
            Assert.AreEqual(33439844.0 / 103873643.0, result, 0.0000001);
        }

        [Test]
        public void Logarithm2()
        {
            // arrange
            var value = (Rational)(12.0 / 4.0);

            // action
            var result = Rational.Log(value, 2);

            // assert
            Assert.AreEqual(102225496.0 / 64497107.0, result, 0.0000001);
        }

        [Test]
        public void Logarithm3()
        {
            // arrange
            var value = (Rational)(10.0 / 4.0);

            // action
            var result = Rational.Log(value, 2);

            // assert
            Assert.AreEqual(78830509.0 / 59632978.0, result, 0.0000001);
        }

        [Test]
        public void Logarithm4()
        {
            // arrange
            var value = Rational.Zero;

            // action
            var result = Rational.Log(value, 2);

            // assert
            Assert.IsTrue(double.IsNaN(result));
        }

        [Test]
        public void Logarithm5()
        {
            // arrange
            var value = (Rational)25 / -2;

            // action
            var result = Rational.Log(value, 2);

            // assert
            Assert.IsTrue(double.IsNaN(result));
        }
    }
}