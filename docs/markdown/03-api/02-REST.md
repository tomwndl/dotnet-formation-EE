<!-- .slide: class="two-column" data-background="#2c3c4e"-->
# REST 

- Representational State Transfer
- Ensemble de principes qui permettent de créer des APIs

##--##
# Points clés

- Client-serveur
- Stateless (Sans état)
- Cacheabilité
- Uniformité de l'interface
- Système en couches
<!-- .element: class="list-fragment" -->

##==##

# Les verbes HTTP

Les verbes HTTP (ou méthodes HTTP) sont des actions standardisées utilisées dans le protocole HTTP pour indiquer l'intention d'une requête.
 
##==##

# Les verbes HTTP

| Verbe | Fonction principale | Effet sur la ressource | Corps autorisé |
|------|--------|---------|----------|
| GET | Récupérer des données | Aucun changement (lecture seule) | Non  |
| POST | Créer une ressource  | Ajoute une nouvelle ressource | oui  |
| PUT | Mettre à jour ou créer une ressource | Remplace toute la ressource | oui  |
| PATCH | Mettre à jour partiellement | Modifie partiellement la ressource  | oui  |
| DELETE | Supprimer une ressource  | Supprime la ressource spécifiée | Non  |

##==##
# Les codes de statut HTTP

- code numérique (3 chiffres) 
- envoyé par le serveur en réponse à une requête HTTP. 
- Indique le résultat de la requête : succès, redirection, erreur, etc.
<!-- .element: class="list-fragment" -->

##==##

# Catégories principales de codes de statut

| Code | Signification         | Description générale                                           |
|------|----------------------|----------------------------------------------------------------|
| 1xx  | Informationnel        | Le serveur a reçu la requête et continue le traitement. Rare. |
| 2xx  | ✅ Succès              | La requête a été reçue, comprise et acceptée.                  |
| 3xx  | 🔁 Redirection         | D'autres actions sont nécessaires pour compléter la requête.  |
| 4xx  | ❌ Erreur client       | Le problème vient de la requête envoyée par le client.         |
| 5xx  | 💥 Erreur serveur      | Le serveur a échoué à traiter une requête valide.              |

##==##

# Codes 2xx (Succès)

| Code | Signification  | Utilisation typique                              |
|------|----------------|--------------------------------------------------|
| 200  | OK             | Requête réussie (GET, PUT, PATCH, DELETE...)     |
| 201  | Created        | Ressource créée (POST)                           |
| 202  | Accepted       | Requête acceptée mais traitement différé         |
| 204  | No Content     | Requête réussie, mais aucune réponse à retourner |

##==##

# Codes 4xx (Erreurs côté client)

| Code | Signification         | Utilisation typique                                          |
|------|-----------------------|--------------------------------------------------------------|
| 400  | Bad Request           | Requête malformée ou invalide                               |
| 401  | Unauthorized          | Authentification requise mais absente ou invalide           |
| 403  | Forbidden             | Authentifié mais pas autorisé à accéder à la ressource      |
| 404  | Not Found             | Mauvais chemin                                              |


##==##

# Codes 5xx (Erreurs côté serveur)

| Code | Signification           | Utilisation typique                                              |
|------|-------------------------|------------------------------------------------------------------|
| 500  | Internal Server Error   | Erreur générique du serveur                                     |
| 502  | Bad Gateway             | Le serveur agit comme proxy et reçoit une mauvaise réponse      |
| 503  | Service Unavailable     | Serveur temporairement indisponible (maintenance, surcharge)    |
| 504  | Gateway Timeout         | Le serveur en amont ne répond pas à temps                       |


**A savoir** 
Exceptions non capturées = 500 Internal Server Error
<!-- .element: class="list-fragment" -->

