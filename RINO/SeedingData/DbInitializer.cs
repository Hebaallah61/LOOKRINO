using RINO.Context;
using RINO.Models;

namespace RINO.SeedingData
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            RinoDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RinoDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c=>c.Value));
            }

            if (!context.Devices.Any())
            {
                context.AddRange(
                new Device { Name = "Phone", Code = "125698545", Description = "lono vo", Instock = true, NumInstock = 5, Price = 1526.54m, ImgUrl = "kol/mk", ImgThumbnailUrl = "jkih/m" },
                new Device { Name = "headPhone", Code = "125698545", Description = "lono vo", Instock = true, NumInstock = 5, Price = 1526.54m, ImgUrl = "kol/mk", ImgThumbnailUrl = "jkih/m" },
                new Device { Name = "chargerPhone", Code = "125698545", Description = "lono vo", Instock = true, NumInstock = 5, Price = 1526.54m, ImgUrl = "kol/mk", ImgThumbnailUrl = "jkih/m" },
                new Device { Name = "cool Phone", Code = "125698545", Description = "lono vo", Instock = true, NumInstock = 5, Price = 1526.54m, ImgUrl = "kol/mk", ImgThumbnailUrl = "jkih/m" },
                new Device { Name = "lap Phone", Code = "125698545", Description = "lono vo", Instock = true, NumInstock = 5, Price = 1526.54m, ImgUrl = "kol/mk", ImgThumbnailUrl = "jkih/m" },
                new Device { Name = "tab Phone", Code = "125698545", Description = "lono vo", Instock = true, NumInstock = 5, Price = 1526.54m, ImgUrl = "kol/mk", ImgThumbnailUrl = "jkih/m" },
                new Device { Name = "touch Phone", Code = "125698545", Description = "lono vo", Instock = true, NumInstock = 5, Price = 1526.54m, ImgUrl = "kol/mk", ImgThumbnailUrl = "jkih/m" }

            ); 
           
            }
 context.SaveChanges();
            

        }
        private static Dictionary<string, Category>? categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(categories== null)
                {
                    var li = new Category[]
                    {
                        new Category{ CategoryName="kolo147"},
                        new Category{ CategoryName="kolo1256"},
                        new Category{ CategoryName="kolo4589"}
                    };
                    categories = new Dictionary<string, Category>();
                    foreach ( Category c in li)
                    {
                        categories.Add(c.CategoryName, c);
                    }
                }
                return categories;
            }
        }
    }
}
