<!-- .slide: class="transition-bg-sfeir-1" -->

# Les bonnes pratiques
##==##
# Conception des endpoints

- Utilise des noms clairs, descriptifs et orientés ressource.
- Typer les endpoints avec des verbes HTTP (GET, POST, PUT, DELETE) 
- Ne pas mettre les verbes HTTP dans les routes
- Suivre les conventions REST https://learn.microsoft.com/fr-fr/azure/architecture/best-practices/api-design
<!-- .element: class="list-fragment" -->

``` http
GET    /api/products          // Récupère tous les produits
GET    /api/products/42       // Récupère le produit 42
POST   /api/products          // Crée un produit
PUT    /api/products/42       // Modifie le produit 42
DELETE /api/products/42       // Supprime le produit 42
```

##==##
# Versionnement de l’API

Le versionnement permet :

- De faire évoluer l’API sans rupture,
- D’offrir une période de transition entre deux versions
- De garder plusieurs versions actives en parallèle

**Comment ?**
``` http
GET /api/v1/products // Version dans l’URL (la plus utilisée)

---- 
GET /api/products   // Version dans l’en-tête HTTP
Accept: application/vnd.myapi.v1+json
```

##==##
# Versionnement de l’API

installation dotnet add package Microsoft.AspNetCore.Mvc.Versioning

``` csharp
// dans program.cs
builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true; // Expose "api-supported-versions" dans l'en-tête
});
```

``` csharp
[ApiController]
[Route("api/v{version:apiVersion}/products")]
[ApiVersion("1.0")]
public class ProductsControllerV1 : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("Version 1");
}

[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/products")]
public class ProductsControllerV2 : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("Version 2");
}
```



##==##

# Documentation avec swagger

Outil et un standard qui sert à documenter, tester et explorer une API REST de manière simple et interactive.

Installation 
``` bash
dotnet add package Swashbuckle.AspNetCore
```

``` csharp

// dans program.cs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
```
Accès ensuite :
``` bash
https://localhost:{port}/swagger
```

