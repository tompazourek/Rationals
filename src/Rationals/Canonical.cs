using System.Numerics;

namespace Rationals
{
    /// <summary>
    /// Rational number.
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Cannonical form is irreducible fraction where denominator is always positive.
        /// </summary>
        /// <remarks>Canonical form of zero is 0/1.</remarks>
        public Rational CanonicalForm
        {
            get
            {
                if (IsNaN)
                    return NaN;

                if (Numerator.IsZero)
                    return Zero;

                var gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);

                if (Denominator.Sign < 0)
                    gcd = BigInteger.Negate(gcd);
                // ensures that canonical form is either positive or has minus in numerator

                var canonical = new Rational(Numerator / gcd, Denominator / gcd);
                return canonical;
            }
        }
    }
}
