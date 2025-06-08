using Microsoft.EntityFrameworkCore;
using GestaoAbrigos_WebApp.Infrastructure.Data.AppData;
using GestaoAbrigos_WebApp.Domain.Interfaces;
using GestaoAbrigos_WebApp.Infrastructure.Data.Repositories;
using GestaoAbrigos_WebApp.Application.Interfaces;
using GestaoAbrigos_WebApp.Application.Services;
using Swashbuckle.AspNetCore.Annotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(options => 
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle")));

// Repositories
builder.Services.AddTransient<IAbrigoRepository, AbrigoRepository>();
builder.Services.AddScoped<ILocalizacaoRepository, LocalizacaoRepository>();
builder.Services.AddScoped<IOcupanteRepository, OcupanteRepository>();
builder.Services.AddScoped<IRecursoRepository, RecursoRepository>();

// Application Services
builder.Services.AddScoped<IAbrigoApplication, AbrigoApplication>();
builder.Services.AddScoped<ILocalizacaoApplication, LocalizacaoApplication>();
builder.Services.AddScoped<IOcupanteApplication, OcupanteApplication>();
builder.Services.AddScoped<IRecursoApplication, RecursoApplication>();

// MVC and API Configuration
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

// Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = "swagger";
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
