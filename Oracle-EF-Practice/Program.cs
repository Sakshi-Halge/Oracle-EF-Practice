using Microsoft.EntityFrameworkCore;
using Oracle_EF_Practice.Repositories.DBContext;
using Oracle_EF_Practice.Repositories.Interfaces;
using Oracle_EF_Practice.Repositories.Repositories;
using Oracle_EF_Practice.Services.Interfaces;
using Oracle_EF_Practice.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Oracle DB context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Dependancy Injection services
builder.Services.AddScoped(typeof(IGenericContextRepository<>), typeof(GenericContextRepository<>));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();

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
