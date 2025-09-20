# [Null reference types](https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references)

- C'est l'ensemble des fonctions qui permettent de limiter les erreurs de type 
<!-- .element: class="list-fragment" -->
  `System.NullReferenceException`
- Cette erreur est généralement levée lorsqu'on "dereference" un objet (en utilisant le "**`.`**")
  ```csharp
  string message = "Hello world";
  int lenght = message.Length; // deferencing message

  User martin = null;
  martin.Address; // Will throw a System.NullReferenceException
  ```

##==##

<!-- .slide: class="with-code max-height"  -->
Exemples des operateurs nullables:
```csharp[1-22|1-7|9-10|12-14|16-18|20-22|1-22]
public class Person
{
    public string? Name { get; set; } 
    public Address? Address { get; set; }
}

public record Address(string Street);

var person1 = new Person { Name = "Alice" };
var person2 = new Person { Name = null, Address = new Address("4 avenue de l'Europe") };

// Null-Conditional operator
string? street1 = person1.Address?.Street; // will be null because person1.Address is null
string? street2 = person2.Address?.Street; // will be "4 avenue de l'Europe"

// Null-Coalescing operator
Console.WriteLine($"Street 1: {street1 ?? "No Street"} "); // Output: "Street 1 : No Street"
Console.WriteLine($"Street 2: {street2 ?? "No Street"} "); // Output: "Street 2 : 4 avenue de l'Europe"

// Null-Forgiving operator (no compiler warnings)
string streetName2 = person2.Address!.Street; // We're telling the compiler we are sure that person2.Address is defined
string streetName1 = person1.Address!.Street; // Throws NullReferenceException
```

##==##

# Mettre en place les Warnings du compilateur

1. Dans le `.csproj`

```csharp[1-11|7]
<Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
        <TargetFramework>net9.0</TargetFramework>

        <!-- ... -->

        <Nullable>enable</Nullable>
    </PropertyGroup>

    <!-- ... -->
</Project>
```

2. Effets sur l'analyse static du code:

- Les reference types seront considérés **non nullable**
- Il faut rajouter un **`?`** pour rendre le type **nullable**
- Les parties du code qui ne sont pas explicitement gérées produiront un **Warning**
<!-- .element: class="list-fragment" -->

##==##

# Exercice

Suivre les instructions des commentaires numérotés du code.

TODO: rajouter le lien vers le repo du code
