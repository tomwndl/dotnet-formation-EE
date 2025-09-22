<!-- .slide: class="transition bg-blue" -->

# Middleware

##==##

# [Middleware](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/)

Ordre des middlewares
<img class="r-frame" src="./assets/12-ioc/middleware-pipeline.svg" height="800">

##==##

# [Middleware custom pour la gestion d'exception](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/write) 

1. Implémenter une classe qui hérite de `IMiddleware`

```csharp
public class GlobalExceptionMiddleware : IMiddleware
{
  public async Task InvokeAsync(HttpContext context, RequestDelegate next)
  {
    try
    {
      await next(context);
    }
    catch (Exception ex)
    {
      await HandleException(context, ex);
    }  
  }
}
``` 

2. Ajouter le service transient dans le conteneur d'injection de dépendances

```csharp
//...
builder.Services.AddTransient<GlobalExceptionMiddleware>();

var app = builder.Build()
//...
app.UseMiddleware<GlobalExceptionMiddleware>();
```

##==##

# Utiliser le handler existant (pour les exceptions)

Pour les [WebApp](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling) 
ou les [WebAPI](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling-api)


```csharp
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}
else 
{
    app.UseDeveloperExceptionPage();
}
```

```csharp
[Route("/error")]
public IActionResult HandleError() => Problem();
```
