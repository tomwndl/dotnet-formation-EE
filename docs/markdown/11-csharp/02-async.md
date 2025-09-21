<!-- .slide: class="transition bg-blue" -->

# Programmation Asynchrone

##==##

# [Programmation Asynchrone](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/)

- Possible depuis **2012** avec la sortie du Framework 4.5
- Permet de lancer une action longue,
  tout en gardant la possibilité pour votre application de **réagir à d'autres actions**.
- Ca évite les "Freeze" de l'application

##==## 

# Example

Imaginons un restaurant avec 1 table de clients, 1 serveur et 1 chef.

##==##

<!-- .slide: class="two-column" data-background="#2c3c4e"-->
# Programmation **synchrone**
- Le serveur prend la commande des clients
- Le serveur donne la commande au chef
- Le serveur attend que le chef ait fini de préparer les plats
- Le serveur va servir les plats
- Le serveur s'occupe des boissons
<!-- .element: class="list-fragment" -->

##--##
# Programmation **asynchrone**
- Le serveur prend la commande des clients
- Le serveur donne la commande au chef
- **Le serveur retourne en salle et s'occupe des boissons**
- **Le serveur retourne en cuisine et vérifie si c'est prêt, ou s'il doit encore attendre un peu**
- Le serveur va servir les plats
<!-- .element: class="list-fragment" -->

##==## 

# Synchrone vers Asynchrone

1. Cette méthode synchrone bloque l'application et prend plusieurs secondes:

```csharp[]
public void CallingMethod()
{
    int length = GetUrlContentLength(); // takes a long time
    //...
}
```

<br /> 

<div class="fragment"> 
2. On veut utiliser une méthode asynchrone pour que l'application ne bloque plus.

```csharp[1-5|3]
public void CallingMethod()
{
    Task<int> promiseLength = GetUrlContentLengthAsync(); // async Task
    //...
}
```
Une `Task` est une **promesse**, soit d'un retour d'un certain type, soit d'une action (comme une méthode void).
</div>

##==##

# Utilisation du async/await

3. On a besoin de la valeur de la promesse faites par la tâche. On attend donc son resultat.

```csharp[1-8|7]
public void CallingMethod()
{
    Task<int> promiseLength = GetUrlContentLengthAsync();

    //...

    int length = await promiseLength;
}
```

<br /> 

<div class="fragment"> 
4. Pour pouvoir utiliser `await` dans une méthode, il faut que la méthode appelante soit marquée avec `async Task`

```csharp[1-8|1]
public async Task CallingMethod()
{
    Task<int> promiseLength = GetUrlContentLengthAsync();

    //...

    int length = await promiseLength;
}
```
</div>

##==##

# CancellationToken

5. Pour pouvoir interrompre le traitement:

```csharp[1-8|1-3]
public async Task CallingMethod(CancellationToken ct)
{
    Task<int> promiseLength = GetUrlContentLengthAsync(ct);

    //...

    int length = await promiseLength;
}
```

<br /> 

Remarque: on évite de mettre le suffix `Async` dans le nom des méthodes

##==##

# Fonctionnement d'await

```csharp
public async Task CallingMethod()
{
    Task<int> promiseLength = GetUrlContentLengthAsync();
    //...
    int length = await lengthPromise;
    // ...
}
```

```csharp[1-12|3|5-6|8|10|10-12|1-12]
public async Task<int> GetUrlContentLengthAsync()
{
    var client = new HttpClient();
    
    Task<string> getStringTask = 
        client.GetStringAsync("https://docs.microsoft.com/dotnet");

    DoIndependantWork();

    string contents = await getStringTask;
    return contents.Length;
}
```

##--## 

<!-- .slide: class="two-column" data-background="#2c3c4e"-->
[Microsoft Learn: What happens in an async method?](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model#BKMK_WhatHappensUnderstandinganAsyncMethod)

![Schema](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/media/task-asynchronous-programming-model/navigation-trace-async-program.png)

##==##
 
# IAsyncEnumerable

```csharp
public async IAsyncEnumerable<string> GetUsersOneByOne([EnumeratorCancellation] CancellationToken ct)
{ 
    //...
}

public async Task WriteUserNames(CancellationToken ct)
{
    await foreach(User user in GetUsersOneByOne(ct))
    {
        Console.WriteLine(user.Name);
    }
}
```

- Permet de retourner une partie de la réponse progressivement
- Nécessite une annotation au niveau du `cancellationToken` en paramètre
- Se consomme avec une boucle `await foreach(...)`

##==## 

<!-- .slide: class="exercice" -->
# Exercice

TODO: lien vers le repo ?

