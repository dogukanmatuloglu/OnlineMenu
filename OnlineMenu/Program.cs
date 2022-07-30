using Microsoft.AspNetCore.Identity;
using OnlineMenu.Core.Entities;
using OnlineMenu.Core.IUnitOfWork;
using OnlineMenu.Core.Services;
using OnlineMenu.Data;
using OnlineMenu.Data.UnitOfWork;
using OnlineMenu.Service.Mapping;
using OnlineMenu.Service.Services;
using OnlineMenu.UI.IdentityCustomValidation;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OnlineMenuContext>();

builder.Services.AddIdentity<User, Role>(x => {

    x.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
    x.User.RequireUniqueEmail = true;


    x.Password.RequiredLength = 4; 
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase=false;
    x.Password.RequireDigit = false;

}).AddPasswordValidator<CustomPasswordValidator>().AddUserValidator<CustomUserValidator>().AddErrorDescriber<CustomIdentityErrorDescriber>().AddEntityFrameworkStores<OnlineMenuContext>().AddDefaultTokenProviders();




CookieBuilder cookieBuilder = new CookieBuilder()
{
    Name = "OnlineMenu",
    HttpOnly = false,


    SameSite = SameSiteMode.Lax,
    SecurePolicy = CookieSecurePolicy.None
};



builder.Services.ConfigureApplicationCookie(x => { x.LoginPath = "/User/Login"; x.Cookie = cookieBuilder; x.SlidingExpiration = true; x.ExpireTimeSpan = TimeSpan.FromDays(60); });
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MapProfile));


var app = builder.Build();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
  );
    endpoints.MapDefaultControllerRoute();


});


app.Run();
