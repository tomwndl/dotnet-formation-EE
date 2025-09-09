<!-- .slide: class="transition-bg-sfeir-1" -->

# Api .Net (Création d'une api todolist)

##==##

# Initier le projet

- Ouvrir Visual Studio et créer un nouveau projet
- Selectionner le template API web ASP. NET Core
- Nommer le projet
- Décocher la case configurer pour HTTPS
- Cliquer sur créer

##==##

# Observation du template créé

- Api de prévision météorologiques
- Un model 
- Un controller
- Une classe Program
- Un fichier .http pour tester les requêtes dans Visual Studio

##==##

# Le controller d'api

- classe qui traite les requêtes HTTP
- point d’entrée entre le client (ex : une app web ou mobile) et le back-end
- Hérite généralement de la classe ControllerBase

##==##

# Les attributs importants

| Attribut              | Description                                                                 |
|-----------------------|-----------------------------------------------------------------------------|
| `[ApiController]`     | Active les fonctionnalités automatiques (binding, validation, 400 implicite) |
| `[Route(...)]`        | Définit la route du contrôleur ou de l’action                               |
| `[HttpGet]`           | Spécifie que l’action répond aux requêtes HTTP GET                          |
| `[HttpPost]`          | Spécifie que l’action répond aux requêtes HTTP POST                         |
| `[HttpPut]`           | Spécifie que l’action répond aux requêtes HTTP PUT                          |
| `[HttpDelete]`        | Spécifie que l’action répond aux requêtes HTTP DELETE                       |
| `[FromBody]`          | Indique que la donnée provient du corps de la requête HTTP                  |
| `[FromQuery]`         | Indique que la donnée provient de la query string                           |
| `[FromRoute]`         | Indique que la donnée provient des paramètres de route                      |
| `[FromForm]`          | Indique que la donnée provient d’un formulaire envoyé en POST               |


##==##

# Validation automatique des modèles

``` cs
public class UserDto
{
    [Required]
    public string Name { get; set; }
}

[ApiController]
public class Controller : ControllerBase
{
  [HttpPost]
  public IActionResult CreateUser([FromBody] UserDto user)
  {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      // inutile si [ApiController] est présent
  }   
}

```

##==##

# Les types de retours

| Type de retour             | Usage recommandé                                      | Peut retourner autre chose que 200 ? | Commentaires                    |
|----------------------------|--------------------------------------------------------|----------------------------------------|------------------------------------------|
| `IActionResult`            | Gestion des erreurs                                    | ✅                                      | Flexibilité maximale                      |
| `ActionResult<T>`          | Pour retour typé + gestion d'erreurs                   | ✅                                      | Typage fort + contrôle sur les erreurs   |
| `T` (ex: `UserDto`)        | Retourne toujours un 200                               | ❌                                      | Déconseillé                              |
| `Task<IActionResult>`      | Idem `IActionResult`, mais version async               | ✅                                      | Pour les appels asynchrones              |
| `Task<ActionResult<T>>`    | Idem `ActionResult<T>`, version async                  | ✅                                      | Typage + async                            |


##==##

# PostMan

Bruno est outil open-source qui permet de tester des API. 

- Ouvrir Bruno
- Créer un nouvelle collection
- Créer une nouvelle requête GET vers http://localhost:{port}/weatherforecast/
- Démarrer votre API
- Tester 

##==##

# Architecture cible pour notre api
```
src/
│
├── Controllers/
│   └── TodoListController.cs       # Contrôleurs API
│
├── Services/
│   │── ITodoListService.cs        # Interface du service
│   └── TodoListService.cs         # Implémentation du service
│
├── Models/
│   └── Todo.cs               # Modèle de données
│
├── DTO/
│   └── CreateTodoDto.cs            # Objets de transfert de données
│
└── Program.cs                   # Point d'entrée

```

##==##

# Création du controller 

- Création du controller TodoListController
- route api/TodoList
- Herite de ControllerBase
- Création d'un route GET toute simple qui retourne juste un code 200

##==##

# Création du controller 

``` cs
    [ApiController]
    [Route("api/todolist")]
    public class TodoListController : ControllerBase
    {
        private readonly ILogger<TodoListController> _logger;

        public TodoListController(ILogger<TodoListController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Code200()
        {
            return Ok();
        }
    }
```

##==##

# Création du modèle
<!-- .slide: class="two-column" data-background="#2c3c4e"-->

Créer la class Todo dans un dossier Models :

- Id (Guid)
- Description (string)
- IsDone (bool)

##--##

# Création d'un DTO associé pour la création

Créer la class CreateTodoDto dans un dossier DTO :

- Description (string)

##==##

# Création du Service et de son interface
- Créer la class Service dans le dossier services
``` cs
  public class Service : IService
    {
        private ICollection<Todo> TodoList = [ 
                new Todo()
                {
                    Id = Guid.NewGuid(),
                    Description = "Promener le chien"
                }
            ];

  ```

- Créer l'interface IService dans le dossier services et ajouter les méthode suivantes

``` cs
    public interface IService
    {
        public ICollection<Todo> GetTodo(); // get todos isDone = false
        public ICollection<Todo> GetDone(); // get todos isDone = true
        public Todo Post(CreateTodoDto item); // create todo
        public Todo ValidateTodo(Guid id); // update Todo => isDone = true
    }
```
Implémenter les méthodes dans le services

##==##
``` cs
    public class Service : IService
    {
        private List<Todo> TodoList = [ 
                new Todo()
                {
                    Id = Guid.NewGuid(),
                    Description = "Promener le chien"
                }
            ];

        public ICollection<Todo> GetDone()
        {
            return TodoList.Where( t => t.IsDone == true).ToList();
        }

        public ICollection<Todo> GetTodos()
        {
            return TodoList.Where(t => t.IsDone == false).ToList();
        }

        public Todo Post(CreateTodoDto item)
        {
            var newTodo = new Todo() { Id = Guid.NewGuid(), Description = item.Description };
            TodoList.Add(newTodo);
            return newTodo;       
        }

        public Todo ValidateTodo(Guid id)
        {
            var todoToValidate = TodoList.FirstOrDefault(t => t.Id == id);
            if(todoToValidate == null)
            {
                throw new Exception($"Pas de todos trouvé avec l'id {id}");
            }

            todoToValidate.IsDone = true;
            return todoToValidate;
        }
    }
```

##==##

# Injection du service dans le controller

Ajout du service dans program.cs 
``` cs
builder.Services.AddSingleton<IService, Service>();
```

puis injection dans le controller :

``` cs
        private readonly IService service;

        public TodoListController(IService service)
        {
            service = service;
        }
```

##==##

# Création des endpoints : GET

Créer deux endpoints Get : 
- un endpoint pour lister les choses à faire :  api/todolist
- Un endpoint pour lister les choses faites :  api/todolist/done
- Renvoie un code 200 + la liste des éléments
- Si pas d'éléments renvoie un code 204 (no content)

##==##

# Création des endpoints : GET

``` cs
        [HttpGet] // accessible via  GET api/todolist
        public IActionResult GetTodo()
        {
            var todos = service.GetTodos();
            if (!todos.Any())
            {
                return NoContent();
            }

            return Ok(todos);
        }

        [HttpGet("done")] // accessible via  GET api/todolist/done
        public IActionResult GetDone()
        {
            var done = service.GetDone();
            if (!done.Any())
            {
                return NoContent();
            }

            return Ok(done);
        }
```
##==##

# Création des endpoints : POST

Créer un endpoint POST pour créer un todo.

(route : POST api/todolist)

##==##

# Création des endpoints : POST

``` cs
        [HttpPost]
        public IActionResult Post([FromBody] CreateTodoDto dto)
        {
            service.Post(dto);
            return Created();
        }
```

##==##

# Création des endpoints : PUT

Créer un endpoint pour valider un todo (changement de statut isDone => true)
route : PUT api/todolist/{id}

##==##
# Création des endpoints : PUT

``` cs
        [HttpPut] 
        public IActionResult Validate([FromRoute] Guid id) // accessible via  PUT api/todolist/{id}
        {
            return Ok(service.ValidateTodo(id)); 
        }

``` 
##==##

# Création des endpoints : ajout de documentation pour le swagger 

- Ajouter les attributs [ProducesResponseType] (décrit les codes de retour possibles pour Swagger.)

``` cs
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status204NoContent)]
public IActionResult GetTodo()
{
    var todos = service.GetTodos();
    if (!todos.Any())
    {
        return NoContent();
    }

    return Ok(todos);
}
``` 
