using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(DataContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                context.ProductBrands.AddRange(brands);
            }
            if (!context.ProductTypes.Any())
            {
                var productType = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var type = JsonSerializer.Deserialize<List<ProductType>>(productType);
                context.ProductTypes.AddRange(type);
            }
            if (!context.Products.Any())
            {
                var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                context.Products.AddRange(products);
            }
            if(context.ChangeTracker.HasChanges()) context.SaveChangesAsync();
        }
    }
}
