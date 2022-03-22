⚠️ Cette branche est encore utilisée activement (après la date de rendu de rapport). Nous y ajoutons des tests et des fonctionnalités supplémentaires en vue du projet React Native du second semestre.

La branche qui correspond au rendu du 14/01, soumissible à l'évaluation est disponible à l'adresse :

https://github.com/ensc-glog/projet-2021-bernard-domecq-gr1/tree/rendu

`git clone --branch rendu git@github.com:ensc-glog/projet-2021-bernard-domecq-gr1.git`

# Projet
Projet de génie logiciel

# Comment le lancer ?

Pour lancer le projet, depuis le dossier racine du dépôt exécutez (sur Windows):

`dotnet tool install dotnet-ef --global --version 5.0 `

`dotnet-ef database update`

`dotnet run --project Ensciens`

Pour lancer les tests automatisés : 

`dotnet test`

`xcopy "Ensciens\EnsciensContext-395eca2a-a773-46c0-82f8-3316672b5924.db" "Ensciens.Tests\bin\Debug\net5.0\" /y`

`dotnet test --logger "console;verbosity=detailed" Ensciens.Tests`

# Objectifs

L'objectif de ce projet est de mettre en place une API pour le projet de création d'application mobile. Notre projet porte sur un réseau social basique pour les élèves de l'ENSC. Ce réseau prend en compte les bureaux, clubs, familles, et permet la création de publications et d'évènements de la vie associative enscienne.

## Exigences métier
- [x] **EF_01** L’application offre accès aux données métier via des vues web (HTML).

- [x] **EF_02** L’application expose une API anonyme donnant accès aux données métier. Cette API utilise le format JSON.

## Exigences techniques
- [x] **ET_01** L’application est réalisée à l’aide de la technologie ASP. NET Core MVC.

- [x] **ET_02** Les données persistantes sont stockées dans une base de données relationnelle SQLite.

- [x] **ET_03** L’interface entre les classes métier et la SGBDR exploite l’outil Entity Framework Core.

- [x] **ET_04** L’application respecte autant que possible les grands principes de conception étudiés en cours : séparation des responsabilités, limitation de la duplication de code, KISS, YAGNI, etc.

- [x] **ET_05** L’ensemble du code source respecte la convention camelCase.

- [x] **ET_06** Les noms des classes, propriétés, méthodes, paramètres et variables sont choisis avec soin pour refléter leur rôle.

- [x] **ET_07** L’application dispose de tests automatisés de type “smoke tests” pour vérifier le comportement des contrôleurs

