using CookBookApp.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBookApp.Client.Services.ProductService
{
    public interface IProductService
    {
        Task AcceptProduct(Product product);
        Task CreateProduct(AddProductModel product);
        Task DeleteProduct(Product product);
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetAllProductsAddedByUser(User user);
        Task<List<ProductType>> GetAllProductTypes();
    }
}