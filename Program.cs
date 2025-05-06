using APIProjetoLivros.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LivrosContext>();
var app = builder.Build();

app.Run();
