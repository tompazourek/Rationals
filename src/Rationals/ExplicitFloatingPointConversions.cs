using System.Numerics;

namespace Rationals
{
    public partial struct Rational
    {
        public static explicit operator decimal(Rational rational)
        {
            if (rational < 0)
                return -(decimal)-rational;

            decimal result = 0;
            var numerator = rational.Numerator;
            var denominator = rational.Denominator;
            var scale = 1M;
            var previousScale = 0M;
            while (numerator > 0)
            {
                BigInteger rem;
                var divided = BigInteger.DivRem(numerator, denominator, out rem);

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

        public static explicit operator double(Rational rational)
        {
            return (double)(decimal)rational;
        }

        public static explicit operator float(Rational rational)
        {
            return (float)(decimal)rational;
        }

        public static explicit operator Rational(decimal num)
        {
            return Approximate(num);
        }

        public static explicit operator Rational(double num)
        {
            return Approximate(num);
        }

        public static explicit operator Rational(float num)
        {
            return Approximate(num);
        }
    }
}