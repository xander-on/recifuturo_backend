using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using FluentValidation;
using RecifuturoBackend.UnitMeasures;
using RecifuturoBackend.Products;
using RecifuturoBackend.Products.Features.Create;
using RecifuturoBackend.Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString)
);

// modulos
builder.Services.AddUnitMeasures();
builder.Services.AddProducts();
builder.Services.AddRecyclers();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.MapUnitMeasures();
app.MapProducts();
app.MapRecyclers();
// app.MapGetAllProducts();


app.Run();
