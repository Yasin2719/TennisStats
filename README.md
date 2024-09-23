# Tennis Stats

Projet ASP.Net Core Web API avec .Net 8.0.

## Architecture

L'application suit une architecture DDD (Domain Driven Design) qui sépare la solution en 4 projets:

- Domain: Contient les classes de domaine
- Infrastructure: Contient Repository permettant de faire les requêtes vers les sources de données
- Application: Contient les classes de l'application et les services
- API: Contient la partie Web API (Controllers, etc...)

Ces projets sont présents dans le dossier src.

## Tests

Le projet est tésté et contient un projet xUnit permettant de tester, principalement, la partie Application.

pour lancer les tests, veuillez exécuter la commande suivante dans le terminal:

```bash
dotnet test
```

## Dépendances

- Microsoft.AspNetCore.Mvc.NewtonsoftJson

## Contneurisation

Il existe un DockerFile permettant de créer l'image Docker de l'application.

Pour créer l'image Docker, veuillez exécuter la commande suivante dans le terminal:

```bash
docker build -t tennis-stats-image .
docker run -it --rm -p 5000:80 --name tennis-stats-container tennis-stats-image
docker run -d -p 5000:80 --name tennis-stats-container tennis-stats-image
```

Cette commande va créer l'image Docker et l'exécuter dans un conteneur Docker.
Elle sera ensuite accessible via l'url http://localhost:5000.

## Installation

Pour installer l'application, il faut d'abord cloner le dépôt git et ouvrir le projet dans Visual Studio.

## Démarrage

Pour démarrer l'application, il faut d'abord exécuter la commande suivante dans le terminal:

```bash
dotnet run
```

Cette commande va démarrer l'application et la déployer sur localhost:5000.

Une fois l'application démarrée, vous pouvez accéder à l'application en utilisant l'url http://localhost:5000.
