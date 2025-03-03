using InventarioMobile.Models.Request;
using InventarioMobile.Models.Response;

namespace InventarioMobile.Repositories.Product;
public interface IProductRepository
{
    Task<IEnumerable<ProductResponse>> GetProductsAsync();
    Task<ProductResponse> GetProductAsync(Guid productId);
    Task<bool> AddProductAsync(ProductRequest request);
    Task<bool> UpdateProduct(ProductRequest request);
    Task<bool> DeleteProduct(int id);
    Task<ProductResponse> GetProductByBarCodeAsync(string code);
}