# Programmation Asynchrone

Possible depuis 2012 avec la sortie du Framework 4.5

Permet de lancer une action longue, tout en gardant la possibilité pour votre application de réagir à d'autres actions.
(ça évite les Freeze d'application)


##==##

# Exemple du serveur au restaurant

Imaginons un restaurant avec :
- 1 serveur
- 2 chefs

Programmation **synchrone**:
- Le serveur prend la commande d'un client
- Le serveur donne la commande au chef
- Le serveur attend que le chef ait fini de préparer le plat
- Le serveur va servir le plat

Dans cette première situation le serveur est bloqué/en attente et ne peut rien faire avant que le plat ne soit prêt.

Programmation **asynchrone**:
- Le serveur prend la commande d'un client
- Le serveur donne la commande au chef
- **Le serveur demande au chef de le prévenir quand c'est prêt**
- **Le serveur retourne en salle s'occuper des autres clients**
- **Le cuistot a fini et prévient le serveur que c'est prêt**
- Le serveur va servir le plat


##==## 

# Async/Await

```csharp
public async Task MyMethod(CancellationToken ct)
{
  ct.ThrowIfCancellationRequested();
  //...
  await other.LongRunningMethod(ct);
  //..
}
```

- Le type de retour est: **`Task`** ou **`ValueTask`**
- Utilisation du `async/await`
  - `async` devant le type de retour
  - `await` devant un appel d'une méthode asynchrone
- Le `CancellationToken` pour interrompre une méthode asynchrone avant qu'elle soit finie

##==##
 
# IAsyncEnumerable

```csharp


```

- Permet de retourner une partie de la réponse progressivement
- Nécessite une annotation au niveau du `cancellationToken` en paramètre
- Se consomme avec une boucle `await foreach(...)`

