import { SfeirThemeInitializer } from '../web_modules/sfeir-school-theme/sfeir-school-theme.mjs';

// One method per module
function schoolSlides() {
  return ['00-conf/00-TITLE.md', '00-conf/01-speaker.md', '00-conf/02-agenda.md'];
}

function history() {
  return [
    '10-history/00-TITLE.md',
    '10-history/01-objectifs.md',
    '10-history/02-net-framework-history.md',
    '10-history/03-net-core-history.md',
    '10-history/04-net-architecture.md',
    '10-history/05-exercices.md',
  ];
}

function csharp() {
  return [
    '11-csharp/00-TITLE.md',
    '11-csharp/01-null-handling.md',
    '11-csharp/02-async.md',
    '11-csharp/03-optional-params.md',
    '11-csharp/04-string-literals.md',
    '11-csharp/05-expression-bodied.md',
    '11-csharp/06-tuples.md',
    '11-csharp/07-records.md',
    '11-csharp/08-others.md',
  ];
}

function ioc() {
  return ['12-ioc/00-TITLE.md', '12-ioc/01-di-container.md', '12-ioc/02-middleware.md'];
}

function conceptionSlides() {
  return [
    '02-conception ASP.NET/00-TITLE.md',
    '02-conception ASP.NET/01-Intro-et-rappel.md',
    '02-conception ASP.NET/02-presentation.md',
    '02-conception ASP.NET/03-controller.md',
    '02-conception ASP.NET/04-routes.md',
    '02-conception ASP.NET/05-service.md',
    '02-conception ASP.NET/06-data.md',
  ];
}

function apiSlides() {
  return [
    '03-api/00-TITLE.md',
    '03-api/01-intro.md',
    '03-api/02-REST.md',
    '03-api/03-bonnes-pratiques.md',
    '03-api/04-api-net.md',
    '03-api/05-consommer-api.md',
  ];
}

function securiteSlides() {
  return ['04-securite/00-TITLE.md', '04-securite/01-rappels.md', '04-securite/02-authent.md', '04-securite/03-TP.md'];
}

function utests() {
  return [
    'tests/unit-tests/00-TITLE.md',
    'tests/unit-tests/01-definitions.md',
    'tests/unit-tests/02-autres-tests.md',
    'tests/unit-tests/03-pyramide.md',
    'tests/unit-tests/04-frameworks.md',
    'tests/unit-tests/05-mise-en-place.md',
    'tests/unit-tests/08-test-types.md', //intentionaly in this order
    'tests/unit-tests/06-organisations.md',
    'tests/unit-tests/07-test-params.md',
    'tests/unit-tests/09-test-advanced.md',
    'tests/unit-tests/10-cas-particuliers.md',
    'tests/unit-tests/11-philosophie.md',
    'tests/unit-tests/12-continuous-testing.md',
    'tests/unit-tests/13-other-tests.md',
  ];
}

function formation() {
  return [
    //
    ...schoolSlides(), //
    ...history(), //
    ...csharp(), //
    ...conceptionSlides(), //
    ...ioc(), //
    ...apiSlides(), //
    ...utests(), //
    ...securiteSlides(), //
  ].map((slidePath) => {
    return { path: slidePath };
  });
}

SfeirThemeInitializer.init(formation);
