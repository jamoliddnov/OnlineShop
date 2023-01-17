using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using OnlineShop.Api.Configurations;
using OnlineShop.DataAccess.Interfaces;
using OnlineShop.DataAccess.Repositories;
using OnlineShop.Service.Interfaces;
using OnlineShop.Service.Interfaces.Common.Security;
using OnlineShop.Service.Services;
using OnlineShop.Service.Services.Common.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();


builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


builder.ConfigureDataAccess();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAuthManagerService, AuthManagerService>();
builder.Services.AddScoped<IAccountRepositorie, AccountRepositorie>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IVerifyEmailService, VerifyEmailService>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
builder.Services.AddScoped<ISavedAdsService, SavedAdsService>();
builder.Services.AddScoped<ISavedAdRepositorie, SavedAdsRepositorie>();
builder.Services.AddScoped<IMemoryCache, MemoryCache>();



builder.Services.ConfigureSwaggerAuthorize();

//Mapper
builder.Services.AddAutoMapper(typeof(MapperConfiguration));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();
app.Run();
