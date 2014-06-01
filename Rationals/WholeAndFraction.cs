#region License

// Copyright (C) Tomáš Pažourek, 2014
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
        /// Whole part of the rational number, see also <seealso cref="FractionPart"/>.
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

                BigInteger wholePart;
                if (Sign > 0)
                {
                    if (Numerator < Denominator)
                        return 0;

                    if (IsOne)
                        return 1;

                    wholePart = Numerator / Denominator;
                    return wholePart;
                }

                BigInteger remainder;
                wholePart = BigInteger.DivRem(Numerator, Denominator, out remainder);

                if (remainder != 0)
                    wholePart--;

                return wholePart;
            }
        }

        /// <summary>
        /// Fractional part of the rational number, see also <seealso cref="WholePart"/>.
        /// </summary>
        /// <example>
        /// 4/3 = 1 + 1/3;
        /// -10/4 = -3 + 2/4
        /// </example>
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

                Rational fractionPart = this - WholePart;
                return fractionPart;
            }
        }
    }
}