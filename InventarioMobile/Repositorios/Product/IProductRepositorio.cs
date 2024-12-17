using InventarioMobile.Models.Request;
using InventarioMobile.Models.Response;

namespace InventarioMobile.Repositorios.Product
{
    public interface IProductRepositorio
    {
        Task<IEnumerable<ProductResponse>> GetProductsAsync();
        Task<bool> AddAsync(ProductRequest productRequest);
        Task<bool> UpdateAsync(ProductRequest productRequest);
        Task<ProductResponse> GetProductByBarCodeAsync(string barCode);
    }
}
