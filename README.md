# Projet Gestion

## Description
Projet Gestion est une application web développée en .NET 8 utilisant Entity Framework Core pour la gestion des utilisateurs. L'application expose une API RESTful permettant de créer, lire, mettre à jour et supprimer des utilisateurs et des tâches.

## Prérequis
- .NET 8 SDK
- MySQL Server
- Visual Studio 2022 (ou une autre IDE compatible)

## Installation

1. Clonez le dépôt :
   git clone https://github.com/schlanger/ProjetGestionASP.git
   
## Utilisation

L'API expose les endpoints suivants :

- `GET /api/User/GetUsers` : Récupère la liste de tous les utilisateurs.
- `GET /api/User/GetUserById/{id}` : Récupère un utilisateur par son identifiant.
- `POST /api/User/InsertUser` : Insère un nouvel utilisateur.
- `PUT /api/User/UpdateUser` : Met à jour un utilisateur existant.
- `DELETE /api/User/DeleteUser/{id}` : Supprime un utilisateur par son identifiant.

## Exemple de requêtes

### Récupérer tous les utilisateurs

curl -X GET http://localhost:5193/api/User/GetUsers

### Récupérer un utilisateur par ID
curl -X GET https://localhost:5193/api/User/GetUserById/1
   
