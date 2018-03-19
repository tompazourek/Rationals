# ![Rationals logo](https://raw.githubusercontent.com/tompazourek/Rationals/master/assets/logo_32.png) Rationals .NET

*Implementation of rational number arithmetic for .NET with arbitrary precision.*

[![Build status](https://img.shields.io/appveyor/ci/tompazourek/rationals.svg)](https://ci.appveyor.com/project/tompazourek/rationals)
[![Tests](https://img.shields.io/appveyor/tests/tompazourek/rationals.svg)](https://ci.appveyor.com/project/tompazourek/rationals/build/tests)
[![NuGet downloads](https://img.shields.io/nuget/dt/Rationals.svg)](https://www.nuget.org/packages/Rationals/)

```csharp
var left = (Rational) 1 / 2;
var right = (Rational) 1 / 4;

var sum = left + right; // equals to: 3 / 4
```

## Download

Binaries of the last build can be downloaded on the [AppVeyor CI page of the project](https://ci.appveyor.com/project/tompazourek/rationals/build/artifacts).

The library is also [published on NuGet.org](https://www.nuget.org/packages/Rationals/), install using:

```
PM> Install-Package Rationals
```

The library can be used since .NET 4.6 or .NET Standard 1.4. It's also CLS compliant to allow use in VB.NET.


## Features

- **implicit conversions** - rationals integrate seamlessly with other number types
- **unlimited precision** - rationals use `BigInteger` inside
- **canonical form** - each rational can have its canonical form (irreducible fraction where denominator is always positive)
- **comparison & equality**
- **separate whole and fractional part** - any rational number can be separated into a whole part (integer quotient aka result of integer division) and fractional part (reminder of the integral division aka result of modulo operation)
- **continued fraction expansion** - expand rational numbers to continued fraction (sequence of coefficients), construct rational numbers from sequence of continued fraction coefficients
- **rational number approximation** - approximate floating point numbers (decimal, double, float) as rational numbers with customizable tolerance
- **multiple formatting options** - `ToString("C")` (canonical form), `ToString("W")` (whole + fractional part), or normal fraction format

## Documentation

The Rationals library is an alternative to [BigRational found in BCL](https://github.com/MicrosoftArchive/bcl/tree/master/Libraries/BigRational). Its implementation is quite trivial, it doesn't do any low-level magic to make sure it's the best performer. But it should be easy to use and has few nice features.  

### Constructors

There are just two constructors to rational numbers. For most scenarios, you might not need to use those constructors directly and rely on the typecasting operators.

```csharp
// constructor from a whole BigInteger number
var p = new Rational(new BigInteger(3));

// constructor from a BigInteger numerator and denominator
var p = new Rational(new BigInteger(1), new BigInteger(2));
```

### Implicit conversions from other types

Rationals are much easier created by implicit conversions. There exist implicit conversions from: `int`, `uint`, `short`, `ushort`, `long`, `ulong`, `byte`, `sbyte`, and `BigInteger`.

```csharp
Rational p = 5;
```

### Explicit conversions from other types

There exist explicit operator conversions from `decimal`, `double`, and `float`.

```csharp
var p = (Rational) 0.5; // equals to: 1/2
```

Note that sometimes you might not get very nice rational numbers as the output.

```csharp
var p = (Rational) 0.71428571428M; // equals to: 71428571428/100000000000 (or 17857142857/25000000000 simplified)
```

However, `0.71428571428` is almost exactly `5/7`. To actually read the number as `5/7`, you have to use the `Rational.Approximate` function and provide some tolerance.

### Approximation

Approximation tries to find the "simplest" rational number for given decimal/floating point number.

The library supports approximation of `decimal`, `double`, and `float` numbers. An optional second `tolerance` parameter might be given.

```csharp
var p1 = Rational.Approximate(0.71428571428M);                            // 17857142857/25000000000
var p2 = Rational.Approximate(0.71428571428M, tolerance: 0.00000000001M); // 5/7

var q1 = Rational.Approximate(0.3333);         // 3333/10000
var q2 = Rational.Approximate(0.3333, 0.0001); // 1/3 
```

### Continuous fraction expansion

Rational numbers can be expanded into [Continuous fractions](https://en.wikipedia.org/wiki/Continuous_fractions). The library can expand any rational number into a such a fraction, the result of this is the sequence of those coefficients.

For example, the rational number `649/200` can be represented as a continuous fraction with coefficients `3, 4, 12, 4`, which when used in the formula `3 + 1/(4 + 1/(12 + 1/4))` give the result `649/200`.

```csharp
// compute rational number from continuous fraction coefficients
var p = Rational.FromContinuedFraction(new BigInteger[] { 3, 4, 12, 4 }); // 649/200

// find continuous fraction coefficients for a rational number
var coefficients = ((Rational) 10 / 7).ToContinuedFraction(); // 1, 2, 3

```

### Reducing fractions, canonical form

The library supports reducing (simplifying) fractions. To reduce a fraction, you can use the `CanonicalForm` property. That returns a rational number that's irreducible, and where also the denominator is always positive. Canonical form of zero is `0/1`.

```csharp
var p1 = ((Rational) 9 / 12).CanonicalForm;    // 3/4
var p2 = ((Rational) (-9) / 12).CanonicalForm; // -3/4
var p3 = ((Rational) 9 / -12).CanonicalForm;   // -3/4
var p4 = ((Rational) 0 / -12).CanonicalForm;   // 0/1
```  

There should always be just one canonical form of any rational number.

### Whole and fractional parts

A rational number `x/y` can be thought of as having a whole and fractional part `a + b/c`.

For example, the `14/4` can be written as `3 + 2/4` where `3` is the whole part, and `2/4` is the fractional part.

```csharp
var r1 = (Rational)14 / 4;
BigInteger a1 = r1.WholePart;   // 3
Rational bc1 = r1.FractionPart; // 2/4

var r2 = (Rational)(-49) / 10;
BigInteger a2 = r2.WholePart;   // -5
Rational bc2 = r2.FractionPart; // 1/10
```

### Explicit conversions to other types

Rational numbers can be explicitly converted to `decimal`, `double`, and `float` decimal numbers. Note that the `Rational` type has unlimited precision where the types to convert to are limited. As a result of that, there might be some rounding occurring or an overflow.

```csharp
var p1 = (Rational) 1 / 2;
var x1 = (decimal) p1; // 0.5

var p2 = (Rational) 1 / 3;
var x2 = (double) p2; // 0.33333333333333337
```  

Rational numbers can also be explicitly converted to whole number types `int`, `uint`, `short`, `ushort`, `long`, `ulong`, `byte`, and `sbyte`. For these, we only take the whole part of the fractional number:

```csharp
var p1 = (Rational) 3 / 2;
var x1 = (int) p1; // 1

var p2 = (Rational) (-3) / 2;
var x2 = (int) p2; // -2
```

### BigInteger inspired properties

There are several other useful properties of the rational number that have similar equivalents in BigInteger:

- `.IsZero` returns true if the number is equal to 0
- `.IsOne` returns true if the is equal to 1
- `.Sign` returns an `int` number (negative, positive, or zero) that indicates the sign of the number
- `.IsPowerOfTwo` returns true if the number is a power of two

### Overloaded operators

Rational numbers have all the common numeric operators overloaded so that their use in C# is very idiomatic. All of these operators should behave as expected: `+`, unary `-`, binary `-`, `*`, `/`, `++`, `--`, `==`, `!=`, `<`, `>`, `<=`, `>=`.

```csharp
var p = (Rational) 3 / 4;
var q = (Rational) 1 / 3;
var result = p / q; // 9/4
```

### Mathematical operations

The `Rational` class has a range of static methods that implement common mathematical operations. Some of these can be used through the corresponding overloaded operators.

```csharp
var p = (Rational) 3 / 4;
var q = (Rational) 1 / 3;

Rational.Invert(p);      // 4/3
Rational.Negate(p);      // -3/4
Rational.Add(p, q);      // 13/12
Rational.Subtract(p, q); // 5/12
Rational.Multiply(p, q); // 3/12
Rational.Divide(p, q);   // 9/4
Rational.Pow(p, 2);      // 9/16
Rational.Abs(p);         // 3/4
Rational.Log10(p);       // -0.12493873660829985
Rational.Log(p);         // -0.28768207245178079 (base is e)
Rational.Log(p, 2);      // -0.4150374992788437
Rational.Root(p, 2);     // 0.8660254037844386 (square root, result is double)
Rational.RationalRoot((Rational) 9 / 16, 2); // 3/4 (square root, result is rational)
```

### Computing magnitude

Magnitude of a number can be thought of as the exponent of 10 if the number was written in scientific notation.

- Magnitude of 0 is 0.
- Magnitude of 5 is 0.
- Magnitude of 12 is 1.
- Magnitude of 3988222 is 6.
- Magnitude of 0.2223 is -1.
- Magnitude of 0.04 is -2.

To find the magnitude of rational number, use the `.Magnitude` property.

```csharp
var p = (Rational) 1 / 11;
int magnitude = p.Magnitude; // -2 
```

### Significant digits

Every rational number has a `Digits` property that enumerates all significant digits of the rational number. You might want to use this together with the `Magnitude` property.

Keep in mind that the result of this might be infinite. For example, for the rational number `1/3`, it will return an infinite sequence of threes.

```csharp
((Rational) 200).Digits;                // 2
((Rational) 1/2).Digits;                // 5
((Rational) 1/3).Digits.Take(10);       // 3, 3, 3, 3, 3, 3, 3, 3, 3, 3
((Rational) (-213)/31).Digits.Take(10); // 6, 8, 7, 0, 9, 6, 7, 7, 4, 1
((Rational) 0).Digits;                  // 0
```
 
### Formatting

Rational numbers can be formatted in three formats passed into the `.ToString()` method:

- `"F"` (default, normal fraction)
	- whole number will be formated as a whole number, e.g. `10/5` as `2`.
	- fractional number will be formatted as it is, e.g. `9/5` as `9/5`.
- `"C"` (canonical fraction)
	- number will be converted to canonical form, and then formatted as `"F"`.
- `"W"` (whole + fractional part)`
	- number will be separated as a whole and fractional part and formatted with a space between them, e.g. `9/5` as `1 4/5`.

### Parsing

The `Rational` class has 4 different static methods for parsing strings: `.Parse`, `.TryParse`, `.ParseDecimal`, and `.TryParseDecimal`.

The `.Parse` and `.TryParse` methods accept strings in two formats:

- Fractional format (e.g. `3/4`)
- Whole fractional format (e.g. `5 1/2`)

The `.ParseDecimal` and `.TryParseDecimal` methods try to parse the string into `decimal` type and then convert it to `Rational`. An optional `tolerance` parameter might be given to parse nicer fractions, as it uses the `Approximate` function inside.

```csharp
var p1 = Rational.Parse("7/5");        // 7/5
var p2 = Rational.Parse("1 2/5");      // 7/5
var p3 = Rational.ParseDecimal("1.4"); // 7/5
```
