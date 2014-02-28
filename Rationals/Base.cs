﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Rationals
{
    public partial struct Rational
    {
        private readonly BigInteger _denominator;
        private readonly BigInteger _numerator;

        public Rational(BigInteger whole)
            : this(whole, 1)
        {
        }

        internal Rational(ref BigInteger numerator, ref BigInteger denominator)
        {
            if (denominator == 0)
                throw new ArgumentOutOfRangeException("denominator", "Denominator cannot be zero.");

            _numerator = numerator;
            _denominator = denominator;
        }

        public Rational(BigInteger numerator, BigInteger denominator)
        {
            if (denominator == 0)
                throw new ArgumentOutOfRangeException("denominator", "Denominator cannot be zero.");

            _numerator = numerator;
            _denominator = denominator;
        }

        public bool IsZero
        {
            get { return _numerator.IsZero; }
        }

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

        public BigInteger Numerator
        {
            get { return _numerator; }
        }

        public BigInteger Denominator
        {
            get { return _denominator; }
        }
    }
}