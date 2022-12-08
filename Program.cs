using Microsoft.EntityFrameworkCore;
using TryWebAPI.Models;
using TryWebAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var conStr = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<CollegeContext>(options => options.UseSqlServer(conStr));
builder.Services.AddScoped<ICollegeRepo, CollegeRepo>();
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
