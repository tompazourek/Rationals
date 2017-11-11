using System;
using System.Numerics;

namespace Rationals
{
    public partial struct Rational
    {
        private readonly BigInteger _denominator;

        public Rational(BigInteger whole)
            : this(whole, 1)
        {
        }

        internal Rational(ref BigInteger numerator, ref BigInteger denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");

            Numerator = numerator;
            _denominator = denominator;
        }

        public Rational(BigInteger numerator, BigInteger denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");

            Numerator = numerator;
            _denominator = denominator;
        }

        public BigInteger Numerator { get; }

        public BigInteger Denominator => _denominator.IsZero ? 1 : _denominator;
    }
}