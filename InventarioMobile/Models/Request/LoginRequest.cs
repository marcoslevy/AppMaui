namespace InventarioMobile.Models.Request
{
    public class LoginRequest
    {
        public LoginRequest(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; private set; }
        public string Senha { get; private set; }
    }
}
