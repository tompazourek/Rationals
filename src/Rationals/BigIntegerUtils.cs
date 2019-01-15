using System.Numerics;

namespace Rationals
{
    internal static class BigIntegerUtils
    {
        /// <summary>
        /// Returns the number of digits of the given number
        /// </summary>
        public static int GetNumberOfDigits(BigInteger x)
        {
            x = BigInteger.Abs(x);

            var digits = 0;
            while (x > 0)
            {
                digits++;
                x /= 10;
            }

            return digits;
        }
    }
}