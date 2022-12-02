using firebase.Controllers;
using firebase.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//added by me ----------------------------------------------------------------------
IConfiguration _configuration = builder.Configuration;
//added by me -----------------------------------------------------------------------
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(_configuration.GetConnectionString("MsSqlConnection")));
builder.Services.AddScoped<IDbOperation, DbOperation>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
