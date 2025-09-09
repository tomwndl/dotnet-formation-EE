# Objectif

- Rappels sécurité Web
- Authentification dans ASP.NET Core 
- Autorisation dans ASP.NET Core

##==##

# Rappels sécurité  

Frameworks modernes gèrent déjà beaucoup des risques classiques de sécurité : 

- XSS –  Cross-Site Scripting : L’attaquant injecte du JavaScript malveillant dans une page web (redirection etc)
- Injection SQL : ORM comme Entity Framework protège par défaut

##==##

# Rappels sécurité  : les bonne pratiques 

- Utiliser HTTPS partout (SSL/TLS)
- Authentification / autorisation
- Logguer les erreurs mais ne pas les exposer coté front end => Les messages d’erreur détaillés peuvent révéler la structure du système / fuite d'informations
- Limiter les surfaces d’attaque => Désactiver les endpoints non utilisés, fermer les ports / services non nécessaires
<!-- .element: class="list-fragment" -->

##==##

# Rappels sécurité  : les bonne pratiques 
- Gérer correctement les dépendances et mises à jour => beaucoup de failles viennent de librairies vulnérables
- Logs et surveillance  : Détecter les comportements suspect
- Limiter les abus (brute force, DDoS, rate limiting) :  Limiter les tentatives de login, utiliser des captcha
-  Principe de moindre privilège :  Séparer les rôles utilisateur (admin, user, invité, etc.), ne pas utiliser un compte admin pour accéder à la base de données
- Avoir un plan de réaction en cas d'incident : Être prêt à révoquer des tokens, forcer des resets de mot de passe / documenter le processus d’alerte interne
<!-- .element: class="list-fragment" -->
##==##

# Authentification dans avec .Net

- Pipeline d'authentification basé sur un middleware
- Intercepte chaque requête 
- Effectue un traitement
- Décide de la transmettre ou non au middleware suivant.
<!-- .element: class="list-fragment" -->
##==##

# Authentification dans avec .Net

Mise en place dans l'injdection de dépendances

``` cs
app.UseAuthentication(); // Authentifie l'utilisateur
app.UseAuthorization();  // Applique les règles d'autorisation
```

##==##

# Rôle du middleware UseAuthentication

- Le middleware UseAuthentication intercepte la requête.
- Il parcourt les schémas d’authentification enregistrés (par exemple JWT Bearer, Cookie, OAuth, etc.).
- Il exécute celui qui correspond à la requête.
- Si l’utilisateur est reconnu : crée un objet ClaimsPrincipal & l’attache à HttpContext.User pour qu’il soit disponible dans les contrôleurs
- **Attention** : si aucun utilisateur n’est trouvé, le middleware ne bloque pas la requête (ClaimsPrincipal vide & HttpContext.User.Identity.IsAuthenticated == false)
<!-- .element: class="list-fragment" -->
##==##

# Rôle du middleware UseAuthorization

- Il lit les attributs [Authorize], [AllowAnonymous]...
- Il vérifie que l'utilisateur dans HttpContext.User est authentifié
- Et s’il l’est, qu’il a les bons rôles ou claims
- =>  retourne une réponse 401 Unauthorized ou 403 Forbidden sinon
<!-- .element: class="list-fragment" -->
##==##

# Qu’est-ce qu’un Claim ?

Un claim est une information (paire clé-valeur) sur l’utilisateur, émise par un fournisseur d'identité (AzureAD par exemple). 

C’est la manière standard de représenter les données d'identité dans ASP.NET Core.

Le middleware interseptes les informations et les stocke ensuite dans object ClaimsPrincipal dans HttpContext?.User qui contient : 
- Une ou plusieurs identités (ClaimsIdentity)
- Chaque identité contient une collection de Claim 

##==##

# Exemple 

| Clé (Type)             | Exemple de valeur     | Description                       |
|------------------------|------------------------|-----------------------------------|
| `"Name""`      | `"alice"`              | Nom d'utilisateur                 |
| `"Email"`     | `"alice@mail.com"`     | Email                             |
| `"Role"`      | `"Admin"`              | Rôle(s) attribué(s)               |


**exemple**

``` cs
ClaimsPrincipal? principal = httpContextAccessor.HttpContext?.User;
var name = principal.FindFirstValue("name") 
```

##==##

#  Schémas d’authentification disponibles

ASP.NET Core supporte plusieurs schémas d'authentification via des packages, les plus connus :

- Cookie (Auth persistante via un cookie HTTP)
- JWT Bearer (Token dans le header Authorization)

Il faut configurer le schémas d'authentification pour que UseAuthentication() fonctionne correctement.

##==##

# Token JWT : c'est quoi 

Un JWT (JSON Web token) contient trois parties encodées en base64 séparé par des point (.) :

- Header : l'algorithme utilisé pour la signature (par exemple, HMAC SHA256 ou RSA).
- Payload (données / claims)
- Signature (vérifie que le token n'a pas été modifié)
- Exemple de token après encodage
``` cs
eyJhbGciOiAiSFMyNTYiLCAidHlwIjogIkpXVCJ9.eyJzdWIiOiAiMTIzNDU2IiwgIm5hbWUiOiAiYWxpY2UiLCAicm9sZSI6ICJhcGkiLCAiaWF0IjogMTYxMjAyNzkwNSwgImV4cCI6IDE2MTIwMzE1MDV9.Mgfjk232jksdfg24kfk34jf2k32jkjw2r43kjs
```

##==##

# Token JWT :  comment l'obtenir 

processure d'authentification classique :
- L’utilisateur envoie ses identifiants (login/password) à un endpoint d’authentification (ex: /api/auth/login).
- Le serveur vérifie les identifiants.
- Si tout est correct, le serveur génère un token JWT avec les claims nécessaires (nom, rôle, id...).
- Le token est retourné au client.

Dans un environnement Azure AD :
- L’utilisateur est redirigé vers une page de login Azure.
- Azure AD authentifie l’utilisateur.
- Azure AD renvoie un token JWT signé à l’application, contenant les informations d'identité.

##==##

# Token JWT :  comment ça marche 

- L'utilisateur de l'api ajout le token dans la requête dans le header http => Authorization: Bearer {token-jwt}
- Le middleware autorisation le valide automatiquement avant que la requête n'atteigne le contrôleur
- Le middleware utilise la clé pour valider que la signature correspond à celle du contenu du token.
- Le middleware vérifie la date d'expiration (exp) du token. Si le token est expiré, la requête est rejetée.
- Si le token est valide, ASP.NET Core crée un objet ClaimsPrincipal qui contient toutes les claims extraites du payload du token
<!-- .element: class="list-fragment" -->
##==##

# Token JWT :  bonnes pratiques 
- Utiliser HTTPS pour toutes les requêtes (ne jamais transmettre de token sur HTTP) => évite le vol de token
- Définir une expiration courte (ex: 15–60 minutes) pour limiter les risques en cas de vol du token.
- Implémenter un système de Refresh Token pour permettre la régénération des tokens sans demander à l'utilisateur de se reconnecter.
- Ajouter uniquement les informations nécessaires dans le payload.
- Éviter les données sensibles (ex : mot de passe, données personnelles non chiffrées).
<!-- .element: class="list-fragment" -->



