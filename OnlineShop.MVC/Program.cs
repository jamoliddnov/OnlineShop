

using AutoMapper;
using OnlineShop.MVC.Configurations.LayerConfiguration;
using OnlineShop.MVC.Middlewares;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddService();
builder.Services.AddHttpContextAccessor();


//Mapper
builder.Services.AddAutoMapper(typeof(MapperConfiguration));


builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        context.HttpContext.Response.Redirect("accounts/login");
    }
});

app.MapControllerRoute(
    name: "account",
    pattern: "{area:exists}/{controller=Accounts}/{action=Login}/{id?}");

app.UseMiddleware<TokenRedirectMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("corspolicy");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();




