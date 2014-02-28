using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public partial struct Rational
    {
        public override string ToString()
        {
            if (_denominator.IsOne)
                return _numerator.ToString();

            if (_numerator.IsZero)
                return 0.ToString();

            return string.Format(CultureInfo.InvariantCulture, "{0}/{1}", _numerator, _denominator);
        }
    }
}