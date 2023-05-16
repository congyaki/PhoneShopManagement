using Microsoft.EntityFrameworkCore;
using PhoneShop.BusinessLogic.Catalog.Products;
using PhoneShop.Data.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("PhoneShopDB");
builder.Services.AddDbContext<PhoneShopDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();

//Declare DI
builder.Services.AddTransient<IPublicProductService, PublicProductService>();

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
