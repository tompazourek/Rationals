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
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Rationals
{
    public partial struct Rational : IFormattable
    {
        /// <summary>
        ///     Enumerates significant digits of the rational number.
        ///     Omits leading and trailing zeros (only exception is number zero).
        /// </summary>
        /// <remarks>
        ///     To see the right magnitude, see <seealso cref="Magnitude" /> (e.g. for writing in scientific notation).
        /// </remarks>
        public IEnumerable<char> Digits
        {
            get
            {
                BigInteger numerator = BigInteger.Abs(Numerator);
                BigInteger denominator = BigInteger.Abs(Denominator);
                bool removeLeadingZeros = true;
                bool returnedAny = false;
                while (numerator > 0)
                {
                    BigInteger rem;
                    BigInteger divided = BigInteger.DivRem(numerator, denominator, out rem);

                    string digits = divided.ToString(CultureInfo.InvariantCulture);

                    if (rem == 0)
                        digits = digits.TrimEnd('0'); // remove trailing zeros

                    foreach (char digit in digits)
                    {
                        if (removeLeadingZeros && digit == '0')
                            continue;

                        yield return digit;
                        removeLeadingZeros = false;
                        returnedAny = true;
                    }

                    numerator = rem * 10;
                }

                if (!returnedAny)
                    yield return '0';
            }
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "F";
            if (formatProvider == null) formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "F": // normal fraction
                    return ToString();

                case "W": // as whole + fractional part
                    {
                        BigInteger whole = WholePart;
                        Rational fraction = FractionPart;
                        if (whole.IsZero)
                            return fraction.ToString();

                        if (fraction.IsZero)
                            return whole.ToString();

                        return string.Format(formatProvider, "{0} + {1}", whole, fraction);
                    }
                case "C": // in canonical form
                    return CanonicalForm.ToString();
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }

        public override string ToString()
        {
            if (Denominator.IsOne)
                return Numerator.ToString();

            if (Numerator.IsZero)
                return 0.ToString(CultureInfo.InvariantCulture);

            return string.Format(CultureInfo.InvariantCulture, "{0}/{1}", Numerator, Denominator);
        }
    }
}