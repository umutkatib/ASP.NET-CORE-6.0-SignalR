using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

// Add services to the container.
builder.Services.AddControllersWithViews(opt =>
{
	opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});

builder.Services.AddHttpClient();
builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
	options.Password.RequiredLength = 5;
	options.Password.RequireDigit = false;
	options.Password.RequireLowercase = false;
	options.Password.RequireUppercase = false;
	options.Password.RequireNonAlphanumeric = false;

	options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<SignalRContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.LoginPath = "/Login/Index";
	options.AccessDeniedPath = "/Login/Index";
	options.ExpireTimeSpan = TimeSpan.FromHours(4);
	options.SlidingExpiration = true;
});

var app = builder.Build();

app.UseStatusCodePages(async x =>
{
	if (x.HttpContext.Response.StatusCode == 404)
		x.HttpContext.Response.Redirect("/Error/NotFound404Page");
	else if(x.HttpContext.Response.StatusCode == 403)
		x.HttpContext.Response.Redirect("/Error/AccessDenied403Page");
	else if (x.HttpContext.Response.StatusCode == 500)
		x.HttpContext.Response.Redirect("/Error/InternalServer500Page");

});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Default}/{action=Index}");

app.Run();
