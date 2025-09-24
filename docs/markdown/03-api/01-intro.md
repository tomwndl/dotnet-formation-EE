<!-- .element: class="list-fragment" -->
# Objectifs

- Introduction aux API Web
- Les principes fondamentaux de REST (verbes HTTP, status ...)
- Validation des données
- Développement d'une API Web avec .NET
- Bonnes pratiques pour les API Web
- TP : Développement d'une Todo list

Notes:
- 

##==##
<!-- .slide: class="two-column" data-background="#2c3c4e"-->


# Qu'est-ce qu'une API Web ?

- Application Programming Interface
- Interface logicielle qui permet à des applications de communiquer entre elles
- Expose des fonctionnalités ou des données sous forme de services accessibles par des requêtes
- Accessible via HTTP/HTTPS
- Peut être privé ou publique 
<!-- .element: class="list-fragment" -->

##--##

# Qu'est-ce qu'une API Web ?
![Timeline usage](./assets/images/api.png)

##==##

# Quels sont les avantages des APIs
- **Réutilisabilité** : Les fonctionnalités exposées via une API peuvent être utilisées par plusieurs applications.
- **Interopérabilité** : Permet aux systèmes de différentes technologies de communiquer.
- **Séparation des responsabilités** : Les API permettent de séparer le backend (logique métier) du frontend (interface utilisateur).
<!-- .element: class="list-fragment" -->


##==##

# Concepts clés

- **Client** : Une application ou un utilisateur envoie une requête à l'API.
- **Serveur** : L'API traite la requête et retourne une réponse 
- **Protocole HTTP/HTTPS** 
- **Format de données** : JSON / XML
- **Endpoint** : URL représentant une ressource/action dans l'API (api/users/123 => retourne l'utilisateur avec l'id 123)
<!-- .element: class="list-fragment" -->
