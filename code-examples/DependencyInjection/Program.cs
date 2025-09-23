using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//TODO-1 create a class UserService inheriting from IUserService

//TODO-2 make this class use a IDatabaseAccess (this is an interface not a class)

//TODO-3 implement an FakeDatabase inheriting from IDatabaseAccess

//TODO-4 use the dependency injection container in this file to register the
// - UserService
// - FakeDatabase

//TODO-5-Bonus :
// - create a class UserAuthorizationService that requires a UserService
// - create a method: bool IsAuthorized(string login);
// - don't forget to use the dependency injection container

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}
app.MapScalarApiReference();
app.MapControllers();
app.Run();
