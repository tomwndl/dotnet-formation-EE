<!-- .slide: class="transition bg-pink" -->

# La couche core / business

##==##


# La couche core / business

- Cœur fonctionnel de l’application
- Implémente les règles métiers, règles de gestion, cas d’usage
- Garant de la cohérence des données et la validité métier

La couche Core Business est le cerveau de l’application : elle contient toute la logique de gestion, indépendante de l’UI, du stockage ou des protocoles d’accès

##==##

# La couche core / business : on y met quoi ?
- Services métiers (UserService, PaymentService)
- Entités métier & des DTOs (PaymentResultDto, OrderSummaryDto)
- Validations métier / Événements métier (PaymentSucceeded)

##==##

# Exemple
<!-- .slide: class="two-column" -->
```cs
[ApiController]
[Route("api/[controller]")]
public class TaxesController 
(ITaxService _taxService) : ControllerBase
{
    [HttpGet("tva")]
    public ActionResult<decimal> GetTva([FromQuery] decimal amount)
    {
        var result = _taxService.CalculateTva(amount);
        return Ok(result);
    }
}
```

##--##

```cs
public interface ITaxService
{
    decimal CalculateTva(decimal amount);
}

public class TaxService : ITaxService
{
    private const decimal TauxTva = 0.20m; // 20%

    public decimal CalculateTva(decimal amount)
    {
        if (amount < 0) throw new ArgumentException("Le montant doit être positif");
        return amount * TauxTva;
    }
}
```

##==##

# La couche core / business : Bonnes pratiques
- utiliser des interfaces : définissent les contrats, implémentées ailleurs (ex. repository)
- Dependency Injection (DI) : les services métiers doivent être injectés et découplés
- Tests : C’est la couche la plus importante à tester (tests unitaires + tests fonctionnels)
- Doit être le plus pur possible, sans dépendance technique
- Il doit refléter le langage du métier (nommer les classes, méthodes et propriétés avec les termes fonctionnels)


