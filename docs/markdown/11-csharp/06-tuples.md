<!-- .slide: class="transition bg-blue" -->
# Tuples

##==##

# [Tuples](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples)

Un Tuple est une structure de données très "légère" qui permet de rassembler un ensemble d'éléments.

```csharp[1-32|1-3|5-7|9-10|12-14|16-18|20-24|26-28|30-32|1-32]
// Tuple
(double, int) tuple = (4.5, 3);
Console.WriteLine($"Tuple with element1={tuple.Item1} and element2={tuple.Item2}");

// Tuple with field names
(double Sum, int Count) tuple2 = (4.5, 3);
Console.WriteLine($"Tuple with Sum={tuple2.Sum} and Count={tuple2.Count}");

// Return type
public (double Sum, int Count) GetSumAndCount() => (4.5, 3);

// Deconstruction
var (sum, count) = GetSumAndCount();
(var sum, var count) = GetSumAndCount();

var (sum, _) = GetSumAndCount(); // Here count is discarded
var result = GetSumAndCount();
Console.WriteLine(result.Sum);

// Projection
var sum = 4.5;
var count = 3;
var t = (sum, count);
Console.WriteLine($"Sum of {t.count} elements is {t.sum}."); // Field names are inferred

// Naming a tuple
global using SumCount = (double sum, int count);
SumCount result = GetSumAndCount()

// More tuples
var t = (Sum: 4.5, Count: 3, Min: 1, Max: 2, Average: 1.5)
Console.WriteLine($"Sum is {t.Sum} with an average of {t.Average} and {t.Count} elements");
```

##==##

# [Tuples](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples)

Les tuples sont généralement utilisés pour:
- définir une structure de données temporaire rapidement
- retourner plusieurs resultats
  - souvent une combinaison de (resultat, exception)

```csharp
public (int Sum, Exception ex) GetSum() { /* ... */ }

public static void Main()
{
    var (sum, ex) = GetSum();

    if (ex != null)
    {
       // device what to do with the exception
    }
    else 
    {
       // do something with the sum
    }
}
```
