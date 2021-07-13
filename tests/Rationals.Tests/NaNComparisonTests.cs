using System.Collections.Generic;
using Xunit;

namespace Rationals.Tests
{
    public class NaNComparisonTests
    {
        [Theory]
        [MemberData(nameof(GetDataForOpComparisonsNaN))]
        public void OpComparisonsNaNLess(Rational a, Rational b) => Assert.False(a < b);

        [Theory]
        [MemberData(nameof(GetDataForOpComparisonsNaN))]
        public void OpComparisonsNaNLessOrEquals(Rational a, Rational b) => Assert.False(a <= b);

        [Theory]
        [MemberData(nameof(GetDataForOpComparisonsNaN))]
        public void OpComparisonsNaNGreater(Rational a, Rational b) => Assert.False(a > b);

        [Theory]
        [MemberData(nameof(GetDataForOpComparisonsNaN))]
        public void OpComparisonsNaNGreaterOrEquals(Rational a, Rational b) => Assert.False(a >= b);

        [Theory]
        [MemberData(nameof(GetDataForOpComparisonsNaN))]
        public void OpComparisonsNaNOpEquals(Rational a, Rational b) => Assert.False(a == b);

        [Theory]
        [MemberData(nameof(GetDataForOpComparisonsNaN))]
        public void OpComparisonsNaNNotEquals(Rational a, Rational b) => Assert.True(a != b);

        public static IEnumerable<object[]> GetDataForOpComparisonsNaN()
        {
            Rational[] samples = { new Rational(1, -1), new Rational(-1), new Rational(0), new Rational(1), new Rational(-1, -1), };
            foreach (var d in samples)
            {
                yield return new object[] { Rational.NaN, d, };
                yield return new object[] { d, Rational.NaN, };
            }
            yield return new object[] { Rational.NaN, Rational.NaN, };
        }

        [Theory]
        [MemberData(nameof(GetDataForEqCmpComparisonsNaN))]
        public void ComparisonsNaNCompareTo(Rational a, Rational b, int cmp) => Assert.Equal(cmp, a.CompareTo(b));

        [Theory]
        [MemberData(nameof(GetDataForEqCmpComparisonsNaN))]
        public void ComparisonsNaNEqual(Rational a, Rational b, int cmp) => Assert.Equal(cmp == 0, a.Equals(b));

        public static IEnumerable<object[]> GetDataForEqCmpComparisonsNaN()
        {
            Rational[] samples = { Rational.NaN, new Rational(-1), new Rational(0), new Rational(1), };
            for (var i = 0; i < samples.Length; i += 1)
            {
                for (var j = 0; j < samples.Length; j += 1)
                {
                    yield return new object[] { samples[i], samples[j], i.CompareTo(j), };
                }
            }
        }
    }
}
