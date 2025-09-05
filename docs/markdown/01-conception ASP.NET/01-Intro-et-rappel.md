# Objectif ?

* Introduction à MVC 
* créer une petite application MVC 
* Quelques bonnes pratiques

<!-- .element: class="list-fragment" -->

##==##

<!-- .slide: class="two-column" -->
MVC est un pattern architectural de logiciels, introduit dans les années 1970. 

Il divise une application en trois aspects principaux: 
- Modèle
- Vue
- Contrôleur.

Il permet une séparation de préoccupations, ce qui signifie que le modèle et la logique du contrôleur sont séparés de l’interface utilisateur (vue). 

##--##

![center](./assets/images/mvc.png)

##==##
<!-- .slide: class="two-column" -->

## Model

* Représente les données et la logique métier
* Indépendant de l'interface utilisateur
* Composants typiques : entités de données, couche services...

##--##

## Vue

* Interface utilisateur (UI)
* Contient principalement du HTML

##==##

## Controller

* Point d'entrée du back-end
* Traite les requêtes HTTP
* Coordonne les interactions entre Model et Vue
* Gère la logique de navigation (routage)
* Prépare les données pour l'affichage
* Ne contient PAS de logique métier 

Création d'un projet ASP.NET MVC pour la suite du cours
