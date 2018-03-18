using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Rationals
{
    /// <summary>
    /// Rational number.
    /// </summary>
    public partial struct Rational
    {
        private static IEnumerable<BigInteger> ExpandToContinuedFraction(decimal d)
        {
            var wholePart = Math.Truncate(d);
            var fractionPart = d - wholePart;
            yield return (BigInteger)wholePart;

            while (fractionPart != 0)
            {
                d = 1m / fractionPart;

                wholePart = Math.Truncate(d);
                fractionPart = d - wholePart;
                yield return (BigInteger)wholePart;
            }
        }

        private static IEnumerable<BigInteger> ExpandToContinuedFraction(double d)
        {
            var wholePart = Math.Truncate(d);
            var fractionPart = d - wholePart;
            yield return (BigInteger)wholePart;

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (fractionPart != 0)
            {
                d = 1d / fractionPart;

                wholePart = Math.Truncate(d);
                fractionPart = d - wholePart;
                yield return (BigInteger)wholePart;
            }
        }

        private static float TruncateFloat(float d)
        {
            if (d.Equals(float.PositiveInfinity))
                return float.PositiveInfinity;

            if (d.Equals(float.NegativeInfinity))
                return float.NegativeInfinity;

            if (d.Equals(float.NaN))
                return float.NaN;

            return (int)d;
        }

        private static IEnumerable<BigInteger> ExpandToContinuedFraction(float d)
        {
            var wholePart = TruncateFloat(d);
            var fractionPart = d - wholePart;
            yield return (BigInteger)wholePart;

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (fractionPart != 0)
            {
                d = 1f / fractionPart;

                wholePart = TruncateFloat(d);
                fractionPart = d - wholePart;
                yield return (BigInteger)wholePart;
            }
        }

        /// <summary>
        /// Approximates given decimal number as a rational number. If a higher tolerance is given, simpler decimal might be returned.
        /// </summary>
        /// <param name="input">Input decimal</param>
        /// <param name="tolerance">Optional tolerance</param>
        /// <returns>Output rational</returns>
        public static Rational Approximate(decimal input, decimal tolerance = 0)
        {
            if (tolerance < 0) throw new ArgumentOutOfRangeException(nameof(tolerance));
            var continuedFraction = ExpandToContinuedFraction(input);

            var sequence = new List<BigInteger>();
            var previousDifference = decimal.MaxValue;
            var currentNumber = Zero;
            foreach (var coefficient in continuedFraction)
            {
                sequence.Add(coefficient);
                currentNumber = FromContinuedFraction(sequence);
                var currentDifference = Math.Abs((decimal)currentNumber - input);

                if (currentDifference <= tolerance)
                {
                    break;
                }
                if (currentDifference < previousDifference)
                {
                    previousDifference = currentDifference;
                }
                else
                {
                    break;
                }
            }
            return currentNumber;
        }

        /// <summary>
        /// Approximates given double number as a rational number. If a higher tolerance is given, simpler double might be returned.
        /// </summary>
        /// <param name="input">Input double</param>
        /// <param name="tolerance">Optional tolerance</param>
        /// <returns>Output rational</returns>
        public static Rational Approximate(double input, double tolerance = 0)
        {
            if (tolerance < 0) throw new ArgumentOutOfRangeException(nameof(tolerance));
            var continuedFraction = ExpandToContinuedFraction(input);

            var sequence = new List<BigInteger>();
            var previousDifference = double.MaxValue;
            var currentNumber = Zero;
            foreach (var coefficient in continuedFraction)
            {
                sequence.Add(coefficient);
                currentNumber = FromContinuedFraction(sequence);
                var currentDifference = Math.Abs((double)currentNumber - input);
                Debug.WriteLine($"{currentNumber} {currentDifference}");
                if (currentDifference <= tolerance)
                {
                    break;
                }
                if (currentDifference < previousDifference)
                {
                    previousDifference = currentDifference;
                }
                else
                {
                    break;
                }
            }
            return currentNumber;
        }

        /// <summary>
        /// Approximates given float number as a rational number. If a higher tolerance is given, simpler float might be returned.
        /// </summary>
        /// <param name="input">Input float</param>
        /// <param name="tolerance">Optional tolerance</param>
        /// <returns>Output rational</returns>
        public static Rational Approximate(float input, float tolerance = 0)
        {
            if (tolerance < 0) throw new ArgumentOutOfRangeException(nameof(tolerance));
            var continuedFraction = ExpandToContinuedFraction(input);

            var sequence = new List<BigInteger>();
            double previousDifference = float.MaxValue;
            var currentNumber = Zero;
            foreach (var coefficient in continuedFraction)
            {
                sequence.Add(coefficient);
                currentNumber = FromContinuedFraction(sequence);
                var currentDifference = Math.Abs((float)currentNumber - input);

                if (currentDifference <= tolerance)
                {
                    break;
                }
                if (currentDifference < previousDifference)
                {
                    previousDifference = currentDifference;
                }
                else
                {
                    break;
                }
            }
            return currentNumber;
        }
    }
}