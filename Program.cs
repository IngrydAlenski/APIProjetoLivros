using APIProjetoLivros.Context;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

builder.Services.AddDbContext<LivrosContext>();

app.Run();
