﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GestionC.Data;
using GestionC.Controllers;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GestionCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GestionCContext") ?? throw new InvalidOperationException("Connection string 'GestionCContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//***cmj servicio p api minimal
builder.Services.AddHttpClient();

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

app.MapFestivosEndpoints();


app.Run();