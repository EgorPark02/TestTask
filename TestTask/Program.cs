using Microsoft.EntityFrameworkCore.Migrations;
using TestTask;
using TestTask.Interfaces;
using TestTask.Models;
using TestTask.Repositories;
using TestTask.Worker;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddHostedService<MigrationWorker>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();