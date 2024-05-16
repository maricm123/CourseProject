using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//*** Database context dependency injection ****//
var server = "courseproject.database";
var port = "1433";
var database = "courseproject";
var user = "sa";
var password = "KWkW01UnvsJIvxraxUp2";

/*var connectionString = $"Data source={dbHost};Initial Catalog={dbServer}; User ID=sa;Password={dbPassword}";*/
var connectionString = $"Server={server}, {port}; Database={database}; User ID={user}; Password={password}; TrustServerCertificate=true";
Console.WriteLine(connectionString, "CONNECTION STRING");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString).UseSnakeCaseNamingConvention());
/*builder.Services.AddDbContext<CustomerDbContext>(opt => opt.UseSqlServer(connectionString));*/

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
DatabaseInitializer.MigrationInitialisation(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
