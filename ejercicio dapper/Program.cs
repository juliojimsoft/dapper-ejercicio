using System.Data;
using ejercicio_dapper.Data;
using ejercicio_dapper.Data.Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Conexion para entity framework
builder.Services.AddDbContext<AppDbContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración para Dapper
builder.Services.AddScoped<IDbConnection>(provider =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro del repositorio
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
