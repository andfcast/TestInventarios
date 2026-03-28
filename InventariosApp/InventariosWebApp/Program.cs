using InventariosWebApp.Service.Implementacion;
using InventariosWebApp.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IInventarioService, InventarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); // Enable Swagger middleware
    app.UseSwaggerUI(); // Enable Swagger UI middleware

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "InventariosWebApp API V1");
    });
}

app.UseHttpsRedirection();
app.UseDefaultFiles(); // Para que busque index.html por defecto
app.UseStaticFiles();  // Para servir archivos desde wwwroot

app.UseAuthorization();

app.MapControllers();



app.Run();
