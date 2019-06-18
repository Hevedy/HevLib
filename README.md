# HevLib
[Hevedy Library][ProjectURL] for C# (Net Core &amp; Net Framework &amp; Unity 2019) and C++ for Unreal Engine 4

Author: Hevedy\
Version: 0.4.6\


## C#

### Core
 * Console helper.
 * Program help funtions.
 * Math functions and helpers.
 * String conversion tools.
 * Random generators.
 * Hash MD5, SHA1, SHA256 generators.
 * Mutex manager per instance.
 
### IO
 * Assembly helpers.
 * Folder tools.
 * File tools.
 * Bytes reader.
 * Text reader and writer with helpers.
 * INI reader and writer with helpers.
 * JSON reader and writer with helpers.



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

 * If Project Name and Default RootNamespace are different then need to declare aswell "HEVSAFE" into the project "Conditional compilation symbols" then set your project default RootNamespace into the file "HEVInfo.cs" line 7.
```csharp
private static readonly string CUSTOM_NAMESPACE = "YourRootNamespace";
```

### Dependencies
 * INI Parser: https://www.nuget.org/packages/ini-parser/
 * JSON Parser: https://www.nuget.org/packages/Newtonsoft.Json/




## C++ (WIP)

### Core
 * Program help funtions.
 * Math functions and helpers.
 * String conversion tools.
 * Random generators.
 
### IO
 * Folder tools.
 * File tools.
 * Text reader and writer with helpers.
 * INI reader and writer with helpers.



### Installation
Same structure of [Purpleprint Kit 2][PurpleprintKitURL], needs manual split for non UE4 setups.


### Dependencies
None.



[ProjectURL]: https://github.com/Hevedy/HevLib
[PurpleprintKitURL]: https://github.com/Hevedy/PurpleprintKit