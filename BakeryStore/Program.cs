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

var builder = WebApplication.CreateBuilder(args);
var mysqlConnection = builder.Configuration.GetConnectionString("MyConnection");

builder.Services.AddControllersWithViews();
builder.Services.AddCors();
builder.Services.AddDbContext<AppDBContent>(options => 
options.UseMySql(mysqlConnection, ServerVersion.AutoDetect(mysqlConnection)));


builder.Services.AddScoped<ICategories, CategoryRepository>();
builder.Services.AddScoped<IProducts, ProductRepository>();


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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Product}/{action=List}");
app.Run();
