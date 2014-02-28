using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public partial struct Rational :
        IEquatable<Rational>, IComparable<Rational>,
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

        public int CompareTo(uint other)
        {
            return CompareTo((Rational) other);
        }

        public int CompareTo(ulong other)
        {
            return CompareTo((Rational) other);
        }

        public bool Equals(BigInteger other)
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

        public bool Equals(uint other)
        {
            return Equals((Rational) other);
        }

        public bool Equals(ulong other)
        {
            return Equals((Rational) other);
        }

        public override bool Equals(object other)
        {
            if (!(other is Rational))
            {
                if (other is int ||
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