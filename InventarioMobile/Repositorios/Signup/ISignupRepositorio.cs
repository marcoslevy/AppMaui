using InventarioMobile.Models.Request;

namespace InventarioMobile.Repositorios.Signup
{
    public interface ISignupRepositorio
    {
        Task<bool> CreateAsync(SignupRequest request);
    }
}
