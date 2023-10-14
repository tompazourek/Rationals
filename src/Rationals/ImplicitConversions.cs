using System;
using System.Numerics;

namespace Rationals
{
    /// <summary>
    /// Rational number.
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Creates rational number from sbyte number.
        /// </summary>
        [CLSCompliant(false)]
        public static implicit operator Rational(sbyte n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Creates rational number from byte number.
        /// </summary>
        public static implicit operator Rational(byte n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Creates rational number from short number.
        /// </summary>
        public static implicit operator Rational(short n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Creates rational number from ushort number.
        /// </summary>
        [CLSCompliant(false)]
        public static implicit operator Rational(ushort n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Creates rational number from int number.
        /// </summary>
        public static implicit operator Rational(int n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Creates rational number from uint number.
        /// </summary>
        [CLSCompliant(false)]
        public static implicit operator Rational(uint n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Creates rational number from long number.
        /// </summary>
        public static implicit operator Rational(long n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Creates rational number from ulong number.
        /// </summary>
        [CLSCompliant(false)]
        public static implicit operator Rational(ulong n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Creates rational number from BigInteger number.
        /// </summary>
        public static implicit operator Rational(BigInteger n) => !n.IsZero ? new Rational(n) : Zero;
    }
}
