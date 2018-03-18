using System;
using System.Numerics;

namespace Rationals
{
    /// <summary>
    /// Rational number.
    /// </summary>
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
        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            switch (obj)
            {
                case sbyte @sbyte:
                    return CompareTo(@sbyte);
                case byte b:
                    return CompareTo(b);
                case short s:
                    return CompareTo(s);
                case ushort @ushort:
                    return CompareTo(@ushort);
                case int i:
                    return CompareTo(i);
                case uint u:
                    return CompareTo(u);
                case long l:
                    return CompareTo(l);
                case ulong @ulong:
                    return CompareTo(@ulong);
                case Rational rational:
                    return CompareTo(rational);
                case BigInteger integer:
                    return CompareTo(integer);
            }

            return -1;
        }

        /// <inheritdoc />
        public int CompareTo(BigInteger other) => CompareTo((Rational)other);

        /// <inheritdoc />
        public int CompareTo(byte other) => CompareTo((Rational)other);

        /// <inheritdoc />
        public int CompareTo(int other) => CompareTo((Rational)other);

        /// <inheritdoc />
        public int CompareTo(long other) => CompareTo((Rational)other);

        /// <inheritdoc />
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

        /// <inheritdoc />
        [CLSCompliant(false)]
        public int CompareTo(sbyte other) => CompareTo((Rational)other);

        /// <inheritdoc />
        public int CompareTo(short other) => CompareTo((Rational)other);

        /// <inheritdoc />
        [CLSCompliant(false)]
        public int CompareTo(uint other) => CompareTo((Rational)other);

        /// <inheritdoc />
        [CLSCompliant(false)]
        public int CompareTo(ulong other) => CompareTo((Rational)other);

        /// <inheritdoc />
        [CLSCompliant(false)]
        public int CompareTo(ushort other) => CompareTo((Rational)other);

        /// <inheritdoc />
        public bool Equals(BigInteger other) => Equals((Rational)other);

        /// <inheritdoc />
        public bool Equals(byte other) => Equals((Rational)other);

        /// <inheritdoc />
        public bool Equals(int other) => Equals((Rational)other);

        /// <inheritdoc />
        public bool Equals(long other) => Equals((Rational)other);

        /// <inheritdoc />
        public bool Equals(Rational other) => (Numerator * other.Denominator).Equals(other.Numerator * Denominator);

        /// <inheritdoc />
        [CLSCompliant(false)]
        public bool Equals(sbyte other) => Equals((Rational)other);

        /// <inheritdoc />
        public bool Equals(short other) => Equals((Rational)other);

        /// <inheritdoc />
        [CLSCompliant(false)]
        public bool Equals(uint other) => Equals((Rational)other);

        /// <inheritdoc />
        [CLSCompliant(false)]
        public bool Equals(ulong other) => Equals((Rational)other);

        /// <inheritdoc />
        [CLSCompliant(false)]
        public bool Equals(ushort other) => Equals((Rational)other);

        /// <inheritdoc />
        public override bool Equals(object other)
        {
            if (other is Rational rational)
                return Equals(rational);

            switch (other)
            {
                case short _:
                case ushort _:
                case sbyte _:
                case byte _:
                case int _:
                case uint _:
                case long _:
                case ulong _:
                case BigInteger _:
                    // ReSharper disable once PossibleInvalidCastException
                    return Equals((Rational)other);
            }

            return false;
        }

        /// <inheritdoc />
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