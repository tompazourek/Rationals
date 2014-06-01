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
    public partial struct Rational :
        IEquatable<Rational>, IComparable<Rational>,
        IEquatable<sbyte>, IComparable<sbyte>,
        IEquatable<byte>, IComparable<byte>,
        IEquatable<short>, IComparable<short>,
        IEquatable<ushort>, IComparable<ushort>,
        IEquatable<int>, IComparable<int>,
        IEquatable<uint>, IComparable<uint>,
        IEquatable<long>, IComparable<long>,
        IEquatable<ulong>, IComparable<ulong>,
        IEquatable<BigInteger>, IComparable<BigInteger>
    {
        public int CompareTo(BigInteger other)
        {
            return CompareTo((Rational) other);
        }

        public int CompareTo(byte other)
        {
            return CompareTo((Rational) other);
        }

        public int CompareTo(int other)
        {
            return CompareTo((Rational) other);
        }

        public int CompareTo(long other)
        {
            return CompareTo((Rational) other);
        }

        public int CompareTo(Rational other)
        {
            if (Sign == other.Sign)
            {
                if (Sign >= 0)
                    return (Numerator * other.Denominator).CompareTo(other.Numerator * Denominator);

                return -BigInteger.Abs(Numerator * other.Denominator).CompareTo(BigInteger.Abs(other.Numerator * Denominator));
            }

            if (Sign > other.Sign)
                return 1;

            return -1;
        }

        public int CompareTo(sbyte other)
        {
            return CompareTo((Rational) other);
        }

        public int CompareTo(short other)
        {
            return CompareTo((Rational) other);
        }

        public int CompareTo(uint other)
        {
            return CompareTo((Rational) other);
        }

        public int CompareTo(ulong other)
        {
            return CompareTo((Rational) other);
        }

        public int CompareTo(ushort other)
        {
            return CompareTo((Rational) other);
        }

        public bool Equals(BigInteger other)
        {
            return Equals((Rational) other);
        }

        public bool Equals(byte other)
        {
            return Equals((Rational) other);
        }

        public bool Equals(int other)
        {
            return Equals((Rational) other);
        }

        public bool Equals(long other)
        {
            return Equals((Rational) other);
        }

        public bool Equals(Rational other)
        {
            return (Numerator * other.Denominator).Equals(other.Numerator * Denominator);
        }

        public bool Equals(sbyte other)
        {
            return Equals((Rational) other);
        }

        public bool Equals(short other)
        {
            return Equals((Rational) other);
        }

        public bool Equals(uint other)
        {
            return Equals((Rational) other);
        }

        public bool Equals(ulong other)
        {
            return Equals((Rational) other);
        }

        public bool Equals(ushort other)
        {
            return Equals((Rational) other);
        }

        public override bool Equals(object other)
        {
            if (!(other is Rational))
            {
                if (other is short ||
                    other is ushort ||
                    other is sbyte ||
                    other is byte ||
                    other is int ||
                    other is uint ||
                    other is long ||
                    other is ulong ||
                    other is BigInteger)
                {
                    return Equals((Rational) other);
                }
                return false;
            }

            return Equals((Rational) other);
        }

        public override int GetHashCode()
        {
            Rational canonical = CanonicalForm;
            unchecked
            {
                int hash = 27;
                hash = (13 * hash) + canonical.Numerator.GetHashCode();
                hash = (13 * hash) + canonical.Denominator.GetHashCode();
                return hash;
            }
        }
    }
}