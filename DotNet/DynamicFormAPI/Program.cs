using DynamicFormAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static DynamicFormAPI.Features.Studnet.Commands.StudentCommand;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<sdirectdbContext>(i => i.UseSqlServer(builder.Configuration.GetConnectionString("AppConn")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
}));

builder.Services.AddScoped<StudentCommandHandler>();
//builder.Services.AddScoped<StudentQueryHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("corsapp");

app.MapControllers();

app.Run();
