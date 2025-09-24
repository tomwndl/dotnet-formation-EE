using Scalar.AspNetCore;
using Serilog;
using Serilog.Events;
using SfeirAPI.Domain.Posts;
using SfeirAPI.Domain.Todos;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(
        restrictedToMinimumLevel: LogEventLevel.Information,
        "Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
    )
    .WriteTo.Seq("http://localhost:5341")
    .MinimumLevel.Information()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddSerilog(Log.Logger);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// required later for swagger usage
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITodoRepository, InMemoryTodoDatabase>();
builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddHttpClient<IPostService, PostService>(client =>
{
    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // Use swagger and scalar (you can decide to use only one, or none if you want)
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapScalarApiReference();
}

app.UseAuthorization();

app.MapControllers();
Log.Information("Application starting");
app.Run();