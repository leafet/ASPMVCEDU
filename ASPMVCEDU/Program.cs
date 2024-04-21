using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using ASPMVCEDU.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var config = builder.Configuration;

var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("NO string");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Teachers",
    pattern: "{area:exists}/{controller=Teachers}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Students",
    pattern: "{area:exists}/{controller=Students}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Classes",
    pattern: "{area:exists}/{controller=Classes}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Courses",
    pattern: "{area:exists}/{controller=Courses}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Registrations",
    pattern: "{area:exists}/{controller=Registrations}/{action=Index}/{id?}");

app.Run();
