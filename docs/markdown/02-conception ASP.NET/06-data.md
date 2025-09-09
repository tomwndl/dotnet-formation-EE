<!-- .slide: class="transition bg-pink" -->

# La couche données

##==##


# La couche données : rôle

- Assurer la persistance des informations de l’application.
- Fournir un moyen abstrait et fiable d’accéder aux données.
- Être remplaçable sans impacter les couches supérieures (ex. changer SQL → NoSQL).

La couche Core Business est le cerveau de l’application : elle contient toute la logique de gestion, indépendante de l’UI, du stockage ou des protocoles d’accès

##==##

# La couche données : responsabilité
- Gérer la connexion à la base de données.
- Effectuer les opérations CRUD (Create, Read, Update, Delete).
- Garantir la cohérence des données (transactions, intégrité).
- Fournir des objets manipulables aux couches supérieures (souvent via ORM comme EF Core).

##==##

# La couche données : on y met quoi ?

- Les entités de persistance : classes qui reflètent la structure de la base (souvent mappées via EF Core)
- Les repositories : interfaces + implémentations qui encapsulent l’accès à la base
- La configuration de l’ORM ( Fichiers de configuration EF Core (DbContext, Fluent API, migrations; mapping))
- Requêtes SQL ou LINQ complexes pour ne pas polluer la logique métier

##==##

# Les entités de persistance

- Une classe qui reflète la structure de la base de données.
- Propriétés alignées sur les colonnes
- Peut avoir des relations (navigation properties)
- Utilisée par l’ORM (ex. EF Core) pour mapper les tables ↔ objets.
- Contient en général uniquement des propriétés (pas ou très peu de logique).
- Sert de modèle technique pour la couche Données.

##==##

# Les entités de persistance vs entité métier / DTOs

- L’entité de persistance est souvent plate
- pas ou très peu de logique
- Propriétés simples (souvent 1:1 avec les colonnes DB)
- Évolue avec le schéma de base


```cs
public class UserEntity
{
    public int Id { get; set; }        // Colonne DB
    public string Name { get; set; }   // Colonne DB
    public string Adress { get; set; }   // Colonne DB
    ...
    public int Age { get; set; }       // Colonne DB
}

public class UserSummary
{
    public int Id { get; }
    public string Name { get; }
    public int Age { get; }
    // Pas toute les colonnes

    // Règle métier
    public bool IsAdult() => Age >= 18;
}
```

# Les entités de persistance : bonnes pratiques

- Sans logique métier
- Clés & index
- Relations nettes & FK explicites
- Alignées sur le schéma DB
- Noms clairs et stables

```cs
public class OrderEntity
{
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }

    //  FK 
    public int UserId { get; set; }                 // <-- FK
    public UserEntity User { get; set; } = default!; // navigation
}
```
