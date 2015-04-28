# WildcardMatch

## Why

I just needed a wildcard match method is some other project and found no NuGet package for it. :sweat:

## How
The library is available as a [NuGet package](https://www.nuget.org/packages/WildcardMatch)  
Using it is simple:
```csharp
using WildcardMatch;

// the WildcardMatch is a string extension method
bool match = "*.*".WildcardMatch("thisfile.txt");
```
