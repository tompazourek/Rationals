using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public partial struct Rational
    {

        public static Rational operator +(Rational left, Rational right)
        {
            return Add(left, right);
        }

        public static Rational operator -(Rational p)
        {
            return Negate(p);
        }

        public static Rational operator -(Rational left, Rational right)
        {
            return Subtract(left, right);
        }

        public static Rational operator *(Rational left, Rational right)
        {
            return Multiply(left, right);
        }

        public static Rational operator /(Rational left, Rational right)
        {
            return Divide(left, right);
        }

        public static Rational operator ++(Rational p)
        {
            return p + One;
        }

        public static Rational operator --(Rational p)
        {
            return p - One;
        }

        public static bool operator ==(Rational left, Rational right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Rational left, Rational right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(Rational left, Rational right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Rational left, Rational right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Rational left, Rational right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Rational left, Rational right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
