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
using System.Linq;
using System.Text;

namespace Rationals
{
    public partial struct Rational
    {
        [CLSCompliant(false)]
        public static explicit operator sbyte(Rational rational)
        {
            return (sbyte) rational.WholePart;
        }

        public static explicit operator byte(Rational rational)
        {
            return (byte) rational.WholePart;
        }

        [CLSCompliant(false)]
        public static explicit operator ushort(Rational rational)
        {
            return (ushort) rational.WholePart;
        }

        public static explicit operator short(Rational rational)
        {
            return (short) rational.WholePart;
        }

        [CLSCompliant(false)]
        public static explicit operator uint(Rational rational)
        {
            return (uint) rational.WholePart;
        }

        public static explicit operator int(Rational rational)
        {
            return (int) rational.WholePart;
        }

        [CLSCompliant(false)]
        public static explicit operator ulong(Rational rational)
        {
            return (ulong) rational.WholePart;
        }

        public static explicit operator long(Rational rational)
        {
            return (long) rational.WholePart;
        }
    }
}