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
        /// Cannonical form is irreducible fraction where denominator is always positive.
        /// </summary>
        /// <remarks>Canonical form of zero is 0/1.</remarks>
        public Rational CanonicalForm
        {
            get
            {
                if (Numerator.IsZero)
                    return Zero;

                var gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);

                if (Denominator.Sign < 0)
                    gcd = BigInteger.Negate(gcd);
                // ensures that canonical form is either positive or has minus in numerator

                var canonical = new Rational(Numerator / gcd, Denominator / gcd);
                return canonical;
            }
        }
    }
}