using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public partial struct Rational
    {
        /// <summary>
        /// Multiplicative inverse of the rational number.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Rational Invert(Rational p)
        {
            BigInteger numerator = p.Denominator;
            BigInteger denominator = p.Numerator;
            var result = new Rational(numerator, denominator);
            return result;
        }

        /// <summary>
        /// Additive inverse of the rational number.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Rational Negate(Rational p)
        {
            return -p;
        }

        public static Rational operator +(Rational left, Rational right)
        {
            if (right.IsZero)
                return left;

            if (left.IsZero)
                return right;

            BigInteger numerator = left.Numerator * right.Denominator + left.Denominator * right.Numerator;
            BigInteger denominator = left.Denominator * right.Denominator;
            var sum = new Rational(ref numerator, ref denominator);
            return sum;
        }

        public static Rational operator -(Rational p)
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

        public static Rational operator -(Rational left, Rational right)
        {
            if (right.IsZero)
                return left;

            if (left.IsZero)
                return -right;

            BigInteger numerator = left.Numerator * right.Denominator - left.Denominator * right.Numerator;
            BigInteger denominator = left.Denominator * right.Denominator;
            var difference = new Rational(ref numerator, ref denominator);
            return difference;
        }

        public static Rational operator *(Rational left, Rational right)
        {
            if (left.IsZero || right.IsZero)
                return Zero;

            BigInteger numerator = left.Numerator * right.Numerator;
            BigInteger denominator = left.Denominator * right.Denominator;
            var product = new Rational(ref numerator, ref denominator);
            return product;
        }

        public static Rational operator /(Rational left, Rational right)
        {
            if (right.IsZero)
                throw new DivideByZeroException();

            if (left.IsZero)
                return Zero;

            BigInteger numerator = left.Numerator * right.Denominator;
            BigInteger denominator = left.Denominator * right.Numerator;
            var quotient = new Rational(ref numerator, ref denominator);
            return quotient;
        }

        public static Rational operator ++(Rational p)
        {
            return p + One;
        }

        public static Rational operator --(Rational p)
        {
            return p - One;
        }
    }
}