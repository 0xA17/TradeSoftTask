using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeSoftTask.MVVM.Model;
using TradeSoftTask.Utilities;

namespace TradeSoftTask.Providers;

class PostgreSQLProvider
{
    public static List<ProductModel> GetProducts()
    {
        var result = new List<ProductModel>();

        using (var db = new DbMain())
        {
            result = db.Products.ToList();
        }

        return result;
    }

    public static async Task AddProduct(ProductModel product)
    {
        if (product is null) return;

        using (var db = new DbMain())
        {
            await db.Products.AddAsync(product);
            await db.SaveChangesAsync();
        }
    }

    public static async Task<Boolean> UpdateProduct(ProductModel productModel)
    {
        using (var db = new DbMain())
        {
            var existingProduct = db.Products.FirstOrDefault(p => p.Id == productModel.Id);

            if (existingProduct is null) return false;

            existingProduct.Article1 = productModel.Article1;
            existingProduct.Article2 = productModel.Article2;
            existingProduct.Manufacturer1 = productModel.Manufacturer1;
            existingProduct.Manufacturer2 = productModel.Manufacturer2;
            existingProduct.Confidence = productModel.Confidence;

            await db.SaveChangesAsync();
        }

        return true;
    }

    public static async Task ActualizeProducts(List<ProductModel> productModel)
    {
        using (var db = new DbMain())
        {
            foreach (var product in productModel)
            {
                var existingProduct = db.Products.FirstOrDefault(p => p.Id == product.Id);

                if (existingProduct is null)
                {
                    await db.Products.AddAsync(product);
                    continue;
                }

                existingProduct.Article1 = product.Article1;
                existingProduct.Article2 = product.Article2;
                existingProduct.Manufacturer1 = product.Manufacturer1;
                existingProduct.Manufacturer2 = product.Manufacturer2;
                existingProduct.Confidence = product.Confidence;
            }

            await db.SaveChangesAsync();
        }
    }

    public static async Task DeleteProduct(ProductModel productModel)
    {
        if (productModel is null) return;

        using (var db = new DbMain())
        {
            if(GetProductModelById(productModel.Id) is null) return;

            db.Remove(productModel);
            await db.SaveChangesAsync();
        }
    }

    public static ProductModel? GetProductModelById(Int32 id)
    {
        ProductModel? productModel = null;

        using (var db = new DbMain())
        {
            foreach (var item in db.Products)
            {
                if(item.Id == id)
                {
                    productModel = item;
                    break;
                }
            }
        }

        return productModel;
    }

    public static List<ProductModel> GetProductModelsByKey(String productKey)
    {
        var productModel = new List<ProductModel>();

        if (String.IsNullOrEmpty(productKey)) return productModel;

        using (var db = new DbMain())
        {
            foreach (var item in db.Products)
            {
                if (ProductWorkModel.IsCurrentProductKey(productKey, item.Article1, item.Manufacturer1))
                {
                    productModel.Add(item);
                }
            }
        }

        return productModel;
    }

    public static List<ProductModel>? GetProductModelsByAnalogue(ProductModel productModel)
    {
        if (productModel is null) return null;

        return GetProductModelsByKey(RegexUtils.NormalizeString(productModel.Article2 + productModel.Manufacturer2));
    }
}