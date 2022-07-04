using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GestionC.Data;
using GestionC.Controllers;
using GestionC.Servicios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GestionCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GestionCContext") ?? throw new InvalidOperationException("Connection string 'GestionCContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//***cmj registracion de servicio para api minimal
builder.Services.AddHttpClient();

//***cmj PARA USAR DI de Net 6.0: cuando se pida una instancia de IServicioFestivos se debe crear una instancia de ServicioFestivos 
//***cmj registramos el servicio tipo transient en el container q es la IServicioFestivos 
builder.Services.AddTransient<IServicioFestivos, ServicioFestivos>();


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

//***cmj operaciones a ejecutar por cada peticion (pipeline request)
app.MapFestivosEndpoints();


app.Run();
