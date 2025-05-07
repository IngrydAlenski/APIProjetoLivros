using APIProjetoLivros.Context;
using APIProjetoLivros.Interface;
using APIProjetoLivros.Repositories;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

//Avisa que a aplicacao usa controlers
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LivrosContext>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();    
var app = builder.Build();

app.MapControllers();
app.UseSwagger();

//Para que o swagger apareca direto na tela inicial sem ter que fazer /api/swagger 
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string .Empty;    
});

app.Run();
