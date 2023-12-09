using SistemaDeGestionEscolar.Controllers;
using SistemaDeGestionEscolar.Models;
using SistemaDeGestionEscolar.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<SistemaDeGestionDatabaseSettings>(
    builder.Configuration.GetSection("SistemaDeGestionEscolarDatabase"));

builder.Services.AddSingleton<ProfesorServices>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddScoped<AlumnosServices>();
builder.Services.AddScoped<CalificacionesServices>();
builder.Services.AddScoped<MateriaServices>();
builder.Services.AddScoped<ProfesorServices>();



var app = builder.Build();

app.UseCors();

app.MapControllers();

app.Run();
