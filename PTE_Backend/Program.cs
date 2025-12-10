using DataContext.PTEContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PTE_Repository;
using PTE_Model;

var builder = WebApplication.CreateBuilder(args);

// Register MySQL
var connectionString = builder.Configuration["DB:DefaultConnection"];

builder.Services.AddDbContext<PTEContext>(options =>
   options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));



// Add services to the container.

// Configuration
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// PTE Content Service
builder.Services.AddScoped<IWfdService,WfdService>();









builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "PTE API",
        Version = "v1"
    });

    c.EnableAnnotations();  // Running SwaggerOperation
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
