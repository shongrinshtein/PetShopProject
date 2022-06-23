using Microsoft.EntityFrameworkCore;
using PetShop.Client.Controllers;
using PetShop.Data;
using PetShop.Data.Models;
using PetShop.Data.Repository;
using PetShop.Service;
using PetShop.Service.Interfaces;
using PetShop.Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContextDB>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("PetShopDataConnection")));

builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAdminstartorService, AdminService>();
builder.Services.AddScoped<IAgeService,AgeService>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}");

app.Run();
