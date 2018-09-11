using System.Numerics;

namespace Rationals
{
    /// <summary>
    /// Rational number.
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Explicit conversion to decimal number, may result in rounding.
        /// </summary>
        public static explicit operator decimal(Rational rational)
        {
            if (rational < 0)
                return -(decimal)-rational;

            decimal result = 0;
            var numerator = rational.Numerator;
            var denominator = rational.Denominator;
            var scale = 1M;
            var previousScale = 0M;
            while (numerator != 0)
            {
                var divided = BigInteger.DivRem(numerator, denominator, out var rem);

                if (scale == 0)
                {
                    if (divided >= 5)
                        result += previousScale; // round up last digit

                    break;
                }

                result += (decimal)divided * scale;

                numerator = rem * 10;
                previousScale = scale;
                scale /= 10;
            }

            return result;
        }

        /// <summary>
        /// Explicit conversion to double number, may result in rounding.
        /// </summary>
        public static explicit operator double(Rational rational) => (double)(decimal)rational;

        /// <summary>
        /// Explicit conversion to float number, may result in rounding.
        /// </summary>
        public static explicit operator float(Rational rational) => (float)(decimal)rational;

        /// <summary>
        /// Approximation from a decimal number. <seealso cref="Approximate(decimal,decimal)"/>.
        /// </summary>
        public static explicit operator Rational(decimal num) => Approximate(num);

        /// <summary>
        /// Approximation from a double number. <seealso cref="Approximate(double,double)"/>.
        /// </summary>
        public static explicit operator Rational(double num) => Approximate(num);

        /// <summary>
        /// Approximation from a float number. <seealso cref="Approximate(float,float)"/>.
        /// </summary>
        public static explicit operator Rational(float num) => Approximate(num);
    }
}