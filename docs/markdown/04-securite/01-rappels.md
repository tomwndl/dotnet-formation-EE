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

