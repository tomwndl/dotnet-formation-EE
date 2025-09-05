## Le controller

``` cs
public class ProductsController : Controller
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    public IActionResult GetProducts()
    {
        var products = _service.GetAll();
        return Json(products);
    }
}
```

* Hérite de Controller ou ControllerBase
* Nom se termine par "Controller"
* Situé dans le dossier Controllers
* Contient des actions / endpoint / point de terminaisons
* Injection de dépendances
* Chaque méthode public d’un contrôleur peut être appelée en tant que point de terminaison HTTP. 


##==##

# Les actions

En ASP.NET Core MVC, une action est une méthode publique définie dans un contrôleur qui gère les requêtes HTTP et retourne une réponse au client.
Dans le langage plus courant on les appelles des points de terminaison /endpoints

Rôle d'une action :
- Point d'entrée du backend
- Elle reçoit les requêtes HTTP entrantes (GET, POST, PUT, DELETE, etc.).
- Elle traite les données (ex : lecture/écriture dans une base de données, logique métier).
- Elle renvoie une réponse au client (ex : une vue, un JSON, un statut HTTP).

Notes:
- Note  

##==##

<!-- .slide: class="two-column" -->

## Types de retour d'une action

``` cs
return Json(data);                     //Données JSON
return File(bytes, "application/pdf"); // Fichier
return NotFound();                     // 404
return BadRequest();                   // 400
return Ok();                           // 200

return View();                          // Vue par défaut
return View("ViewName");                // Vue spécifique

```
##==##

## Exercices : créer sa propre action

Supprimez toutes les méthodes du HomeController 
Ajoutez une méthode Users qui renvoie une liste d'utilisateurs sous format json.
voici les 3 utilisateurs à renvoyer : 

- Jean Bonneau - 23
- Guy Tar - 28
- Anne Honyme - 45

Lancer votre application. Comment appeler notre action ?

##==##

Solution : 
``` cs
  public IActionResult Users()
  {
      var users = new List<object>
      {
          new { nom = "Jean", prenom = "Bonneau", age = 23 },
          new { nom = "Guy", prenom = "Tar", age = 28},
          new { nom = "Anne", prenom = "Honyme", age = 45}
      };

      return Json(users);
  }
```

