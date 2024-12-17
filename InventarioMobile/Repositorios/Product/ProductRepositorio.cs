using Flurl;
using Flurl.Http;
using InventarioMobile.Helpers;
using InventarioMobile.Models.Request;
using InventarioMobile.Models.Response;

namespace InventarioMobile.Repositorios.Product
{
    public class ProductRepositorio : IProductRepositorio
    {
        public async Task<IEnumerable<ProductResponse>> GetProductsAsync()
        {
            try
            {
                return await Constants.ApiUrl
                    .AppendPathSegment("/products")
                    .WithOAuthBearerToken(await SessionHelper.GetTokenAsync())
                    .GetJsonAsync<IEnumerable<ProductResponse>>();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Enumerable.Empty<ProductResponse>();
        }

        public async Task<bool> AddAsync(ProductRequest productRequest)
        {
            try
            {
                var response = await Constants.ApiUrl
                    .AppendPathSegment("/products")
                    .WithOAuthBearerToken(await SessionHelper.GetTokenAsync())
                    .PostJsonAsync(productRequest);
                return response.ResponseMessage.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }

        public async Task<bool> UpdateAsync(ProductRequest productRequest)
        {
            try
            {
                var response = await Constants.ApiUrl
                    .AppendPathSegment($"/products/{productRequest.ProductId}")
                    .WithOAuthBearerToken(await SessionHelper.GetTokenAsync())
                    .PutJsonAsync(productRequest);

                return response.ResponseMessage.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }


        public async Task<ProductResponse> GetProductByBarCodeAsync(string barCode)
        {
            try
            {
                return await Constants.ApiUrl
                    .AppendPathSegment($"/products/{barCode}")
                    .WithOAuthBearerToken(await SessionHelper.GetTokenAsync())
                    .GetJsonAsync<ProductResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new ProductResponse();
        }
    }
}
