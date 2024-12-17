using InventarioMobile.Models.Request;
using InventarioMobile.Models.Response;

namespace InventarioMobile.Repositorios.Login
{
    public interface ILoginRepositorio
    {
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    }
}
