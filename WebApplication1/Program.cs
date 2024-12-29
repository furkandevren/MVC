using Microsoft.EntityFrameworkCore;
using WebApplication1.Helpers;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    //dbContext.product
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));

});

//Bir singelton nesne ekleyecez . Herhangi bir classýn constractýrýnda veya metodunda IHelper isminde bir interface görürsek
//gidip bundan Helper ismindeki sýnýftan bir nesne üret.

// builder.Services.AddSingleton<IHelper,Helper>();

builder.Services.AddScoped<IHelper, Helper>();

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

app.Run();
