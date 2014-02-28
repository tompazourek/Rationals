using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public partial struct Rational
    {
        public static explicit operator sbyte(Rational rational)
        {
            return (sbyte) rational.WholePart;
        }

        public static explicit operator byte(Rational rational)
        {
            return (byte)rational.WholePart;
        }

        public static explicit operator ushort(Rational rational)
        {
            return (ushort)rational.WholePart;
        }

        public static explicit operator short(Rational rational)
        {
            return (short)rational.WholePart;
        }

        public static explicit operator uint(Rational rational)
        {
            return (uint)rational.WholePart;
        }

        public static explicit operator int(Rational rational)
        {
            return (int)rational.WholePart;
        }

        public static explicit operator ulong(Rational rational)
        {
            return (ulong)rational.WholePart;
        }

        public static explicit operator long(Rational rational)
        {
            return (long)rational.WholePart;
        }
    }
}
