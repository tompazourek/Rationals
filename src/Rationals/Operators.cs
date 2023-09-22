﻿using System;

namespace Rationals
{
    /// <summary>
    /// Rational number.
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Overload of the + operator.
        /// </summary>
        public static Rational operator +(Rational left, Rational right) => Add(left, right);

        /// <summary>
        /// Overload of the unary - operator.
        /// </summary>
        public static Rational operator -(Rational p) => Negate(p);

        /// <summary>
        /// Overload of the binary - operator.
        /// </summary>
        public static Rational operator -(Rational left, Rational right) => Subtract(left, right);

        /// <summary>
        /// Overload of the * operator.
        /// </summary>
        public static Rational operator *(Rational left, Rational right) => Multiply(left, right);

        /// <summary>
        /// Overload of the / operator.
        /// </summary>
        public static Rational operator /(Rational left, Rational right) => Divide(left, right);

        /// <summary>
        /// Overload of the ++ operator.
        /// </summary>
        public static Rational operator ++(Rational p) => p + One;

        /// <summary>
        /// Overload of the -- operator.
        /// </summary>
        public static Rational operator --(Rational p) => p - One;

        /// <summary>
        /// Overload of the == operator.
        /// </summary>
        public static bool operator ==(Rational left, Rational right) => !left.IsNaN && !right.IsNaN && left.Equals(right);

        /// <summary>
        /// Overload of the != operator.
        /// </summary>
        public static bool operator !=(Rational left, Rational right) => !(left == right);

        /// <summary>
        /// Overload of the &lt; operator.
        /// </summary>
        public static bool operator <(Rational left, Rational right) => !left.IsNaN && !right.IsNaN && left.CompareTo(right) < 0;

        /// <summary>
        /// Overload of the &gt; operator.
        /// </summary>
        public static bool operator >(Rational left, Rational right) => !left.IsNaN && !right.IsNaN && left.CompareTo(right) > 0;
        
        /// <summary>
        /// Overload of the &lt;= operator.
        /// </summary>
        public static bool operator <=(Rational left, Rational right) => !left.IsNaN && !right.IsNaN && left.CompareTo(right) <= 0;

        /// <summary>
        /// Overload of the &gt;= operator.
        /// </summary>
        public static bool operator >=(Rational left, Rational right) => !left.IsNaN && !right.IsNaN && left.CompareTo(right) >= 0;

        /// <summary>
        /// Overload of the % operator.
        /// </summary>
        public static Rational operator %(Rational left, Rational right)
            => throw new NotImplementedException();

        /// <summary>
        /// Overload of the unary + operator.
        /// </summary>
        public static Rational operator +(Rational value)
            => new(+value.Denominator, +value.Numerator);
    }
}
