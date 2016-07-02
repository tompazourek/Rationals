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
        public static explicit operator decimal(Rational rational)
        {
            if (rational < 0)
                return -(decimal) -rational;

            decimal result = 0;
            var numerator = rational.Numerator;
            var denominator = rational.Denominator;
            var scale = 1M;
            var previousScale = 0M;
            while (numerator > 0)
            {
                BigInteger rem;
                var divided = BigInteger.DivRem(numerator, denominator, out rem);

                if (scale == 0)
                {
                    if (divided >= 5)
                        result += previousScale; // round up last digit

                    break;
                }

                result += (decimal) divided * scale;

                numerator = rem * 10;
                previousScale = scale;
                scale /= 10;
            }

            return result;
        }

        public static explicit operator double(Rational rational)
        {
            return (double) (decimal) rational;
        }

        public static explicit operator float(Rational rational)
        {
            return (float) (decimal) rational;
        }
    }
}