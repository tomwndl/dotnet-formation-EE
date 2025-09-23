<!-- .slide: class="transition bg-blue" -->
# Records

##==##

<!-- .slide: class="with-code max-height"  -->
# [Records](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)

Le code:

```csharp[]
public record Product(string Id, string Reference, decimal Price, string Description);

// Same as
public record Product 
{
    public string Id { get; init; } // init only accept changes during construction
    public string Reference { get; init; }
    public decimal Price { get; init; }
    public string Description {get; init; }

    public Product(string id, string reference, decimal price, string description)
    {
          Id = id;
          Reference = reference;
          Price = price;
          Description = description;
    }
}
```

##==## 

# [Records](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)

Un record est Immutable.
- C'est à dire que les propriétés ne peuvent plus changer après que le Record soit construit.

```csharp
var chocapics = new Product("c1", "Chocapic", (decimal)2.95, "Des céréales fort en chocolat");

// Impossible: compiler will not authorize the following code
// chocapics.Reference = "Chocapics"
```

<br />

<div class="fragment"> 
Par contre il est possible de faire des copies

```csharp
var chocapics = new Product("c1", "Chocapic", (decimal)2.95, "Des céréales fort en chocolat");

var chocapicsPlusChoco = chocapics with { 
    Reference = "c3",
    Description = "Des céréales encore plus fort en chocolat"};
```
</div>

##==##

# [Records](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)


Un record est un value type.
- C'est à dire que lorsqu'on compare 2 record équivalents (mêmes valeurs pour toutes leurs propriétés), ils sont égaux

```csharp
public record Product(string Id, string Reference, decimal Price, string Description);

var chocapics1 = new Product("c1", "Chocapic", (decimal)2.95, "Des céréales fort en chocolat");
var chocapics2 = new Product("c1", "Chocapic", (decimal)2.95, "Des céréales fort en chocolat");

Console.WriteLine(chocapics1 == chocapics2); // Outputs: True
```

Ce même code retourne `False` si Product est une `class` au lieu d'un `record`.

```csharp
public class Product(string Id, string Reference, decimal Price, string Description);

var chocapics1 = new Product("c1", "Chocapic", (decimal)2.95, "Des céréales fort en chocolat");
var chocapics2 = new Product("c1", "Chocapic", (decimal)2.95, "Des céréales fort en chocolat");

Console.WriteLine(chocapics1 == chocapics2); // Outputs: False
```
