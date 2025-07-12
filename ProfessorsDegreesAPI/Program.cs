using ProductsApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Добавляем контекст базы данных
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Настройка Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Products API",
        Version = "v1",
        Description = "API для управления товарами и производителями"
    });
});

var app = builder.Build();

// Использование Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products API v1");
    c.RoutePrefix = "swagger"; // Доступ по адресу /swagger
});

app.UseHttpsRedirection(); // Можно убрать, если не используешь HTTPS
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();