using OnlineMenu.Core.Entities;
using OnlineMenu.Core.IUnitOfWork;
using OnlineMenu.Core.Services;
using OnlineMenu.Data;
using OnlineMenu.Data.UnitOfWork;
using OnlineMenu.Service.Mapping;
using OnlineMenu.Service.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OnlineMenuContext>();
builder.Services.AddIdentity<User,Role>().AddEntityFrameworkStores<OnlineMenuContext>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MapProfile));


var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
