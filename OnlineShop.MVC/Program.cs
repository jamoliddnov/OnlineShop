using OnlineShop.MVC.Configurations.LayerConfiguration;
using OnlineShop.MVC.Middlewares;
using OnlineShop.Service.Helpers;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddService();
builder.Services.AddHttpContextAccessor();
builder.Services.AddWeb(builder.Configuration);


//Mapper
//builder.Services.AddAutoMapper(typeof(MapperConfiguration));


//builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
//{
//    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//}));

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
		context.HttpContext.Response.Redirect("login");
	}
});

app.MapControllerRoute(
	name: "account",
	pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.UseMiddleware<TokenRedirectMiddleware>();

if (app.Services.GetService<IHttpContextAccessor>() != null)
{
	HttpContextHelper.Accessor = app.Services.GetRequiredService<IHttpContextAccessor>();
}

app.UseAuthentication();
app.UseAuthorization();


app.UseCors("corspolicy");
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();




