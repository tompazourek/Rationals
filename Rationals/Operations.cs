#region License

// Copyright (C) Tomáš Pažourek, 2016
// All rights reserved.
// 
// Distributed under MIT license as a part of project Rationals.
// https://github.com/tompazourek/Rationals

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Rationals
{
    public partial struct Rational
    {
        /// <summary>
        /// Multiplicative inverse of the rational number
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Rational Invert(Rational p)
        {
            var numerator = p.Denominator;
            var denominator = p.Numerator;
            var result = new Rational(numerator, denominator);
            return result;
        }

        /// <summary>
        /// Additive inverse of the rational number
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Rational Negate(Rational p)
        {
            if (p.IsZero)
                return Zero;

            BigInteger numerator;
            BigInteger denominator;
            if (p.Denominator < 0)
            {
                numerator = p.Numerator;
                denominator = BigInteger.Negate(p.Denominator);
            }
            else
            {
                numerator = BigInteger.Negate(p.Numerator);
                denominator = p.Denominator;
            }
            var result = new Rational(ref numerator, ref denominator);
            return result;
        }

        /// <summary>
        /// Returns the sum of the two numbers.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Rational Add(Rational left, Rational right)
        {
            if (right.IsZero)
                return left;

            if (left.IsZero)
                return right;

            var numerator = left.Numerator * right.Denominator + left.Denominator * right.Numerator;
            var denominator = left.Denominator * right.Denominator;
            var sum = new Rational(ref numerator, ref denominator);
            return sum;
        }

        /// <summary>
        /// Subtracts one number from another and returns result.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Rational Subtract(Rational left, Rational right)
        {
            if (right.IsZero)
                return left;

            if (left.IsZero)
                return -right;

            var numerator = left.Numerator * right.Denominator - left.Denominator * right.Numerator;
            var denominator = left.Denominator * right.Denominator;
            var difference = new Rational(ref numerator, ref denominator);
            return difference;
        }

        /// <summary>
        /// Returns product of the two numbers.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Rational Multiply(Rational left, Rational right)
        {
            if (left.IsZero || right.IsZero)
                return Zero;

            var numerator = left.Numerator * right.Numerator;
            var denominator = left.Denominator * right.Denominator;
            var product = new Rational(ref numerator, ref denominator);
            return product;
        }

        /// <summary>
        /// Divides one number by another and returns result.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Rational Divide(Rational left, Rational right)
        {
            if (right.IsZero)
                throw new DivideByZeroException();

            if (left.IsZero)
                return Zero;

            var numerator = left.Numerator * right.Denominator;
            var denominator = left.Denominator * right.Numerator;
            var quotient = new Rational(ref numerator, ref denominator);
            return quotient;
        }

        /// <summary>
        /// Exponentiation of the rational number to the given integer exponent
        /// </summary>
        /// <param name="number"></param>
        /// <param name="exponent"></param>
        /// <returns></returns>
        public static Rational Pow(Rational number, int exponent)
        {
            if (exponent == 1)
                return number;

            if (exponent == 0)
                return One;

            if (number.IsOne)
                return number;

            if (number.IsZero)
            {
                if (exponent < 0)
                    throw new DivideByZeroException("Cannot exponentiate zero to negative exponent.");

                return number;
            }

            if (exponent > 0)
            {
                var numerator = BigInteger.Pow(number.Numerator, exponent);
                var denominator = BigInteger.Pow(number.Denominator, exponent);
                var result = new Rational(ref numerator, ref denominator);
                return result;
            }
            else
            {
                var numerator = BigInteger.Pow(number.Denominator, -exponent);
                var denominator = BigInteger.Pow(number.Numerator, -exponent);
                var result = new Rational(ref numerator, ref denominator);
                return result;
            }
        }

        /// <summary>
        /// Root of the rational number to the given integer radix
        /// </summary>
        /// <param name="number"></param>
        /// <param name="radix"></param>
        /// <returns></returns>
        public static Rational Root(Rational number, int radix)
        {
            if (radix == 1)
                return number;

            if (radix == 0)
                throw new InvalidOperationException("Cannot use zero radix.");

            if (number.IsOne)
                return number;

            if (number.IsZero)
            {
                if (radix < 0)
                    throw new DivideByZeroException("Cannot root zero to negative exponent.");

                return number;
            }

            if (radix > 0)
            {
                var numerator = BigIntegerRoot(number.Numerator, radix);
                var denominator = BigIntegerRoot(number.Denominator, radix);
                var result = new Rational(ref numerator, ref denominator);
                return result;
            }
            else
            {
                var numerator = BigIntegerRoot(number.Denominator, -radix);
                var denominator = BigIntegerRoot(number.Numerator, -radix);
                var result = new Rational(ref numerator, ref denominator);
                return result;
            }
        }
    }
}