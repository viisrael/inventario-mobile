using Flunt.Validations;
using InventarioMobile.Models.Request;

namespace InventarioMobile.Contracts;
public class SignupContract: Contract<SignupRequest>
{
    public SignupContract(SignupRequest request)
    {
        Requires().IsNotNullOrEmpty(request.Nome, nameof(SignupRequest.Nome), "Nome não pode ser vazio");
        Requires().IsEmail(request.Email, nameof(SignupRequest.Email), "E-mail inválido");
        Requires().IsNotNullOrEmpty(request.Senha, nameof(SignupRequest.Senha), "Informe uma Senha");
        
    }
}
