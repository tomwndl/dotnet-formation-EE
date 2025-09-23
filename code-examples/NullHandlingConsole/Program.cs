var person= new Person
{
    FirstName = "Sacha",
    Age = 10,
    Address = new Address
    {
        City = "Bourg-Palette",
        Street = "Rue Carapuce",
        PostalCode = "1337",
    }
};

try
{
    Console.WriteLine($"City: {person.Address.City}");
    Console.WriteLine($"Secondary: {person.SecondaryAddress.City}");
}
catch (NullReferenceException ex)
{
    Console.WriteLine($"Caught in EXAMPLE 1: {ex.Message}");
}

/* 1. Set <Nullable>annotations</Nullable>, rebuild and check warnings. What changed ? */
/* 2. Set <Nullable>warnings</Nullable>,    rebuild and check warnings. What changed ? */
/* 3. Set <Nullable>enable</Nullable>,      rebuild and check warnings. What changed ? */
/* 4. Why is 'Person.Age' not throwing a Warning ? */
/* 5. Uncomment code until the line with ############################################ */

//
//if (person.SecondaryAddress != null)
//{
//    _ = person.SecondaryAddress.City;
//}
//
//if (person.SecondaryAddress is not null)
//{
//    _ = person.SecondaryAddress.City;
//}
//
//_ = person.SecondaryAddress?.Street; // Value or Null
//
//_ = person.SecondaryAddress.City; // Will throw (compiler picks it up when Nullable enabled)
//
//person.SecondaryAddress = new Address { City = "Plateau-Indigo" };
//_ = person.SecondaryAddress.City; // No longuer complains as assigned has been done

/* ############################################################################## */

/* 6. Fix line 42 and uncomment following code */

//Console.WriteLine(person.SecondaryAddress?.Street ?? "Unknown");
//Console.WriteLine(person.LastName ?? "KETCHUM");

/* 7. Fix remaining Warnings */
