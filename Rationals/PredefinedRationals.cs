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
        public static readonly Rational Zero = new Rational(0, 1);
        public static readonly Rational One = new Rational(1, 1);
    }
}