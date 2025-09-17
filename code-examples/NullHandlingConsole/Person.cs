public class Person
{
  public string FirstName { get; set; } // Non-nullable string
  public string? LastName { get; set; } // Nullable string (explicitly marked)
  public int Age { get; set; } // Non-nullable primitive
  public int? NumberOfSiblings{ get; set; } // Nullable primitive
  public Address Address { get; set; } //Non-nullable object
  public Address? SecondaryAddress { get; set; } //Nullable object
}

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string? PostalCode { get; set; }
}
