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
        try
        {
            return await Constants.API_URL
                .AppendPathSegment("/products")
                .WithOAuthBearerToken(await SessionHelper.GetTokenAsync())
                .GetJsonAsync<IEnumerable<ProductResponse>>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return Enumerable.Empty<ProductResponse>();
    }

    public async Task<ProductResponse> GetProductAsync(Guid productId)
    {
        try
        {
            return await Constants.API_URL
                .AppendPathSegment($"/products/{productId}")
                .WithOAuthBearerToken(await SessionHelper.GetTokenAsync())
                .GetJsonAsync<ProductResponse>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return new ProductResponse();
    }

    public async Task<bool> AddProductAsync(ProductRequest request)
    {
        try
        {
            var response = await Constants.API_URL
                .AppendPathSegment("/products")
                .WithOAuthBearerToken(await SessionHelper.GetTokenAsync())
                .PostJsonAsync(request);

            return response.ResponseMessage.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return false;
    }

    public async Task<bool> UpdateAsync(ProductRequest request)
    {
        try
        {
            var response = await Constants.API_URL
                .AppendPathSegment($"/products/{request.ProductId}")
                .WithOAuthBearerToken(await SessionHelper.GetTokenAsync())
                .PutJsonAsync(request);

            return response.ResponseMessage.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return false;
    }

    public async Task<bool> DeleteProduct(int id)
    {
        try
        {
            var response = await Constants.API_URL
                .AppendPathSegment($"/products/{id}")
                .WithOAuthBearerToken(await SessionHelper.GetTokenAsync())
                .DeleteAsync();

            return response.ResponseMessage.IsSuccessStatusCode;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return false;
    }

    public async Task<ProductResponse> GetProductByBarCodeAsync(string code)
    {
        try
        {
            var response = await Constants.API_URL
                .AppendPathSegment($"/products/{code}")
                .WithOAuthBearerToken(await SessionHelper.GetTokenAsync())
                .GetJsonAsync<ProductResponse>();

            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return new ProductResponse();
    }
}