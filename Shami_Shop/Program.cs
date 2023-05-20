using Microsoft.EntityFrameworkCore;
using Shami_Shop.Data;
using Shami_Shop.Data.Repositories;
using Shami_Shop.security.phoneoTotp.Providers;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IuserRepositories, UserRepository>();
builder.Services.AddTransient<IPhoneTotpProvider, phonetotpprovider>();
builder.Services.Configure<phonetotpoptions>(options =>
{
    options.stepinsecon = 60;
});

#region b Context

builder.Services.AddDbContext<ShamiShopContext>(optins =>
{
    optins.UseSqlServer("Data Source=.;Initial Catalog= ShamiShop_Db;Integrated Security=true;TrustServerCertificate=True");
});

#endregion


var app = builder.Build();

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

app.UseAuthorization();


app.UseAuthentication();
//app.Use(async (context, next) =>
//{
//    // Do work that doesn't write to the Response.
//    if (context.Request.Path.StartsWithSegments("/Admin"))
//    {
//        if (!context.User.Identity.IsAuthenticated)
//        {
//            context.Response.Redirect("/Account/Login");
//        }
//        else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
//        {
//            context.Response.Redirect("/Account/Login");
//        }
//    }
//    await next.Invoke();
//    // Do logging or other work that doesn't write to the Response.
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
