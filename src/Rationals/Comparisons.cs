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
            if (obj is sbyte @sbyte)
            {
                return CompareTo(@sbyte);
            }

            if (obj is byte b)
            {
                return CompareTo(b);
            }

            if (obj is short s)
            {
                return CompareTo(s);
            }

            if (obj is ushort @ushort)
            {
                return CompareTo(@ushort);
            }

            if (obj is int i)
            {
                return CompareTo(i);
            }

            if (obj is uint u)
            {
                return CompareTo(u);
            }

            if (obj is long l)
            {
                return CompareTo(l);
            }

            if (obj is ulong @ulong)
            {
                return CompareTo(@ulong);
            }

            if (obj is Rational rational)
            {
                return CompareTo(rational);
            }

            if (obj is BigInteger integer)
            {
                return CompareTo(integer);
            }

            return -1;
        }

        public int CompareTo(BigInteger other)
        {
            return CompareTo((Rational)other);
        }

        public int CompareTo(byte other)
        {
            return CompareTo((Rational)other);
        }

        public int CompareTo(int other)
        {
            return CompareTo((Rational)other);
        }

        public int CompareTo(long other)
        {
            return CompareTo((Rational)other);
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
            return CompareTo((Rational)other);
        }

        public int CompareTo(short other)
        {
            return CompareTo((Rational)other);
        }

        [CLSCompliant(false)]
        public int CompareTo(uint other)
        {
            return CompareTo((Rational)other);
        }

        [CLSCompliant(false)]
        public int CompareTo(ulong other)
        {
            return CompareTo((Rational)other);
        }

        [CLSCompliant(false)]
        public int CompareTo(ushort other)
        {
            return CompareTo((Rational)other);
        }

        public bool Equals(BigInteger other)
        {
            return Equals((Rational)other);
        }

        public bool Equals(byte other)
        {
            return Equals((Rational)other);
        }

        public bool Equals(int other)
        {
            return Equals((Rational)other);
        }

        public bool Equals(long other)
        {
            return Equals((Rational)other);
        }

        public bool Equals(Rational other)
        {
            return (Numerator * other.Denominator).Equals(other.Numerator * Denominator);
        }

        [CLSCompliant(false)]
        public bool Equals(sbyte other)
        {
            return Equals((Rational)other);
        }

        public bool Equals(short other)
        {
            return Equals((Rational)other);
        }

        [CLSCompliant(false)]
        public bool Equals(uint other)
        {
            return Equals((Rational)other);
        }

        [CLSCompliant(false)]
        public bool Equals(ulong other)
        {
            return Equals((Rational)other);
        }

        [CLSCompliant(false)]
        public bool Equals(ushort other)
        {
            return Equals((Rational)other);
        }

        public override bool Equals(object other)
        {
            if (other is Rational rational)
                return Equals(rational);

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
                return Equals((Rational)other);

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