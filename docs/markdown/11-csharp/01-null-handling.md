# [Null reference types](https://learn.microsoft.com/en-us/dotnet/csharp/nullable-references)

C'est l'ensemble des fonctions qui permet de limiter les erreurs `System.NullReferenceException`.

##--##

# Exemple

Cette erreur est généralement levée lorsqu'on "dereference" un objet.

```csharp
string message = "Hello world";
int lenght = message.Length; // deferencing message

User martin = null;
martin.Address; // Will throw a System.NullReferenceException
```

##--##

# Mettre en place les Warnings du compilateur

1. Dans le `.csproj`

```csharp
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
- Les parties du code qui ne sont pas explicitement gérées produiront un Warning.

##==##

# Exercice

**TODO** legacy code, puis passer à `<Nullable>warnings</Nullable>` avant de passer à `enabled`
