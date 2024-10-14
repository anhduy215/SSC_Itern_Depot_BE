using DepotBackEnd.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

//session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true; // Chỉ cho phép truy cập qua HTTP
    options.Cookie.IsEssential = true; // Cookie cần thiết cho session
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Chỉ gửi cookie qua HTTPS
});
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register repositories and MediatR services
builder.Services.AddScoped<ContainerRepository>();
builder.Services.AddScoped<PositionContainerRepository>();
builder.Services.AddScoped<VehicleRepository>();
builder.Services.AddScoped<VehicleTypeRepository>();
builder.Services.AddScoped<LineOperatorRepository>();
builder.Services.AddScoped<EirRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<BlockRepository>();
// Register MediatR
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

// Configure DbContext for Oracle
builder.Services.AddDbContext<Database>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("depot")));

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseSession();//session
app.UseAuthorization();
app.MapControllers();
app.Run();
