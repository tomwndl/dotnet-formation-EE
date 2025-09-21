
<!-- .slide: class="transition bg-blue" -->
# Expression bodied members

##==##

# [Expression bodies = Fonctions flechées](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members)

```csharp[]
public class Person 
{
  public string FirstName => "Jean";
  public string FullName => $"{FirstName} Cloud";

  public override string ToString() => $"I am a person named {FullName}";

  private int age = 30;
  public bool IsOlderThan(int age) => this.age > age;
}

var p = new Person();
Console.WriteLine(p.FirstName);       // Jean
Console.WriteLine(p.FullName);        // Jean Cloud
Console.WriteLine(p);                 // I am a person named Jean Cloud
Console.WriteLine(p.IsOlderThan(18)); // True
```
