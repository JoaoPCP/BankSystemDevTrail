using Microsoft.EntityFrameworkCore;
using ProjetoDevTrail.Api.Middlewares;
using ProjetoDevTrail.Api.Utills;
using ProjetoDevTrail.Api.Utills.DependecyInjectionHelpers;
using ProjetoDevTrail.Infra.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BankContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BankDatabase"))
);
builder.Services.AddDependencies();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

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

app.UseExceptionHandler(options => { });

app.Run();
