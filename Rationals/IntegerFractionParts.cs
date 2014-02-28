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
        /// Integral part of the rational number
        /// <seealso cref="FractionPart"/>.
        /// </summary>
        public BigInteger IntegerPart
        {
            get
            {
                if (IsZero)
                    return 0;

                BigInteger integerPart;
                if (Sign > 0)
                {
                    if (Numerator < Denominator)
                        return 0;

                    if (IsOne)
                        return 1;

                    integerPart = Numerator / Denominator;
                    return integerPart;
                }

                BigInteger remainder;
                integerPart = BigInteger.DivRem(Numerator, Denominator, out remainder);

                if (remainder != 0)
                    integerPart--;

                return integerPart;
            }
        }

        /// <summary>
        /// Fractional part of the rational number
        /// <seealso cref="IntegerPart"/>.
        /// </summary>
        public Rational FractionPart
        {
            get
            {
                if (Sign > 0)
                {
                    if (Numerator < Denominator)
                        return this;

                    if (IsOne)
                        return 0;
                }

                var fractionPart = this - IntegerPart;
                return fractionPart;
            }
        }
    }
}
