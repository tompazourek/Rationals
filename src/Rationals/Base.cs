using System;
using System.Numerics;

namespace Rationals
{
    /// <summary>
    /// Rational number.
    /// </summary>
    public partial struct Rational
    {
        private readonly BigInteger _numerator;
        private readonly BigInteger _denominator;

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

            _numerator = numerator;
            _denominator = denominator;
        }

        /// <summary>
        /// Constructs rational number out of numerator and denominator.
        /// </summary>
        public Rational(BigInteger numerator, BigInteger denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");

            _numerator = numerator;
            _denominator = denominator;
        }

        /// <summary>
        /// Numerator part of the rational number.
        /// </summary>
        public BigInteger Numerator
        {
            get => _numerator;
        }

        /// <summary>
        /// Denominator part of the rational number.
        /// </summary>
        public BigInteger Denominator
        {
            // denominator can be 0 when an instance is created using default constructor
            get => _denominator == 0 ? BigInteger.One : _denominator;
        }
    }
}