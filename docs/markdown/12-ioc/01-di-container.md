<!-- .slide: class="transition bg-blue" -->

# L'injection de dépendances

##==##

# L'injection de dépendances

1. Une dépendance est lorsqu'une classe a besoin d'une autre classe.
2. Une dépendance peut être plus ou moins forte

##==##

Dépendance forte (composition)

```csharp
public class Engine{}

public class Car
{
    private Engine myMotor;

    public Car() => myMotor = new Engine();
}
```

Dépendance moyenne (aggregation)

```csharp
public class Engine{}

public class Car
{
    private Engine myMotor;

    public Car(Engine engine) => myMotor = engine;
}

```

Dépendance faible (association)

```csharp
public class Engine{}

public class Car
{
    public void Start(Engine engine) => engine.Vrouum();
}
```

##==##

# Conteneur d'injection de dépendances

Initialisation pour que l'application puisse s'executer. Manuellement c'est complexe:

- ordre des initialisations
- dépendances imbriquées
- multiples dépendances
- cycle de vie

```csharp
var tyre = new Tyre()
var wheel = new Wheel(tyre);
var motor = new Motor("Diesel");
var car = new Car(motor, wheel)
```

Automatiquement: avec un conteneur d'injection des dépendances

```csharp
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new UserService());
// or better
builder.Services.AddSingleton<UserService>();
// or even better
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();
```

##==##

# Cycle de vie

- Transient = **nouvelle** instance à **chaque appel**
- Singleton = **toujours la même instance** pendant toute la durée de vie de l'application
- Scoped = même instance pour la **durée d'une requête**
<!-- .element: class="list-fragment" -->

```csharp
services.AddTransient<T>();
services.AddScoped<T>();
services.AddSingleton<T>();
```

##==##

# Conteneur d'injection de dépendances

Résumé:

- gère automatiquement les dépendances
- gère automatiquement le cycle de vie des objets
- permet de faire une résolution au démarrage, ou uniquement au moment de l'appel
<!-- .element: class="list-fragment" -->

##==##

# Astuce pour les bibliothèques

Utiliser une méthode d'extension pour regrouper les services propres à une bibliothèque

```csharp[1-17|1-10|15|1-17]
public static class DependencyInjection
{
    public static IServiceCollection AddDatabaseDependencies(this IServiceCollection services)
    {
        // services.AddTransient<T>();
        // services.AddScoped<T>();
        // services.AddSingleton<T>();
        return services;
    }
}

// In Program.cs
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseDependencies();

var app = builder.Build();
```

##==##

<!-- .slide: class="exercice" -->

# Exercice

[https://github.com/tomwndl/dotnet-formation-EE](https://github.com/tomwndl/dotnet-formation-EE)

```bash
# Clone
git clone https://github.com/tomwndl/dotnet-formation-EE.git

# Go to folder
cd code-examples/DependencyInjection
```

<br />
Toutes les instructions sont marquées dans le fichier `Program.cs` avec des commentaires qui commences par `//TODO-`
