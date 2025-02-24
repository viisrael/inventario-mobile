using Flunt.Validations;
using InventarioMobile.Models.Request;

namespace InventarioMobile.Contracts;
public class LoginContract: Contract<LoginRequest>
{
    public LoginContract(LoginRequest request)
    {
        Requires()
            .IsNotNullOrEmpty(request.Email, "Email", "E-mail não pode ser vazio")
            .IsEmail(request.Email, "Email", "E-mail inválido")
            .IsNotNullOrEmpty(request.Senha, "Senha", "Informe uma Senha");
    }
}
