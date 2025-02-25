using Flurl;
using Flurl.Http;
using InventarioMobile.Helpers;
using InventarioMobile.Models.Request;
using InventarioMobile.Models.Response;

namespace InventarioMobile.Repositories.Product;

public class ProductRepository : IProductRepository
{

    public async Task<IEnumerable<ProductResponse>> GetProductsAsync()
    {
        return await Constants.API_URL
            .AppendPathSegment("/products")
            .WithOAuthBearerToken(Preferences.Get("token", string.Empty))
            .GetJsonAsync<IEnumerable<ProductResponse>>();

    }

    public async Task<ProductResponse> GetProductAsync(Guid productId)
    {
        return await Constants.API_URL
            .AppendPathSegment($"/products/{productId}")
            .WithOAuthBearerToken(Preferences.Get("token", string.Empty))
            .GetJsonAsync<ProductResponse>();
    }

    public async Task<bool> AddProductAsync(ProductRequest request)
    {
        var response = await Constants.API_URL
            .AppendPathSegment("/products")
            .WithOAuthBearerToken(Preferences.Get("token", string.Empty))
            .PostJsonAsync(request);

        return response.ResponseMessage.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateProduct(ProductRequest request)
    {
        var response = await Constants.API_URL
            .AppendPathSegment("/products")
            .WithOAuthBearerToken(Preferences.Get("token", string.Empty))
            .PutJsonAsync(request);

        return response.ResponseMessage.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        var response = await Constants.API_URL
            .AppendPathSegment($"/products/{id}")
            .WithOAuthBearerToken(Preferences.Get("token", string.Empty))
            .DeleteAsync();

        return response.ResponseMessage.IsSuccessStatusCode;
    }
}