using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public partial struct Rational
    {
        /// <summary>
        /// True if the number is equal to zero
        /// </summary>
        public bool IsZero
        {
            get { return _numerator.IsZero; }
        }

        /// <summary>
        /// True if the number is equal to one
        /// </summary>
        public bool IsOne
        {
            get { return _numerator == _denominator; }
        }

        /// <summary>
        /// Gets a number that indicates the sign (negative, positive, or zero) of the rational number
        /// </summary>
        public int Sign
        {
            get { return _numerator.Sign * _denominator.Sign; }
        }

        /// <summary>
        /// Indicates whether the value of the rational number is a power of two.
        /// </summary>
        public bool IsPowerOfTwo { get { return _numerator.IsPowerOfTwo && _denominator.IsPowerOfTwo; } }
    }
}