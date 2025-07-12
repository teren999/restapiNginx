using ProductsApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// ��������� �������� ���� ������
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ��������� Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Products API",
        Version = "v1",
        Description = "API ��� ���������� �������� � ���������������"
    });
});

var app = builder.Build();

// ������������� Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products API v1");
    c.RoutePrefix = "swagger"; // ������ �� ������ /swagger
});

app.UseHttpsRedirection(); // ����� ������, ���� �� ����������� HTTPS
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();