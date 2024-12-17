using Flurl;
using Flurl.Http;
using InventarioMobile.Helpers;
using InventarioMobile.Models.Request;

namespace InventarioMobile.Repositorios.Signup
{
    public class SignupRepositorio : ISignupRepositorio
    {
        public async Task<bool> CreateAsync(SignupRequest request)
        {
            var response = await Constants.ApiUrl
                .AppendPathSegment("/users")
                .PostJsonAsync(request);

            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
