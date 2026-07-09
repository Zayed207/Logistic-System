using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.RateLimiting;
using Infrastructure;
using Application;
using Microsoft.EntityFrameworkCore;
// using Infrastructure.Data; // Assuming DbContext is here

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Rate Limiting
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("Fixed", opt =>
    {
        opt.Window = System.TimeSpan.FromSeconds(10);
        opt.PermitLimit = 100;
    });
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Assuming DbContext registration
builder.Services.AddDbContext<DbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LogisticDb;Trusted_Connection=True;MultipleActiveResultSets=true"));

// Dependency Injection from Layers
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseRateLimiter();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
