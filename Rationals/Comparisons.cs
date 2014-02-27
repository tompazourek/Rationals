using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public partial struct Rational
    {
        public override bool Equals(object obj)
        {
            if (!(obj is Rational))
                return false;

            Rational other = (Rational)obj;
            return Numerator * other.Denominator == other.Numerator * Denominator;
        }

        public static bool operator ==(Rational left, Rational right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Rational left, Rational right)
        {
            return !(left == right);
        }
    }
}
