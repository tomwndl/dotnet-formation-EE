<!-- .slide: class="transition-bg-sfeir-2" -->

# Le couplage

##==##

# L'importance des interfaces

Lorsqu'une classe (celle que l'on veut tester) en utilise une autre, il est conseillé **d'utiliser une interface** et **d'injecter cette dépendance** (à l'aide du constructeur par exemple).

##==##

# Couplage fort: composition (au sens UML)

```csharp[]
public class Car
{
    private readonly Diesel _diesel;

    public Car() { _diesel = new Diesel(); }

    //...
}
```

- ❌ On utilise directement un moteur Diesel.
  - Impossible d'utiliser un moteur Essence ou un moteur de Test par exemple.
- ❌ Un vrai moteur Diesel est forcément créé dès qu'on créé la voiture. On ne peut pas le changer.
  - Impossible d'utiliser la voiture sans moteur (lorsqu'on veut vérifier l'alimentation de la batterie par exemple).

##==##

# Couplage moyen: dépendance à une classe

```csharp[]
public class Cary
{
    private readonly Diesel _diesel;

    public Car(Diesel diesel) { _diesel = diesel; }

    //...
}
```

- ❌ On utilise directement un moteur Diesel.
  - Impossible d'utiliser un moteur Essence ou un moteur de Test par exemple.
- ✔ On peut changer de moteur.
  - On peut facilement préparer un moteur pour ensuite l'utiliser (un plus ancien qui ne fonctionne plus, ou un plus récent qui est plus performant)

##==##

# Couplage faible: dépendance à une interface

```csharp[]
public class Car
{
    private IEngine _engine;

    public Car (IEngine engine) { _engine = engine; }

    //...
}
```

- ✔ On peut choisir le type de moteur.
  - On peut facilement choisir un moteur essence ou un moteur électrique selon les besoins.
- ✔ On peut changer de moteur.
  - On peut facilement préparer un moteur pour ensuite l'utiliser (un plus ancien qui ne fonctionne plus, ou un plus récent qui est plus performant)

##==##

# Utilisation de fake

```csharp[]
public class Car
{
    private IEngine _engine;

    public Car (IEngine engine) { _engine = engine; }

    //...
}
```

On peut soit créer son propre "faux" moteur...

```csharp[]
public class FakeEngine : IEngine
{
    public bool StartEngineIsCalled { get; private set; } = false;
    public void StartEngine() { StartEngineIsCalled = true; }
}
```

... mais cela peut rapidement demander beaucoup de travail ...

- Il faut créer pleins de "faux" moteurs différents, configurés selon les besoins du test à réaliser.
- Ces "faux" moteurs représentent beaucoup de code à nettoyer et maintenir

##==##

# NSubstitute, FakeItEasy

... ou on peut utiliser une bibliothèque existante qui simplifie la création de "Fakes".

Généralement on parle aussi de "Mock" ou "Mocking frameworks"

```csharp[]
[Fact]
public void Start_WithEngine_CallsStartEngine()
{
    // Arrange
    var fakeEngine = Substitute.For<IEngine>();
    var myCar = new Car(fakeEngine);

    // Act
    myCar.Start();

    // Assert
    fakeEngine.Received(1).StartEngine();
}
```

<br><br>
_Remarque: attention à `Moq` qui est une bibliothèque très répandue, mais qui a des fonctionnalitées qui mènent souvent à de mauvais tests unitaires._
