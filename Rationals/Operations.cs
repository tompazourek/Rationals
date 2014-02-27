using System;
using System.Collections.Generic;
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
            var numerator = p.Denominator;
            var denominator = p.Numerator;
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

            var numerator = left.Numerator * right.Denominator + left.Denominator * right.Numerator;
            var denominator = left.Denominator * right.Denominator;
            var sum = new Rational(ref numerator, ref denominator);
            var result = sum.CanonicalForm;
            return result;
        }

        public static Rational operator -(Rational p)
        {
            if (p.IsZero)
                return Rational.Zero;

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

            var numerator = left.Numerator * right.Denominator - left.Denominator * right.Numerator;
            var denominator = left.Denominator * right.Denominator;
            var sum = new Rational(ref numerator, ref denominator);
            var result = sum.CanonicalForm;
            return result;
        }

        public static Rational operator *(Rational left, Rational right)
        {
            if (left.IsZero || right.IsZero)
                return Rational.Zero;

            var numerator = left.Numerator * right.Numerator;
            var denominator = left.Denominator * right.Denominator;
            var sum = new Rational(ref numerator, ref denominator);
            var result = sum.CanonicalForm;
            return result;
        }

        public static Rational operator /(Rational left, Rational right)
        {
            if (right.IsZero)
                throw new DivideByZeroException();

            if (left.IsZero)
                return Rational.Zero;
            
            var numerator = left.Numerator * right.Denominator;
            var denominator = left.Denominator * right.Numerator;
            var sum = new Rational(ref numerator, ref denominator);
            var result = sum.CanonicalForm;
            return result;
        }
    }
}
