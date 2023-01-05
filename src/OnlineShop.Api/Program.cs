using OnlineShop.Api.Configurations.LayerConfigurations;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Repositories;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.ConfigureDataAccess();
builder.Services.AddScoped<IAccountRepositorie, AccountRepositorie>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
