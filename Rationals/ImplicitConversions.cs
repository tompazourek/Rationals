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
using System.Numerics;
using System.Text;

namespace Rationals
{
    public partial struct Rational
    {
        public static implicit operator Rational(sbyte n)
        {
            return n != 0 ? new Rational(n) : Zero;
        }

        public static implicit operator Rational(byte n)
        {
            return n != 0 ? new Rational(n) : Zero;
        }

        public static implicit operator Rational(short n)
        {
            return n != 0 ? new Rational(n) : Zero;
        }

        public static implicit operator Rational(ushort n)
        {
            return n != 0 ? new Rational(n) : Zero;
        }

        public static implicit operator Rational(int n)
        {
            return n != 0 ? new Rational(n) : Zero;
        }

        public static implicit operator Rational(uint n)
        {
            return n != 0 ? new Rational(n) : Zero;
        }

        public static implicit operator Rational(long n)
        {
            return n != 0 ? new Rational(n) : Zero;
        }

        public static implicit operator Rational(ulong n)
        {
            return n != 0 ? new Rational(n) : Zero;
        }

        public static implicit operator Rational(BigInteger n)
        {
            return !n.IsZero ? new Rational(n) : Zero;
        }
    }
}