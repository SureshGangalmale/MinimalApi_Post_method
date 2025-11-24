using Microsoft.EntityFrameworkCore;
using MinimalApiDemo.Data;
using MinimalApiDemo.EndPoints;
using MinimalApiDemo.Models;
using MinimalApiDemo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MySqlDbContext>(options=> options.UseMySQL(builder.Configuration.GetConnectionString("MySqlConn")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapStudentEndpoints();

app.Run();


