using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using TaskManagement.Application;
using TaskManagement.Application.Tasks.Commands.CreateTask;
using TaskManagement.Domain.Shared.Repositories;
using TaskManagement.Infrastructure;
using TaskManagement.Infrastructure.Data;
using TaskManagement.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register ITaskRepository
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.EnableDetailedErrors();
    options.UseSqlServer(configuration.GetConnectionString("TaskManagementConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                10,
                TimeSpan.FromSeconds(30),
                null);
        });
});

// Add MediatR
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

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
