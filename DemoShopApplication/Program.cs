using DemoShopApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DemoShopPieDBContextConnection") ?? throw new InvalidOperationException("Connection string 'DemoShopPieDBContextConnection' not found.");

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DemoShopPieDBContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DemoShopPieDbContextConnection"]);
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DemoShopPieDBContext>();
var app = builder.Build();
app.UseStaticFiles();
    app.UseDeveloperExceptionPage();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapDefaultControllerRoute();
app.MapRazorPages();
DBInitilizer.Seed(app);
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=PieController}/{action=List}/");
//});
app.Run();


