using Capiware.Technologies.TesteTecnico.WebApi.Data;
using Capiware.Technologies.TesteTecnico.WebApi.Domain;
using Microsoft.EntityFrameworkCore;

using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("WebApiDatabase")));

ConfigureServices(builder.Services);

static void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<AppDbContext, AppDbContext>();
}

var app = builder.Build();

var Configuration = builder.Configuration;
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