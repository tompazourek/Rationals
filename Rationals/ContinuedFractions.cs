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
        /// Expands rational number to continued fraction coefficients.
        /// <seealso cref="FromContinuedFraction" />
        /// </summary>
        /// <returns>Output sequence of continued fraction coefficients</returns>
        public IEnumerable<BigInteger> ToContinuedFraction()
        {
            yield return WholePart;
            var fractionPart = FractionPart;

            while (!fractionPart.IsZero)
            {
                var p = 1 / fractionPart;

                yield return p.WholePart;
                fractionPart = p.FractionPart;
            }
        }

        /// <summary>
        /// Constructs rational number from sequence of continued fraction coefficients.
        /// <seealso cref="ToContinuedFraction" />
        /// </summary>
        /// <param name="continuedFraction">Input sequence of continued fraction coefficients</param>
        /// <returns>Output rational number</returns>
        public static Rational FromContinuedFraction(IEnumerable<BigInteger> continuedFraction)
        {
            var rational = Zero;
            foreach (var coefficient in continuedFraction.Reverse())
            {
                if (rational.IsZero)
                {
                    rational = coefficient;
                    continue;
                }
                rational = coefficient + 1 / rational;
            }
            return rational;
        }
    }
}