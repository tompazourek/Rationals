#region License

// Copyright (C) Tomáš Pažourek, 2016
// All rights reserved.
// 
// Distributed under MIT license as a part of project Rationals.
// https://github.com/tompazourek/Rationals

#endregion

using System;
using System.Numerics;

namespace Rationals
{
    public partial struct Rational :
        IComparable,
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
        public int CompareTo(object obj)
        {
            if (obj is sbyte)
            {
                return CompareTo((sbyte)obj);
            }

            if (obj is byte)
            {
                return CompareTo((byte)obj);
            }

            if (obj is short)
            {
                return CompareTo((short)obj);
            }

            if (obj is ushort)
            {
                return CompareTo((ushort)obj);
            }

            if (obj is int)
            {
                return CompareTo((int)obj);
            }

            if (obj is uint)
            {
                return CompareTo((uint)obj);
            }

            if (obj is long)
            {
                return CompareTo((long)obj);
            }

            if (obj is ulong)
            {
                return CompareTo((ulong)obj);
            }


            if (obj is Rational)
            {
                return CompareTo((Rational)obj);
            }

            if (obj is BigInteger)
            {
                return CompareTo((BigInteger)obj);
            }      

            return ReferenceEquals(obj, this) ? 0 :  -1;
        }

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

                return
                    -BigInteger.Abs(Numerator * other.Denominator)
                        .CompareTo(BigInteger.Abs(other.Numerator * Denominator));
            }

            if (Sign > other.Sign)
                return 1;

            return -1;
        }

        [CLSCompliant(false)]
        public int CompareTo(sbyte other)
        {
            return CompareTo((Rational) other);
        }

        public int CompareTo(short other)
        {
            return CompareTo((Rational) other);
        }

        [CLSCompliant(false)]
        public int CompareTo(uint other)
        {
            return CompareTo((Rational) other);
        }

        [CLSCompliant(false)]
        public int CompareTo(ulong other)
        {
            return CompareTo((Rational) other);
        }

        [CLSCompliant(false)]
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

        [CLSCompliant(false)]
        public bool Equals(sbyte other)
        {
            return Equals((Rational) other);
        }

        public bool Equals(short other)
        {
            return Equals((Rational) other);
        }

        [CLSCompliant(false)]
        public bool Equals(uint other)
        {
            return Equals((Rational) other);
        }

        [CLSCompliant(false)]
        public bool Equals(ulong other)
        {
            return Equals((Rational) other);
        }

        [CLSCompliant(false)]
        public bool Equals(ushort other)
        {
            return Equals((Rational) other);
        }

        public override bool Equals(object other)
        {
            if (other is Rational)
                return Equals((Rational) other);

            if (other is short ||
                other is ushort ||
                other is sbyte ||
                other is byte ||
                other is int ||
                other is uint ||
                other is long ||
                other is ulong ||
                other is BigInteger)
                // ReSharper disable once PossibleInvalidCastException
                return Equals((Rational) other);

            return false;
        }

        public override int GetHashCode()
        {
            var canonical = CanonicalForm;
            unchecked
            {
                var hash = 27;
                hash = 13 * hash + canonical.Numerator.GetHashCode();
                hash = 13 * hash + canonical.Denominator.GetHashCode();
                return hash;
            }
        }
    }
}