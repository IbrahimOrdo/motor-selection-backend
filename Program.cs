using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using motor_selection_backend.Models;
using Serilog;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using Serilog.Sinks.Elasticsearch;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, JsonContext.Default);
});


// Serilog yapılandırması
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)  // appsettings.json'dan ayarları alır
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/app-log-.txt", rollingInterval: RollingInterval.Day) // Günlük log
    .WriteTo.Seq("http://localhost:5341")  // Seq entegrasyonu
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
    {
        AutoRegisterTemplate = true,
        IndexFormat = "motor-selection-logs-{0:yyyy.MM.dd}"
    })
    .CreateLogger();

builder.Host.UseSerilog(); // Serilog'u kullanmasını sağlıyoruz

//builder.Services.AddDbContext<MotorDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Motor Selection API",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Motor Selection API V1");
    options.RoutePrefix = string.Empty;
});

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

// In-memory kullanıcı ve motor listeleri
var users = new List<User>();
var motorcycles = new List<Motorcycle>
{
    new Motorcycle { Id = 1, Model = "Honda CBR500R", Brand = "Honda", EngineSize = 500, SuitableFor = "Genç sürücüler" },
    new Motorcycle { Id = 2, Model = "Yamaha MT-07", Brand = "Yamaha", EngineSize = 700, SuitableFor = "Orta seviye sürücüler" },
    new Motorcycle { Id = 3, Model = "Kawasaki Ninja H2", Brand = "Kawasaki", EngineSize = 1000, SuitableFor = "Deneyimli sürücüler" }
};

// Kullanıcı CRUD Endpoint'leri
app.MapGet("/users", () => Results.Ok(users));

app.MapGet("/users/{id}", (int id) =>
{
    try
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        return user != null ? Results.Ok(user) : Results.NotFound();
    }
    catch (Exception ex)
    {
        Log.Error(ex, "Beklenmeyen bir hata oluştu.");
        
        //context.Response.StatusCode = 500;
        //await context.Response.WriteAsync("Internal Server Error");
        return Results.NotFound();
    }
    
});

app.MapPost("/users", (User user) =>
{
    user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
    users.Add(user);
    return Results.Created($"/users/{user.Id}", user);
});

app.MapPut("/users/{id}", (int id, User updatedUser) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user == null)
    {
        return Results.NotFound();
    }

    user.Name = updatedUser.Name;
    user.Age = updatedUser.Age;
    user.Weight = updatedUser.Weight;
    user.Height = updatedUser.Height;
    user.Occupation = updatedUser.Occupation;

    return Results.NoContent();
});

app.MapDelete("/users/{id}", (int id) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user == null)
    {
        return Results.NotFound();
    }

    users.Remove(user);
    return Results.NoContent();
});

// Motor CRUD Endpoint'leri
app.MapGet("/motorcycles", () => Results.Ok(motorcycles));

app.MapGet("/motorcycles/{id}", (int id) =>
{
    Log.Information("Log yazıldımı? Deneme!");
    var motorcycle = motorcycles.FirstOrDefault(m => m.Id == id);
    return motorcycle != null ? Results.Ok(motorcycle) : Results.NotFound();
});

app.MapPost("/motorcycles", (Motorcycle motorcycle) =>
{
    motorcycle.Id = motorcycles.Any() ? motorcycles.Max(m => m.Id) + 1 : 1;
    motorcycles.Add(motorcycle);
    return Results.Created($"/motorcycles/{motorcycle.Id}", motorcycle);
});

app.MapPut("/motorcycles/{id}", (int id, Motorcycle updatedMotorcycle) =>
{
    var motorcycle = motorcycles.FirstOrDefault(m => m.Id == id);
    if (motorcycle == null)
    {
        return Results.NotFound();
    }

    motorcycle.Model = updatedMotorcycle.Model;
    motorcycle.Brand = updatedMotorcycle.Brand;
    motorcycle.EngineSize = updatedMotorcycle.EngineSize;
    motorcycle.SuitableFor = updatedMotorcycle.SuitableFor;

    return Results.NoContent();
});

app.MapDelete("/motorcycles/{id}", (int id) =>
{
    var motorcycle = motorcycles.FirstOrDefault(m => m.Id == id);
    if (motorcycle == null)
    {
        return Results.NotFound();
    }

    motorcycles.Remove(motorcycle);
    return Results.NoContent();
});

// Kullanıcıya uygun motorları öneren endpoint
app.MapGet("/recommendations/{userId}", (int userId) =>
{
    var user = users.FirstOrDefault(u => u.Id == userId);
    if (user == null)
    {
        return Results.NotFound();
    }

    var recommendations = motorcycles.Where(m => IsMotorcycleSuitableForUser(m, user)).ToList();
    return Results.Ok(recommendations);
});

bool IsMotorcycleSuitableForUser(Motorcycle motorcycle, User user)
{
    // Basit bir uygunluk kontrolü
    if (user.Age < 25 && motorcycle.EngineSize > 500)
    {
        return false;
    }

    if (user.Weight > 100 && motorcycle.EngineSize < 700)
    {
        return false;
    }

    return true;
}

app.Run();