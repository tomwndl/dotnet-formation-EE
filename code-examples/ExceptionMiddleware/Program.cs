using ExceptionMiddleware;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register the service as transient
builder.Services.AddTransient<GlobalExceptionMiddleware>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
  app.MapOpenApi();
}
app.MapScalarApiReference();
// Make sure to call this UseMiddleware
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseAuthorization();
app.MapControllers();
app.Run();
