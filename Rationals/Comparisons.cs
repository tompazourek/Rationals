using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public partial struct Rational : IEquatable<Rational>, IEquatable<int>, IEquatable<uint>, IEquatable<long>, IEquatable<ulong>, IEquatable<BigInteger>
    {
        public override bool Equals(object obj)
        {
            if (!(obj is Rational))
            {
                if (obj is int ||
                    obj is uint ||
                    obj is long ||
                    obj is ulong ||
                    obj is BigInteger)
                {
                    return Equals((Rational)obj);
                }
                else
                {
                    return false;
                }
            }

            return Equals((Rational)obj);
        }

        public bool Equals(int other)
        {
            return Equals((Rational)other);
        }

        public bool Equals(uint other)
        {
            return Equals((Rational)other);
        }

        public bool Equals(long other)
        {
            return Equals((Rational)other);
        }

        public bool Equals(ulong other)
        {
            return Equals((Rational)other);
        }

        public bool Equals(BigInteger other)
        {
            return Equals((Rational)other);
        }

        public bool Equals(Rational other)
        {
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

        public override int GetHashCode()
        {
            var canonical = CanonicalForm;
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
