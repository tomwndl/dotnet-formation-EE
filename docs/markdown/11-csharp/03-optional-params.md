<!-- .slide: class="transition bg-blue" -->
# Paramètres optionnels

##==##

# Paramètres optionnels

Définir une valeur par défaut pour un paramètre permet de le rendre optionnel.

```csharp[]
public Task DoSomething(CancellationToken ct = default) { }

// Valid calls
DoSomething();
DoSomething(CancellationToken);
```

##==##

# Examples

- Les valeurs par défaut doivent être **connues au moment de la compilation**.
- S'il y a plusieurs paramètres optionnels il faut les renseigner dans **l'ordre** OU **présicer leur nom**


```csharp[1-15|1-6|4-6|9-10|13-15|1-15]
public void CreateUser(
  string firstName, 
  string lastName, 
  string city = "",
  string phoneNumber = ""
  string? job = null) {}

// Optional parameters
CreateUser("Jean", "Cloud");               
CreateUser("Jean", "Cloud", "Strasbourg"); 

//Optional named parameters
CreateUser("Jean", "Cloud", phoneNumber: "06 13 37 13 37");                   
CreateUser("Jean", "Cloud", phoneNumber: "06 13 37 13 37", city: "Strasbourg"); //not recommended ! but works
CreateUser("Jean", "Cloud", "Strasbourg", job: "Software Dev");       
```

