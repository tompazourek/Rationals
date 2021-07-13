namespace Rationals
{
    /// <summary>
    /// Rational number.
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Zero
        /// </summary>
        public static readonly Rational Zero = new Rational(0, 1);

        /// <summary>
        /// One
        /// </summary>
        public static readonly Rational One = new Rational(1, 1);

        /// <summary>
        /// Not a number (internally 0/0)
        /// </summary>
        public static readonly Rational NaN = default;
    }
}