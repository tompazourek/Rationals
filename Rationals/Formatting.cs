using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public partial struct Rational : IFormattable
    {
        public override string ToString()
        {
            if (_denominator.IsOne)
                return _numerator.ToString();

            if (_numerator.IsZero)
                return 0.ToString(CultureInfo.InvariantCulture);

            return string.Format(CultureInfo.InvariantCulture, "{0}/{1}", _numerator, _denominator);
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
                        var whole = WholePart;
                        var fraction = FractionPart;
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
    }
}