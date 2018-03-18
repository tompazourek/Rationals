using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Rationals
{
    /// <summary>
    /// Rational number.
    /// </summary>
    public partial struct Rational
    {
        private static readonly Regex FractionFormat = new Regex(@"^\s*(?<Numerator>-?\d+)/(?<Denominator>-?\d+)\s*$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant);

        private static readonly Regex WholeFractionalFormat =
            new Regex(@"^\s*(?<Whole>-?\d+)\s*[+]\s*(?<Numerator>-?\d+)/(?<Denominator>-?\d+)\s*$",
                RegexOptions.Compiled | RegexOptions.CultureInvariant);

        /// <summary>
        /// Converts the string representation of a number to its rational number equivalent.
        /// Accepts either "3/4" format, or "4 1/2" format.
        /// </summary>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static Rational Parse(string value)
        {
            return Parse(value, NumberStyles.Float, NumberFormatInfo.CurrentInfo);
        }

        /// <inheritdoc cref="Parse(string)"/>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static Rational Parse(string value, NumberStyles style)
        {
            return Parse(value, style, NumberFormatInfo.CurrentInfo);
        }

        /// <inheritdoc cref="Parse(string)"/>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static Rational Parse(string value, IFormatProvider provider)
        {
            return Parse(value, NumberStyles.Float, NumberFormatInfo.GetInstance(provider));
        }

        /// <inheritdoc cref="Parse(string)"/>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static Rational Parse(string value, NumberStyles style, IFormatProvider provider)
        {
            return Parse(value, style, NumberFormatInfo.GetInstance(provider));
        }

        private static Rational Parse(string value, NumberStyles style, NumberFormatInfo info)
        {
            if (!TryParse(value, style, info, out var result))
                throw new FormatException("Cannot parse string as Rational, the input is in incorrect format.");

            return result;
        }

        /// <inheritdoc cref="Parse(string)"/>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static bool TryParse(string value, out Rational result)
        {
            return TryParse(value, NumberStyles.Float, NumberFormatInfo.CurrentInfo, out result);
        }

        /// <inheritdoc cref="Parse(string)"/>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static bool TryParse(string value, NumberStyles style, IFormatProvider provider, out Rational result)
        {
            return TryParse(value, style, NumberFormatInfo.GetInstance(provider), out result);
        }

        private static bool TryParse(string value, NumberStyles style, NumberFormatInfo info, out Rational result)
        {
            result = default(BigInteger);

            try
            {
                var match = FractionFormat.Match(value);
                if (match.Success)
                {
                    var numerator = BigInteger.Parse(match.Groups["Numerator"].Value, style, info);
                    var denominator = BigInteger.Parse(match.Groups["Denominator"].Value, style, info);
                    result = new Rational(numerator, denominator);
                    return true;
                }

                match = WholeFractionalFormat.Match(value);
                if (match.Success)
                {
                    var whole = BigInteger.Parse(match.Groups["Whole"].Value, style, info);
                    var numerator = BigInteger.Parse(match.Groups["Numerator"].Value, style, info);
                    var denominator = BigInteger.Parse(match.Groups["Denominator"].Value, style, info);
                    result = new Rational(whole) + new Rational(numerator, denominator);
                    return true;
                }
            }
            catch (DivideByZeroException)
            {
                return false;
            }

            if (BigInteger.TryParse(value, style, info, out var justWhole))
            {
                result = new Rational(justWhole);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Converts the string representation of a decimal number to its rational number equivalent.
        /// Accepts the decimal format "1.123456", might be approximated to a "nicer" rational number if tolerance is given.
        /// </summary>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static Rational ParseDecimal(string value, decimal tolerance = 0)
        {
            return ParseDecimal(value, NumberStyles.Float, NumberFormatInfo.CurrentInfo, tolerance);
        }

        /// <inheritdoc cref="ParseDecimal(string,decimal)"/>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static Rational ParseDecimal(string value, NumberStyles style, decimal tolerance = 0)
        {
            return ParseDecimal(value, style, NumberFormatInfo.CurrentInfo, tolerance);
        }

        /// <inheritdoc cref="ParseDecimal(string,decimal)"/>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static Rational ParseDecimal(string value, IFormatProvider provider, decimal tolerance = 0)
        {
            return ParseDecimal(value, NumberStyles.Float, NumberFormatInfo.GetInstance(provider), tolerance);
        }

        /// <inheritdoc cref="ParseDecimal(string,decimal)"/>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static Rational ParseDecimal(string value, NumberStyles style, IFormatProvider provider, decimal tolerance = 0)
        {
            return ParseDecimal(value, style, NumberFormatInfo.GetInstance(provider), tolerance);
        }

        private static Rational ParseDecimal(string value, NumberStyles style, NumberFormatInfo info, decimal tolerance)
        {
            if (!TryParseDecimal(value, style, info, out var result, tolerance))
                throw new FormatException("Cannot parse string as Rational, the input is in incorrect format.");

            return result;
        }

        /// <inheritdoc cref="ParseDecimal(string,decimal)"/>
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static bool TryParseDecimal(string value, out Rational result, decimal tolerance = 0)
        {
            return TryParseDecimal(value, NumberStyles.Float, NumberFormatInfo.CurrentInfo, out result, tolerance);
        }

        /// <inheritdoc cref="ParseDecimal(string,decimal)"/>
        public static bool TryParseDecimal(string value, NumberStyles style, IFormatProvider provider, out Rational result, decimal tolerance = 0)
        {
            return TryParseDecimal(value, style, NumberFormatInfo.GetInstance(provider), out result, tolerance);
        }

        private static bool TryParseDecimal(string value, NumberStyles style, NumberFormatInfo info, out Rational result, decimal tolerance = 0)
        {
            if (!decimal.TryParse(value, style, info, out var d))
            {
                result = default(Rational);
                return false;
            }

            try
            {
                result = Approximate(d, tolerance);
                return true;
            }
            catch (Exception)
            {
                result = default(Rational);
                return false;
            }
        }
    }
}