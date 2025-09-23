<!-- .slide: class="transition bg-blue" -->
# Autres

##==##

# File scoped namespaces


On peut écrire:
```csharp
namespace MyNamespace;

public class Product 
{

}
```

Au lieu de:

```csharp
namespace MyNamespace 
{
    public class Product 
    {

    }
}
```

L'ensemble du fichier sera considéré comme faisant partie du namespace.

##==##

# Global usings

Dans un fichier `.cs`

```csharp
global using System;
global using Xunit;
```

Ou directement dans le `.csproj`

```xml
<ItemGroup>
  <Using Include="System" />
  <Using Include="Xunit" />
</ItemGroup>
```

Cela permet d'éviter d'écrire ( `using System;` ) dans tous les fichiers.

##==##

# Les collections

```csharp
List<int> emptyNumbers = []; // empty list

int[] numbers= [1,2,3,4,5,6,7,8,9];

int[] numbers2 = [1,2,3];
int[] numbers3 = [4,5];
int[] sumNumbers = [..numbers2, ..numbers3]; // Contains: 12345

int eight = numbers[^2];                     //Contains: 8

int[] twoToFive = numbers[1..5];             //Contains: 2345
int[] twoToEnd = numbers[1..];               //Contains: 23456789

```

##==## 

# Switch-expression

```csharp
public enum Size { Small, Medium, Large }
```

```csharp
// Switch traditionnel
public int GetPriceTraditional(Size size)
{
    switch (size)
    {
        case Size.Small: 
            return 10;
        case Size.Medium: 
            return 15;
        case Size.Large: 
            return 20;
        default: 
            return 0;
    }
}
```

```csharp
// Switch expression 
public int GetPriceModern(Size size) 
    => size switch
    {
        Size.Small => 10,
        Size.Medium => 15,
        Size.Large => 20,
        _ => 0
    };
```

##==## 

# Pattern-Matching

```csharp
string Describe(List<int> list) => list switch
{
    [] => "vide",
    [var x] => $"unique: {x}",
    [var x, _] => $"début: {x}",
    _ => throw new Exception("invalid");
};
```

```csharp
bool IsValidNumber(object obj) => obj is int n && n > 0;
```

```csharp
record Point(int X, int Y);
string WhereIs(Point p) => p switch
{
    { X: 0, Y: 0 } => "origine",
    { X: 0 } => "axe Y",
    { Y: 0 } => "axe X",
    _ => "ailleurs"
};
```

```csharp
string GetQuadrant((int x, int y) point) => point switch
{
    (> 0, > 0) => "NE",
    (< 0, > 0) => "NO",
    (< 0, < 0) => "SO",
    (> 0, < 0) => "SE",
    _ => "Centre"
};
```
