using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Rationals
{
    /// <summary>
    /// Rational number.
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Multiplicative inverse of the rational number.
        /// </summary>
        public static Rational Invert(Rational p)
        {
            var numerator = p.Denominator;
            var denominator = p.Numerator;
            var result = new Rational(numerator, denominator);
            return result;
        }

        /// <summary>
        /// Additive inverse of the rational number.
        /// </summary>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
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
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
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
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
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
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
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
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
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
        /// Exponentiation of the rational number to the given integer exponent.
        /// </summary>
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
        /// Gets the absolute value of the rational number.
        /// </summary>
        public static Rational Abs(Rational p)
        {
            if (p.IsZero)
                return Zero;

            var numerator = BigInteger.Abs(p.Numerator);
            var denominator = BigInteger.Abs(p.Denominator);
            var result = new Rational(ref numerator, ref denominator);
            return result;
        }

        /// <summary>
        /// Returns the base 10 logarithm of a rational number.
        /// </summary>
        public static double Log10(Rational p)
        {
            if (p.IsZero)
                return double.NaN;

            var result = BigInteger.Log10(p.Numerator) - BigInteger.Log10(p.Denominator);
            return result;
        }

        /// <summary>
        /// Returns the natural (base e) logarithm of a rational number.
        /// </summary>
        public static double Log(Rational p)
        {
            if (p.IsZero)
                return double.NaN;

            var result = BigInteger.Log(p.Numerator) - BigInteger.Log(p.Denominator);
            return result;
        }

        /// <summary>
        /// Returns the logarithm of a rational number.
        /// </summary>
        public static double Log(Rational p, double baseValue)
        {
            if (p.IsZero)
                return double.NaN;

            var result = BigInteger.Log(p.Numerator, baseValue) - BigInteger.Log(p.Denominator, baseValue);
            return result;
        }

        /// <summary>
        /// Root of the rational number as double.
        /// </summary>
        public static double Root(Rational number, double radix)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (radix == 1)
                return (double)number;

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (radix == 0)
                throw new InvalidOperationException("Cannot use zero radix.");

            if (number.IsOne)
                return 1;

            if (number.IsZero)
            {
                if (radix < 0)
                    throw new DivideByZeroException("Cannot root zero to negative exponent.");

                return 0;
            }

            if (number < 0)
            {
                throw new InvalidOperationException("Cannot compute root of negative number.");
            }

            var result = Math.Pow((double)number, 1 / radix);
            return result;
        }

        /// <summary>
        /// Root of the rational number to the given integer radix (experimental).
        /// </summary>
        public static Rational RationalRoot(Rational number, int radix)
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

            if (number < 0)
            {
                throw new InvalidOperationException("Cannot compute root of negative number.");
            }

            if (radix > 0)
            {
                var numerator = BigIntegerRootUtils.BigIntegerRoot(number.Numerator, radix);
                var denominator = BigIntegerRootUtils.BigIntegerRoot(number.Denominator, radix);
                var result = new Rational(ref numerator, ref denominator);
                return result;
            }
            else
            {
                var numerator = BigIntegerRootUtils.BigIntegerRoot(number.Denominator, -radix);
                var denominator = BigIntegerRootUtils.BigIntegerRoot(number.Numerator, -radix);
                var result = new Rational(ref numerator, ref denominator);
                return result;
            }
        }
    }
}