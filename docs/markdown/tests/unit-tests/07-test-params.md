# Test paramétrés

Utilisation de paramètres en entrés pour relancer plusieurs instance d'un même test avec des paramètres différents.

## InlineData

```csharp[]
[Theory]
[InlineData(1, 2, 3)]
[InlineData(-3, -4, -7)]
public void Add_TwoNumbers_ReturnsSum(int value1, int value2, int expected)
{
    var calculator = new Calculator();

    var result = calculator.Add(value1, value2);

    Assert.Equal(expected, result);
}
```

##==##

## MemberData

```csharp[]
[Theory]
[MemberData(nameof(Data))]
public void Add_TwoNumbers_ReturnsSum(int value1, int value2, int expected)
{
    var calculator = new Calculator();

    var result = calculator.Add(value1, value2);

    Assert.Equal(expected, result);
}

public static IEnumerable<object[]> Data =>
    new List<object[]>
    {
        new object[] { 1, 2, 3 },
        new object[] { -3, -4, -7 },
    };
```

##==##

## ClassData

```csharp[]
[Theory]
[ClassData(typeof(CalculatorTestData))]
public void Add_TwoNumbers_ReturnsSum(int value1, int value2, int expected)
{
    var calculator = new Calculator();

    var result = calculator.Add(value1, value2);

    Assert.Equal(expected, result);
}

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { 1, 2, 3 };
        yield return new object[] { -3, -4, -7 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
```
