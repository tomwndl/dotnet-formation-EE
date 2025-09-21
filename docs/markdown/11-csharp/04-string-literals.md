<!-- .slide: class="transition bg-blue" -->
# String

##==##
<!-- .slide: class="with-code"  -->

# Fonctions pour les chaines de caractères

```csharp[1-31|1-3|5-6|8-14|16-18|20-28|30-31|1-31]
// String interpolation (fonctionne aussi avec des constantes)
var sfeir = "SFEIR";
Console.WriteLine($"Hello {sfeir}");

// Verbatim string (pas besoin de doubler les \)
Console.WriteLine(@"C:\Program Files\Mon Application\logs.txt");

// Texte multi-ligne (intéressant pour du json, xml ou html par exemple)
var json = """
    {
        "name": "SFEIR",
        "location": "Schiltigheim"
    }
    """;

// Interpolation avec verbatim string
var appName = "Mon Application";
Console.WriteLine($@"C:\Program Files\{appName}\logs.txt");

// Interpolation dans du json multi-ligne
var sfeir = "SFEIR";
var json = $$"""
    {
        "name": {{sfeir}},
        "location": "Schiltigheim"
    }
    """;
Console.WriteLine(json);

// NameOf
Console.WriteLine(nameof(sfeir));
```
