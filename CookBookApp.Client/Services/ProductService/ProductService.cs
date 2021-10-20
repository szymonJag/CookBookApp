using CookBookApp.Client.Models;
using CookBookApp.Client.Services.HttpService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookApp.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IHttpService httpService;
        private readonly string apiUrl = "https://cobook.azurewebsites.net/api";

        public ProductService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await httpService.Get<List<Product>>($"{apiUrl}/Products");
        }
        public async Task<List<Product>> GetUnacceptedProducts()
        {
            return await httpService.Get<List<Product>>($"{apiUrl}/Products/unaccepted");
        }
        public async Task CreateProduct(AddProductModel product)
        {
            await httpService.Post<AddProductModel>($"{apiUrl}/Products", new { product.Name, product.Kcal, product.ProductTypeId });
        }

        public async Task<List<Product>> GetAllProductsAddedByUser(User user)
        {
            return await httpService.Get<List<Product>>($"{apiUrl}/Products/allProductsAddedByUser?username={user.Username}");
        }

        public async Task DeleteProduct(Product product)
        {
            await httpService.Delete<Product>($"{apiUrl}/Products/{product.Id}");
        }

        public async Task AcceptProduct(Product product)
        {
            await httpService.Put<Product>($"{apiUrl}/Products/changeIsAcceptedStatus/{product.Id}", new { product.Id });
        }

        public async Task<List<ProductType>> GetAllProductTypes()
        {
            return await httpService.Get<List<ProductType>>($"{apiUrl}/ProductTypes");
        }
    }
}
