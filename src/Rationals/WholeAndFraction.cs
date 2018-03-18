using System.Numerics;

namespace Rationals
{
    /// <summary>
    /// Rational number.
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Whole part of the rational number, see also <seealso cref="FractionPart" />.
        /// </summary>
        /// <example>
        /// 4/3 = 1 + 1/3;
        /// -10/4 = -3 + 2/4
        /// </example>
        public BigInteger WholePart
        {
            get
            {
                if (IsZero)
                    return 0;

                // ensure that minus is only in numerator, if negative
                var num = Sign > 0 ? BigInteger.Abs(Numerator) : -BigInteger.Abs(Numerator);
                var den = BigInteger.Abs(Denominator);

                BigInteger wholePart;
                if (Sign > 0)
                {
                    if (num < den)
                        return 0;

                    if (IsOne)
                        return 1;

                    wholePart = num / den;
                    return wholePart;
                }

                wholePart = BigInteger.DivRem(num, den, out var remainder);

                if (remainder != 0)
                    wholePart--;

                return wholePart;
            }
        }

        /// <summary>
        /// Fractional part of the rational number, see also <seealso cref="WholePart" />.
        /// </summary>
        /// <example>
        /// 4/3 = 1 + 1/3;
        /// -10/4 = -3 + 2/4
        /// </example>
        public Rational FractionPart
        {
            get
            {
                // ensure that minus is only in numerator, if negative
                var num = Sign > 0 ? BigInteger.Abs(Numerator) : -BigInteger.Abs(Numerator);
                var den = BigInteger.Abs(Denominator);

                if (Sign > 0)
                {
                    if (num < den)
                        return this;

                    if (IsOne)
                        return 0;
                }

                var fractionPart = this - WholePart;
                return fractionPart;
            }
        }
    }
}