<!-- .slide: class="transition-bg-sfeir-2" -->

# Continuous Testing

##==##

# Live Unit Testing dans Visual Studio Enterprise ou ReSharper

Relancer les tests dès qu'on sauvegarde un fichier avec Live Unit Testing dans Visual Studio Enterprise.
[Live Unit Testing overview](https://learn.microsoft.com/en-us/visualstudio/test/live-unit-testing-intro)

Resharper permet quand-à lui de configurer une ré-execution des tests automatiques dès lors qu'un build a lieu.
[Resharper Continuous Testing](https://www.jetbrains.com/resharper/features/unit_testing.html)

##==##

# Lancer les tests dans un conteneur docker

<!-- .slide: class="with-code" -->

```dockerfile[]
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

ENV SLN=MaSoluce.sln ENV CSPROJ=MonProjet.csproj
ENV CONFIGURATION=Release
ENV SOURCE_DIR=src
ENV TEST_DIR=tests
ENV TEST_RESULTS_DIR="/testresults/"
ENV TEST_FILTER_EXCLUDE="Category=Integration"

WORKDIR /
COPY ${SOURCE_DIR} ${SOURCE_DIR}
COPY ${TEST_DIR} ${TEST_DIR}

RUN dotnet restore "${SLN}"
RUN dotnet build "${SLN}" -c "${CONFIGURATION}"
RUN dotnet test "${SLN}" -- \
    --filter-not-trait "${TEST_FILTER_EXCLUDE}" \
    --results-directory "${TEST_RESULTS_DIR}" \
    --report-xunit \
    --coverage \
    --coverage-output-format 'xml' \
    --ignore-exit-code 8 #when there is no test executed in a project
RUN dotnet publish "${CSPROJ}" -c "${CONFIGURATION}" -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0-azurelinux3.0 AS final
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MonProjet.dll"]
```

##==##

# Automatisation dans des pipelines

1. Premier feedback lors de **l'execution en local**
2. Deuxième feedback lors du **build** et de l'exécution des **tests unitaires** sur une **machine de build**
3. ? Execution des tests d'intégration
4. ? Execution des test fonctionnels, dans un environnement dédié
5. ? Préparation d'un environnement de recette

##==##

# Publication dans Azure DevOps

![Test results in Azure DevOps](./assets/images/test-results-in-azure-devops.png)
