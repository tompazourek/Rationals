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
        /// True if the number is equal to zero.
        /// </summary>
        public bool IsZero => Numerator.IsZero;

        /// <summary>
        /// True if the number is equal to one.
        /// </summary>
        public bool IsOne => Numerator == Denominator;

        /// <summary>
        /// Gets a number that indicates the sign (negative, positive, or zero) of the rational number.
        /// </summary>
        public int Sign => Numerator.Sign * Denominator.Sign;

        /// <summary>
        /// Indicates whether the value of the rational number is a power of two.
        /// </summary>
        public bool IsPowerOfTwo => Numerator.IsPowerOfTwo && Denominator.IsPowerOfTwo;

        /// <summary>
        /// Represents the exponent of 10 if the number was written in scientific notation.
        /// </summary>
        /// <example>
        /// Magnitude of 0 is 0.<br />
        /// Magnitude of 5 is 0.<br />
        /// Magnitude of 12 is 1.<br />
        /// Magnitude of 3 988 222 is 6.<br />
        /// Magnitude of 0.2223 is -1.<br />
        /// Magnitude of 0.04 is -2.<br />
        /// </example>
        public int Magnitude
        {
            get
            {
                if (IsZero)
                    return 0;

                // thanks to 0jpq0 for this magnitude algorithm
                // https://github.com/tompazourek/Rationals/issues/20#issue-398771661

                var numeratorDigits = BigIntegerUtils.GetNumberOfDigits(Numerator);
                var denominatorDigits = BigIntegerUtils.GetNumberOfDigits(Denominator);

                var magnitude = numeratorDigits - denominatorDigits;

                var numeratorAbs = BigInteger.Abs(Numerator);
                var denominatorAbs = BigInteger.Abs(Denominator);

                if (numeratorDigits > denominatorDigits)
                {
                    denominatorAbs *= BigInteger.Pow(10, numeratorDigits - denominatorDigits);
                }
                else if (numeratorDigits < denominatorDigits)
                {
                    numeratorAbs *= BigInteger.Pow(10, denominatorDigits - numeratorDigits);
                }

                if (numeratorAbs < denominatorAbs)
                {
                    magnitude--;
                }

                return magnitude;
            }
        }
    }
}