using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Model.Entities.Sql.DataBase;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(configuration.GetValue<string>("ConnectionStrings:SqlServerConnectionString"));

    options.EnableSensitiveDataLogging();
    builder.Logging.AddConsole();

});
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IModelService, ModelService>(provider => new ModelService(provider.GetService<IConfiguration>()!, provider.GetService<DatabaseContext>()!));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
