﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace CourseWebApp;
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args)
           .Build()
           .Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}

//var builder = WebApplication.CreateBuilder(args);


//// Add services to the container.
//builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<CourseWebAppContext>
//    (options => options.UseMySql("server=localhost;userid=root;password=root;database=coursewebappdb",
//        ServerVersion.Parse("8.0.27-mysql")));

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}



//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();
