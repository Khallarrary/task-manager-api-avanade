using TaskManager.Application.Interfaces;
using TaskManager.Application.Services;
using TaskManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// XML para Swagger
// ==========================
var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

// ==========================
// SERVICES
// ==========================

// Controllers
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(xmlPath);
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// DI (Dependency Injection)
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// ==========================
// BUILD
// ==========================
var app = builder.Build();

// ==========================
// PIPELINE
// ==========================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();