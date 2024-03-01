using Microsoft.EntityFrameworkCore;
using PokemonStore.Backend.Application;
using PokemonStore.Backend.Domain.Interfaces;
using PokemonStore.Backend.Infrastructure;
using PokemonStore.Backend.Infrastructure.Persistence;
using PokemonStore.Backend.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register Services from the other Layers

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

// Add InMemmory Database

builder.Services.AddDbContext<ApplicationDbContext>(o => o.UseInMemoryDatabase("PokemonStore"));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductOrderRepository, ProductOrderRepository>();

// Add services to the container.

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger(c =>
    {
        c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
    });

    app.UseSwaggerUI(c =>
    {

        c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Some API");
        c.RoutePrefix = "api/swagger";

    });

    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
        await initialiser.SeedAsync();
    }
}

app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
