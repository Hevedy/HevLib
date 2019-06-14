# HevLib
Hevedy Library for C# (Net Core &amp; Net Framework &amp; Unity 2019) and C++ for Unreal Engine 4


## C#

### Installation
Include the CS folder files into your project, then include the namespace into the files of your project.
```csharp
using HevLib;
```
You will need to include the dependencies aswell to your project.

If you want to use the functions:
```csharp
AssemblyStringRead()
ResourcesTextReadString()
ResourcesTextReadStringArray()
```
 * If Project Name and Default RootNamespace are equal then only need to declare "HEVSAFE" into the project "Conditional compilation symbols".

 * If Project Name and Default RootNamespace are different then need to declare aswell "HEVSAFE" into the project "Conditional compilation symbols" then set your project default RootNamespace into the file "HEVProgram.cs" line 44.
```csharp
private static readonly string CustomNamespace = "YourRootNamespace";
```

### Dependencies
 * INI Parser: https://www.nuget.org/packages/ini-parser/
 * JSON Parser: https://www.nuget.org/packages/Newtonsoft.Json/
