using Microsoft.EntityFrameworkCore;
using RINO.Context;
using RINO.Repo.CategoryRepo;
using RINO.Repo.DeviceRepo;
using RINO.Repos.OrderRepo;
using RINO.Repos.ShoppingCartItemsRepo;
using RINO.SeedingData;

namespace RINO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddScoped<IDevice, DeviceR>();
            builder.Services.AddScoped<ICategory, CategoryRepo>();
            builder.Services.AddScoped<IShoppingCart,ShoppingCart>(sp=>ShoppingCart.GetCart(sp));
            builder.Services.AddScoped<IOrder, OrderRepo>();
            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllersWithViews()
                       .AddJsonOptions(options =>
                       {
                           // Configure JSON serialization options here
                           options.JsonSerializerOptions.ReferenceHandler =
                               System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                       });
            builder.Services.AddDbContext<RinoDbContext>(options => { options.UseSqlServer(builder.Configuration["ConnectionStrings:Conne"]); }) ;
            builder.Services.AddRazorPages();//if i need to add RazorPages
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseSession();
            //app.MapGet("/", () => "Hello World!");
            if(app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.MapDefaultControllerRoute();
            app.MapRazorPages();// razor page
            //Data
            DbInitializer.Seed(app);
            app.Run();
        }
    }
}