# Objectif 

* Introduction à la conception moderne d'applications .Net
* Décryptage des 4 couches d'une architecture 4-tiers
* Créer une petite application .Net
* Quelques bonnes pratiques

<!-- .element: class="list-fragment" -->

##==##

# Introduction à l’architecture 4-tiers 
<!-- .slide: class="two-column" -->

L’architecture 4-tiers est la base de la plupart des applications web modernes : 
- Découpe l’application en 4 couches logiques (UI, API / Web, logique, données).
- Chaque couche est indépendante et communique seulement avec la couche directement voisine
- Avantages : faible couplage, scalabilité, maintenance et évolutivité

##--##

![center](./assets/images/4tiers.png)

##==##
<!-- .slide: class="two-column" -->

# Les 4 couches

| **Couche**                | **Rôle** | **Exemple concret** |
|--------------------------|----------|---------------------|
| **1. Présentation (UI)** | Interface utilisateur, interaction avec l’appli | Application web (React, Angular), page Razor |
| **2. API / Web**         | Expose des endpoints pour la communication entre client et serveur | ASP.NET Core Web API, Controllers MVC |
| **3. Logique métier**    | Contient les règles métiers, validations et orchestrations | Services C#, Core / business layer, logique métier, DTOs |
| **4. Données**           | Stocke et fournit les données persistantes | Classe entités, Mapping EF Core, context |


