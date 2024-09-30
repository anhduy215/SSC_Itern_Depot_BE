using DepotBackEnd.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using repository;
using service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ContainerService>();
builder.Services.AddScoped<ContainerRepository>();
builder.Services.AddScoped<PositionContainerRepository>();
builder.Services.AddMediatR(configuration => {
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddDbContext<Database>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("depot")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
