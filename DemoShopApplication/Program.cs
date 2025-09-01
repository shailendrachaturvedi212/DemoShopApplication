using DemoShopApplication.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DemoShopPieDBContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:DemoShopPieDbContextConnection"]);
});
var app = builder.Build();
app.UseStaticFiles();

    app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseSession();
app.MapDefaultControllerRoute();
DBInitilizer.Seed(app);
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=PieController}/{action=List}/");
//});
app.Run();


