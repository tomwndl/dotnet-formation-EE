<!-- .slide: class="transition-bg-sfeir-2" -->

# Logs structurés

##==##

# Log traditionnel

```text
[INFO]2025.04.22-12:55:20 - Application started
[INFO]2025.04.22-12:55:32 - Transfered 200€ from account 01234 to account 56789
[EROR]2025.04.22-16:23:10 - Unsufficient amount in account 56789 (200€) to withdrow 500€
[WARN]2025.04.22-16:23:42 - Account 01234 has entered wrong password more than 5 times in the last 3 minutes.
```

Facile:

- faire une recherche (ctrl+f)
- parcourir le fichier par datetime
<!-- .element: class="list-fragment" -->

Plus difficile:

- Filtrer uniquement les Warnings et les Errors qui concernent les comptes 01234 et 56789 sur les 30 derniers jours ?
- Quel est le montant moyen des transferts effectués par l'utilisateur du compte 01234 au cours des 30 derniers jours ?
- Combien de tentatives de connexion échouées ont eu lieu pour chaque compte, regroupées par plage horaire ?
- Quels sont les 5 comptes ayant le plus grand nombre de transactions rejetées pour insuffisance de fonds ?
<!-- .element: class="list-fragment" -->

##==##

# Logs structurés

<!-- .slide: class="with-code" -->

```json
{
  "timestamp": "2025-04-22T12:55:20.000Z",
  "level": "INFO",
  "message": "Application started"
}
{
  "timestamp": "2025-04-22T12:55:32.000Z",
  "level": "INFO",
  "message": "Transfered 200€ from account 01234 to account 56789",
    "details": {
      "operation": "transfer",
      "amount": 200,
      "currency": "EUR",
      "source_account": "01234",
      "destination_account": "56789"
    }
}
{
  "timestamp": "2025-04-22T16:23:10.000Z",
  "level": "ERROR",
  "message": "Unsufficient amount in account 56789 (200€) to withdrow 500€",
  "details": {
    "operation": "withdrawal",
    "account": "56789",
    "available_balance": 200,
    "requested_amount": 500,
    "currency": "EUR"
  }
}
{
  "timestamp": "2025-04-22T16:23:42.000Z",
  "level": "WARNING",
  "message": "Account 01234 has entered wrong password more than 5 times in the last 3 minutes.",
  "details": {
    "account": "01234",
    "security_event": "multiple_password_failures",
    "failure_count": 5,
    "time_window_minutes": 3
  }
}{
  "timestamp": "2025-04-22T12:55:20.000Z",
  "level": "INFO",
  "message": "Application started"
}
{
  "timestamp": "2025-04-22T12:55:32.000Z",
  "level": "INFO",
  "message": "Transfered 200€ from account 01234 to account 56789",
  "details": {
    "operation": "transfer",
    "amount": 200,
    "currency": "EUR",
    "source_account": "01234",
    "destination_account": "56789"
  }
}
{
  "timestamp": "2025-04-22T16:23:10.000Z",
  "level": "ERROR",
  "message": "Unsufficient amount in account 56789 (200€) to withdrow 500€",
  "details": {
    "operation": "withdrawal",
    "account": "56789",
    "available_balance": 200,
    "requested_amount": 500,
    "currency": "EUR"
  }
}
{
  "timestamp": "2025-04-22T16:23:42.000Z",
  "level": "WARNING",
  "message": "Account 01234 has entered wrong password more than 5 times in the last 3 minutes.",
  "details": {
    "account": "01234",
    "security_event": "multiple_password_failures",
    "failure_count": 5,
    "time_window_minutes": 3
  }
}
```

##==##

# Utilisation de Serilog

1. Installer Serilog

```bash
dotnet add package Serilog
dotnet add package Serilog.Extensions.Logging
dotnet add package Serilog.Exceptions
```

2. Choisir un ou plusieurs 'Sink' (Console, Seq, Azure App Insight, Google Cloud Login, SqlServer, ...)

```bash
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.Seq
```

3. Configure Serilog au démarrage

```csharp
Log.Logger = new LoggerConfiguration()
  .WriteTo.Console()
  .WriteTo.Seq("http://localhost:5341")
  .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddSerilog(Log.Logger);
//...
```

##==##

# ATTENTION

N'utilisez pas l'interpolation de string pour les logs.

```csharp
// BAD ! ❌
_logger.LogError(ex, $"Something went wrong with transaction id {myId}");


// GOOD 👍
_logger.LogError(ex, "Something went wrong with transaction id {MyId}", myId);
```

##==##

# Output template

Pour la console ou les fichiers, utiliser un template permet d'afficher du TEXTE plutôt qu'un JSON structuré

```csharp[0|4]
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(
        restrictedToMinimumLevel:   LogEventLevel.Information,
        outptuTemplate:             "Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
    )
    //...
    .CreateLogger();
```
