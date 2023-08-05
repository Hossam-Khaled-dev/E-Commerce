using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {

           // context.Database.EnsureCreated();
            {
                if (!context.ProductBrands.Any())
                {
                
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    context.ProductBrands.AddRange(brands);
                }
                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    context.ProductTypes.AddRange(types);
                }
                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                    context.Products.AddRange(products);
                }

                if (context.ChangeTracker.HasChanges())
                {

                    await context.SaveChangesAsync();
                    
                }

                 


                //if (!context.ProductBrands.Any())
                //{
                //    // var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                //    //var brandData = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "brands.txt"));

                //    // var brands =JsonSerializer.Deserialize<List<ProductBrand>>(brandData);

                //    // var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "brands.json");
                //    //var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Infrastructure", "Data", "SeedData", "brands.json");
                //    // var filePath = Path.Combine("Infrastructure", "Data", "SeedData", "brands.json");
                //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{"SeedData\\brands.json"}");
                //    var jsonData = File.ReadAllText(filePath);
                //    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(jsonData);
                //    context.ProductBrands.AddRange(brands);
                //}
                ////if (!context.Products.Any())
                ////{
                ////    //var ProductData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                ////    //var Products= JsonSerializer.Deserialize<List<Product>>(ProductData);

                ////    //var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{"SeedData\\products.json"}");
                ////    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "SeedData", "products.json");

                ////    var jsonData = File.ReadAllText(filePath);
                ////    var Products = JsonSerializer.Deserialize<List<ProductBrand>>(jsonData);
                ////    //context.Products.AddRange((IEnumerable<Product>)(Products));
                ////    context.Products.AddRange((IEnumerable<Product>)(Products));
                ////}
                ////if (!context.ProductTypes.Any())
                ////{
                ////    //var ProductTypesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                ////    //var Types = JsonSerializer.Deserialize<List<ProductType>>(ProductTypesData);

                ////    var filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{"SeedData\\types.json"}");
                ////    var jsonData = File.ReadAllText(filePath);
                ////    var Types = JsonSerializer.Deserialize<List<ProductBrand>>(jsonData);
                ////    context.ProductTypes.AddRange((IEnumerable<ProductType>)Types);
                ////}
                //if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();

            }
        }
    }
}
