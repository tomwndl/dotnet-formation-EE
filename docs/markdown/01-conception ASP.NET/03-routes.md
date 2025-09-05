
# Le pipeline ASP.NET core et le middleware de routing

![center](./assets/images/pipeline.png)

##==##

le routing est gérer via un middleware

- Mapper les URLs aux actions des contrôleurs
- Gérer les paramètres dans les URLs
- Définir des patterns d'URL personnalisés (convention REST etc...)

##==##

<!-- .slide: class="with-code" -->

# Configuration de base

``` cs
// Dans Program.cs

app.UseRouting();
...

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

Changez la route par defaut pour appeler votre méthode Users

Notes: Nom de la route : "Default"
Modèle URL : "{controller}/{action}/{id}"
Valeurs par défaut : { controller = "Home", action = "Index", id = UrlParameter.Optional }
Si une URL / est appelée, elle ira vers HomeController.Index.
id est optionnel.

##==##


<!-- .slide: class="with-code" -->

# Routes par attribut

``` cs
[Route("api/product")]  
public class ProductController : Controller
{
    [Route("{category}")]
    public ActionResult GetOneProduct(string category)  // api/product/toto
    {
        // Logique ici
        return View();
    }

    [Route("all")]
    public ActionResult GetAllProduct()  // api/product/all
    {
        return View();
    }
}
```

##==##
<!-- .slide: class="with-code" -->

# Exercice

- Ajouter une methode UsersByAge(int age)
- Renvoyer la liste des utilisateurs dont l’âge correspond à l’âge passé en paramètre
- Configurer l’attribute routing pour exposer l’action sous l’URL /home/users/{age}.



##==##

# Solution
```
    [Route("home")]
    public class HomeController : Controller
    {
    ...

        [Route("users/{age}")]
        public IActionResult Users(int age)
        {
              var users = new List<User>
              {
                  new User { Nom = "Jean", Prenom = "Bonneau", Age = 23 },
                  new User { Nom = "Guy", Prenom = "Tar", Age = 28},
                  new User { Nom = "Anne", Prenom = "Honyme", Age = 45}
              };

            return Json(users.Where(u => u.Age == age).ToList());
        }

        public class User
        {
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public int Age { get; set; }
        }
    }
}
```

##==##

# Résumé

**Controller** : 
- Point d’entrée des requêtes.
- Contient des actions (méthodes) qui traitent les requêtes.
- Retourne une réponse (Vue, données, code http...).
- Ne doit pas contenir la logique métier → déléguée aux services.

##==##

# Résumé

**Routing** : 
- Etape dans la pipeline de requête ASP.NET Core
- Middleware UseRouting() identifie l’endpoint cible
- Deux approches :
  - **Conventionnel** : ex. {controller}/{action}/{id?}
  - **Par attributs** : [Route("home/users/{age}")]
