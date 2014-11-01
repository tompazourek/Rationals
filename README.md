![Rationals logo](https://raw.githubusercontent.com/tompazourek/Rationals/master/assets/logo_32.png) Rationals .NET
==============

*Implementation of rational number arithmetics for .NET.*

[![Build status](https://ci.appveyor.com/api/projects/status/8w3d71q8fr65gntb)](https://ci.appveyor.com/project/tompazourek/rationals)

```csharp
Rational left = (Rational) 1 / 2;
Rational right = (Rational) 1 / 4;

Rational sum = left + right; // equals to: 3 / 4
```

Download
--------

Binaries of the last build can be downloaded on the [AppVeyor CI page of the project](https://ci.appveyor.com/project/tompazourek/rationals/build/artifacts).

The library is also [published on NuGet.org](https://www.nuget.org/packages/Rationals/), install using:

```
PM> Install-Package Rationals
```


Supported features
------------------

- **implicit conversions** - rationals integrate seamlessly with other number types
- **unlimited precision** - rationals use `BigInteger` inside
- **canonical form** - each rational can have its canonical form (irreducible fraction where denominator is always positive)
- **comparison & equality**
- **multiple formatting options** - `ToString("C")` (canonical form), `ToString("W")` (whole + fractional part), or normal fraction format
