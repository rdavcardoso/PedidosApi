using PedidosApi.Data;
using PedidosApi.EndPoints;
using PedidosApi.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    } );
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapClienteEndpoints();
app.MapProdutoEndpoints();
app.MapPedidoEndpoints();

//Home
app.MapGet("/", () => "Minimal API CRUD criada por Rogério Cardoso da Vitória" +
                      "\nFeita para aprendizado de EF Core!");


app.Run();
