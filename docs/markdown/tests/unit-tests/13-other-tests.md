# Autres types de tests

- Snapshot testing
- Mutation testing
- Outils d'analyse de converture de code (dotnet-coverage)
  => Pour xUnit.v3 qui utilise la nouvelle Microsoft.Testing.Platform voir la [Documentation officielle xUnit.v3](https://xunit.net/docs/getting-started/v3/code-coverage-with-mtp)

##==##

# Mutation testing avec Striker

1. Installation

```bash
dotnet tool install -g dotnet-stryker
```

2. Aller dans le dossier du projet de test

```bash
cd ./BP.Domain.UnitTests/
```

3. Executer Stryker

```bash
dotnet dotnet-stryker
```

4. Afficher le html du rapport généré
