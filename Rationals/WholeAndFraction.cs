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

                BigInteger remainder;
                wholePart = BigInteger.DivRem(num, den, out remainder);

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