using Microsoft.EntityFrameworkCore;
using PhoneShop.Data.EF;
using PhoneShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using PhoneShop.AdminApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("PhoneShopDB");
builder.Services.AddDbContext<PhoneShopDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(connectionString));

// Đăng ký dịch vụ Identity

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();


// Đăng ký dịch vụ RoleManager
builder.Services.AddScoped<RoleManager<IdentityRole>>();


builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});




//đăng ký dịch vụ bộ nhớ đệm phân tán (Distributed Memory Cache) để lưu trữ tạm thời dữ liệu trong ứng dụng
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    //thời gian chờ không hoạt động của phiên trước khi bị xóa là 30
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    //cho phép truy cập cookie của phiên thông qua HTTP, giúp ngăn chặn tấn công
    options.Cookie.HttpOnly = true;
    //đảm bảo tính mạng của phiên trong trường hợp khẩn cấp.
    options.Cookie.IsEssential = true;
});
//Login
/*builder.Services.AddAuthentication()
    .AddCookie(option =>
    {
        option.LoginPath = new PathString("/Identity/Account/Login");
        *//*option.ExpireTimeSpan = TimeSpan.FromSeconds(30);*//*
    });*/

var app = builder.Build();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapRazorPages();
app.Run();
