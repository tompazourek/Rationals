using System;

namespace Rationals
{
    /// <summary>
    /// Rational number.
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Takes the whole part of the rational number.
        /// </summary>
        [CLSCompliant(false)]
        public static explicit operator sbyte(Rational rational) => (sbyte)rational.WholePart;

        /// <summary>
        /// Takes the whole part of the rational number.
        /// </summary>
        public static explicit operator byte(Rational rational) => (byte)rational.WholePart;

        /// <summary>
        /// Takes the whole part of the rational number.
        /// </summary>
        [CLSCompliant(false)]
        public static explicit operator ushort(Rational rational) => (ushort)rational.WholePart;

        /// <summary>
        /// Takes the whole part of the rational number.
        /// </summary>
        public static explicit operator short(Rational rational) => (short)rational.WholePart;

        /// <summary>
        /// Takes the whole part of the rational number.
        /// </summary>
        [CLSCompliant(false)]
        public static explicit operator uint(Rational rational) => (uint)rational.WholePart;

        /// <summary>
        /// Takes the whole part of the rational number.
        /// </summary>
        public static explicit operator int(Rational rational) => (int)rational.WholePart;

        /// <summary>
        /// Takes the whole part of the rational number.
        /// </summary>
        [CLSCompliant(false)]
        public static explicit operator ulong(Rational rational) => (ulong)rational.WholePart;

        /// <summary>
        /// Takes the whole part of the rational number.
        /// </summary>
        public static explicit operator long(Rational rational) => (long)rational.WholePart;
    }
}