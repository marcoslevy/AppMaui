using Flunt.Validations;
using InventarioMobile.Models.Request;

namespace InventarioMobile.Contratos
{
    public class SignupContract : Contract<SignupRequest>
    {
        public SignupContract(SignupRequest signupRequest)
        {
            Requires()
                .IsNotNullOrEmpty(signupRequest.Nome, nameof(signupRequest.Nome), "Nome não pode ser vazio");

            Requires()
                .IsEmail(signupRequest.Email, nameof(signupRequest.Email), "E-mail inválido")
                .IsNotNullOrEmpty(signupRequest.Email, nameof(signupRequest.Email), "E-mail não pode ser vazio");

            Requires()
                .IsNotNullOrEmpty(signupRequest.Senha, nameof(signupRequest.Senha), "Senha não pode ser vazia");
        }
    }
}
