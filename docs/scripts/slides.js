import { SfeirThemeInitializer } from '../web_modules/sfeir-school-theme/sfeir-school-theme.mjs';

// One method per module
function schoolSlides() {
  return [
    '00-conf/00-TITLE.md',
    '00-conf/01-speaker.md',
    '00-conf/02-agenda.md',
  ];
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
  return [
    '04-Model/00-TITLE.md',
    '04-Model/01-rappels.md',
    '04-Model/02-TP.md',
  ];
}

function formation() {
  return [
    //
    ...schoolSlides(), //
    ...history(), //
    ...csharp(), //
    ...conceptionSlides(), //
    ...apiSlides(), //
    ...securiteSlides(), //
  ].map((slidePath) => {
    return { path: slidePath };
  });
}

SfeirThemeInitializer.init(formation);
