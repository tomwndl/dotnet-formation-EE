<!-- .slide: class="transition-bg-sfeir-1" -->

# Consommer une api
##==##

# HttpClient 

- classe fournie par .NET (dans le namespace System.Net.Http) 
- permet d’envoyer des requêtes HTTP (GET, POST, PUT, DELETE…) vers une API ou un site web distant, et de lire les réponses.

##==##
# HttpClient
``` cs
using System.Net.Http;
using System.Text.Json;

var httpClient = new HttpClient();
HttpResponseMessage response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");

if (response.IsSuccessStatusCode)
{
    var json = await response.Content.ReadAsStringAsync(); // transformation en string
    List<Post>? posts = await response.Content.ReadFromJsonAsync<List<Post>>(); // désérialisation JSON en objet fort typé

    Console.WriteLine(json);
}
``` 
##==##
# HttpClient injecté avec IHttpClientFactory

Créer un nouveau HttpClient à chaque fois peut causer des soucis (on crée une nouvelle connexion TCP) :

- Des fuites de sockets
- De mauvaises performances

IHttpClientFactory est une fabrique d’objets HttpClient introduite par Microsoft dans .NET Core 2.1, pour résoudre des problèmes de performance et de gestion des ressources liés à l’utilisation classique de HttpClient.

##==##

# HttpClient injecté avec IHttpClientFactory
<!-- .slide: class="two-column"-->
 
Enregistrer le client dans Program.cs

 ``` cs
 // Quand je demanderai un HttpClient nommé "monClientApi", je veux que tu me donnes un client pré-configuré avec cette base URL.
builder.Services.AddHttpClient("monClientApi", client =>
{
     client.BaseAddress = new Uri("https://api.exemple.com/");
});
``` 
##--##
Puis l’injecter dans un service
 ``` cs
public class PostService
{
    private readonly HttpClient _httpClient;

    public PostService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("monClientApi"); // Crée un HttpClient avec BaseAddress = new Uri("https://api.exemple.com/");
    }

    public async Task<List<Post>> GetPostsAsync()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("posts"); appel !  GET : https://api.exemple.com/posts
    }
}
``` 

##==##

# HttpClient injecté avec IHttpClientFactory : clients typés 
<!-- .slide: class="two-column"-->
 
Enregistrer le client dans Program.cs

 ``` cs
 // Dans ma classe PostService, je veux que tu me donnes un client pré-configuré avec cette base URL.
builder.Services.AddHttpClient<PostService>(client =>
{
     client.BaseAddress = new Uri("https://api.exemple.com/");
});
``` 
##--##
 ``` cs
public class PostService
{
    private readonly HttpClient _httpClient;

    public PostService(IHttpClientFactory httpClientFactory)
    {
        this._httpClient = _httpClient
    }
}
``` 
##==##

# Consommer une api : TP

- Ajoutez un IHttpClientFactory pointant vers https://jsonplaceholder.typicode.com/
- injectez le dans votre service
- Ecrivez une méthode "GetPosts" qui envoie une requete GET vers /posts (https://jsonplaceholder.typicode.com/posts)
- Créez le DTO correspondant pour y mapper le json reçu
- Relier cela à une méthode de votre controller et testé (GET api/todolist/posts)

Bonus : 
- Ecrivez une méthode POST pour ajouter un posts 
