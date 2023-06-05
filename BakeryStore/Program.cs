using BakeryStore.Controllers;
using BakeryStore.Database;
using BakeryStore.Interfaces;
using BakeryStore.Interfaces.Mocks;
using BakeryStore.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using BakeryStore.Utility;

var builder = WebApplication.CreateBuilder(args);
var mysqlConnection = builder.Configuration.GetConnectionString("MyConnection");

builder.Services.AddControllersWithViews();
builder.Services.AddCors();
builder.Services.AddDbContext<AppDBContent>(options => 
options.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDBContent>()
    .AddDefaultTokenProviders();


builder.Services.AddScoped<IOrder, OrderRepository>();
builder.Services.AddScoped<ICategories, CategoryRepository>();
builder.Services.AddScoped<IShopCart, ShopCartRepository>();
builder.Services.AddScoped<IProducts, ProductRepository>();
builder.Services.AddScoped<IUsers, UserRepository>();
builder.Services.AddScoped<IEmailSender, MockEmailSender>();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCart.GetCart(sp));
builder.Services.AddMvc(mvcOtions =>
{
    mvcOtions.EnableEndpointRouting = false;
});
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
});



var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DBObjects.Initial(content);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(name: "default", pattern: "{controller=Product}/{action=List}");
app.Run();
