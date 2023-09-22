using System;
using System.Numerics;

#if NET7_0_OR_GREATER

namespace Rationals
{
    public partial struct Rational : INumber<Rational>
    {
        /// <inheritdoc />
        static Rational INumberBase<Rational>.One
            => One;

        /// <inheritdoc />
        static int INumberBase<Rational>.Radix
            => 2;

        /// <inheritdoc />
        static Rational INumberBase<Rational>.Zero
            => Zero;

        /// <inheritdoc />
        static Rational IAdditiveIdentity<Rational, Rational>.AdditiveIdentity
            => Zero;

        /// <inheritdoc />
        static Rational IMultiplicativeIdentity<Rational, Rational>.MultiplicativeIdentity
            => One;

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsCanonical(Rational value)
        {
            var canonical = value.CanonicalForm;
            return value.Numerator == canonical.Numerator && value.Denominator == canonical.Denominator;
        }

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsComplexNumber(Rational value)
            => false;

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsEvenInteger(Rational value)
        {
            var canonical = value.CanonicalForm;
            return canonical.Denominator.IsOne && canonical.Numerator.IsEven;
        }

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsFinite(Rational value)
            => true;

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsImaginaryNumber(Rational value)
            => false;

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsInfinity(Rational value)
            => false;

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsInteger(Rational value)
            => value.CanonicalForm.Denominator.IsOne;

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsNaN(Rational value)
            => value.IsNaN;

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsNegative(Rational value)
            => value.Sign < 0;

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsNegativeInfinity(Rational value)
            => false;

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsNormal(Rational value)
            => !value.IsZero && !value.IsNaN;

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsOddInteger(Rational value)
        {
            var canonical = value.CanonicalForm;
            return canonical.Denominator.IsOne && !canonical.Numerator.IsEven;
        }

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsPositive(Rational value)
            => value.Sign > 0;

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsPositiveInfinity(Rational value)
            => false;

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsRealNumber(Rational value)
            => true;

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsSubnormal(Rational value)
            => false;

        /// <inheritdoc />
        static bool INumberBase<Rational>.IsZero(Rational value)
            => value.IsZero;

        private static Rational MaxMagnitudeInner(Rational x, Rational y)
        {
            if (x.IsNaN)
                return NaN;

            if (y.IsNaN)
                return NaN;

            var ax = Abs(x);
            var ay = Abs(y);

            if (ax > ay)
                return x;

            if (ax == ay)
                return x.Sign < 0 ? y : x;

            return y;
        }

        private static Rational MinMagnitudeInner(Rational x, Rational y)
        {
            if (x.IsNaN)
                return NaN;

            if (y.IsNaN)
                return NaN;

            var ax = Abs(x);
            var ay = Abs(y);

            if (ax < ay)
                return x;

            if (ax == ay)
                return x.Sign < 0 ? x : y;

            return y;
        }

        /// <inheritdoc />
        static Rational INumberBase<Rational>.MaxMagnitude(Rational x, Rational y)
            => MaxMagnitudeInner(x, y);

        /// <inheritdoc />
        static Rational INumberBase<Rational>.MaxMagnitudeNumber(Rational x, Rational y)
            => MaxMagnitudeInner(x, y);

        /// <inheritdoc />
        static Rational INumberBase<Rational>.MinMagnitude(Rational x, Rational y)
            => MinMagnitudeInner(x, y);

        /// <inheritdoc />
        static Rational INumberBase<Rational>.MinMagnitudeNumber(Rational x, Rational y)
            => MinMagnitudeInner(x, y);

        /// <inheritdoc />
        static bool INumberBase<Rational>.TryConvertFromChecked<TOther>(TOther value, out Rational result)
            => throw new NotImplementedException();

        /// <inheritdoc />
        static bool INumberBase<Rational>.TryConvertFromSaturating<TOther>(TOther value, out Rational result)
            => throw new NotImplementedException();

        /// <inheritdoc />
        static bool INumberBase<Rational>.TryConvertFromTruncating<TOther>(TOther value, out Rational result)
            => throw new NotImplementedException();

        /// <inheritdoc />
        static bool INumberBase<Rational>.TryConvertToChecked<TOther>(Rational value, out TOther result)
            => throw new NotImplementedException();

        /// <inheritdoc />
        static bool INumberBase<Rational>.TryConvertToSaturating<TOther>(Rational value, out TOther result)
            => throw new NotImplementedException();

        /// <inheritdoc />
        static bool INumberBase<Rational>.TryConvertToTruncating<TOther>(Rational value, out TOther result)
            => throw new NotImplementedException();
    }
}

#endif
