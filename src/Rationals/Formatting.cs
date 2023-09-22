using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;

namespace Rationals
{
    /// <summary>
    /// Rational number.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
    public partial struct Rational : IFormattable
    {
        /// <summary>
        /// Enumerates significant digits of the rational number.
        /// Omits leading and trailing zeros (only exception is number zero).
        /// </summary>
        /// <remarks>
        /// To see the right magnitude, see <seealso cref="Magnitude" /> (e.g. for writing in scientific notation).
        /// </remarks>
        public IEnumerable<char> Digits
        {
            get
            {
                if (IsNaN) yield break;
                var numerator = BigInteger.Abs(Numerator);
                var denominator = BigInteger.Abs(Denominator);
                var removeLeadingZeros = true;
                var returnedAny = false;
                while (numerator > 0)
                {
                    var divided = BigInteger.DivRem(numerator, denominator, out var rem);

                    var digits = divided.ToString(CultureInfo.InvariantCulture);

                    if (rem == 0)
                        digits = digits.TrimEnd('0'); // remove trailing zeros

                    foreach (var digit in digits)
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

        /// <summary>
        /// Formats rational number to string
        /// </summary>
        /// <param name="format">F for normal fraction, C for canonical fraction, W for whole+fractional</param>
        /// <param name="formatProvider">Ignored, custom format providers are not supported</param>
        public string ToString(string format, IFormatProvider formatProvider) => ToString(format);

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER

        /// <summary>Tries to format the value of the current instance into the provided span of characters.</summary>
        /// <param name="destination">When this method returns, this instance's value formatted as a span of characters.</param>
        /// <param name="charsWritten">When this method returns, the number of characters that were written in <paramref name="destination"/>.</param>
        /// <param name="format">A span containing the characters that represent a standard or custom format string that defines the acceptable format for <paramref name="destination"/>.</param>
        /// <param name="provider">An optional object that supplies culture-specific formatting information for <paramref name="destination"/>.</param>
        /// <returns><see langword="true"/> if the formatting was successful; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// An implementation of this interface should produce the same string of characters as an implementation of <see cref="IFormattable.ToString(string?, IFormatProvider?)"/>
        /// on the same type.
        /// TryFormat should return false only if there is not enough space in the destination buffer. Any other failures should throw an exception.
        /// </remarks>
        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider provider)
            => throw new NotImplementedException();

#endif

        /// <summary>
        /// Formats rational number to string
        /// </summary>
        /// <param name="format">F for normal fraction, C for canonical fraction, W for whole+fractional</param>
        public string ToString(string format)
        {
            if (string.IsNullOrEmpty(format)) format = "F";

            switch (format.ToUpperInvariant())
            {
                case "F": // normal fraction
                    return ToString();

                case "W": // as whole + fractional part
                {
                    if (IsNaN)
                        return "NaN";

                    var whole = WholePart;
                    var fraction = FractionPart.CanonicalForm;
                    if (whole.IsZero)
                        return fraction.ToString();

                    if (fraction.IsZero)
                        return whole.ToString();

                    return string.Format(CultureInfo.InvariantCulture, "{0} + {1}", whole, fraction);
                }
                case "C": // in canonical form
                    return CanonicalForm.ToString();
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            if (IsNaN)
                return "NaN";

            if (Denominator.IsOne)
                return Numerator.ToString();

            if (Numerator.IsZero)
                return 0.ToString(CultureInfo.InvariantCulture);

            return string.Format(CultureInfo.InvariantCulture, "{0}/{1}", Numerator, Denominator);
        }

        private string DebuggerDisplay => IsNaN ? "NaN" : Numerator + "/" + Denominator;
    }
}
