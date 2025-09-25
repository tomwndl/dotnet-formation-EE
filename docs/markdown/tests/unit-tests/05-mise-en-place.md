<!-- .slide: class="transition-bg-sfeir-2" -->

# Premiers pas

##==##

# Mise en place - Premier test

Après avoir créer un projet, un premier exemple est proposé dans le template:

```csharp[]
// xUnit
[Fact]
public void Test1()
{
    Assert.True(true);
}
```

```csharp[]
// TUnit
[Test]
public async Task IsTrue()
{
    await Assert.That(x).IsTrue();
}
```

##==##

<!-- .slide: class="exercice" -->

# Exercice: lancer les tests

Lancer les tests unitaires de 4 manières différentes:

- Test Explorer dans Visual Studio
- `dotnet test` dans une console

Possible uniquement avex un framework compabile avec Microsoft Test Platform (exemple: xUnit.v3)

- `dotnet run` dans une console
- "Flèche" run dans Visual Studio

##==##

# Assert "simples"

Avec xUnit ([cheatsheet](https://gist.github.com/jonesandy/f622874e78d9d9f356896c4ac63c0ac3))

```csharp
Assert.True(true);

// strings
Assert.Equal(expectedString, stringToCheck);
Assert.StartsWith(expectedString, stringToCheck);
Assert.EndsWith(expectedString, stringToCheck);

// exception
Assert.Throws<T>(() => sut.Method());

// collections
Assert.Contains(expectedThing, collection);
Assert.DoesNotContain(expectedThing, collection);
Assert.Empty(collection);
Assert.All(collection, item => Assert.False(string.IsNullOrWhiteSpace(item)));
```

##==##

<!-- .slide: class="exercice" -->

# Exercice: TDD - Premiers tests

Compteur de Tennis

- Créer un compteur de score de tenis
- Exemple: Albert a marqué 3 points et Bertrand 1 point. Le score à afficher est "40-15"

Faire du Test Driven Development (TDD)

- RED <!-- écrire un test qui fail -->
- GREEN <!-- résoudre les erreurs de compilation et implémenter la fonction pour que le test passe à succeeded -->
- REFACTOR <!-- améliorer son code (REFACTORING ! pas de changement fonctionnel ou anticipation des fonctions à venir) -->
