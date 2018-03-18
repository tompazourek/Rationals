using System;
using System.Numerics;

namespace Rationals
{
    /// <summary>
    /// Rational number.
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Constructs rational number out of a whole number.
        /// </summary>
        public Rational(BigInteger whole)
            : this(whole, 1)
        {
        }

        private Rational(ref BigInteger numerator, ref BigInteger denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");

            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Constructs rational number out of numerator and denominator.
        /// </summary>
        public Rational(BigInteger numerator, BigInteger denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");

            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Numerator part of the rational number.
        /// </summary>
        public BigInteger Numerator { get; }

        /// <summary>
        /// Denominator part of the rational number.
        /// </summary>
        public BigInteger Denominator { get; }
    }
}