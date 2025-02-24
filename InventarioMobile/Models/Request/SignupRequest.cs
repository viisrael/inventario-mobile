using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioMobile.Models.Request;
public class SignupRequest
{
    public Guid UsuarioId { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }

    public SignupRequest(string nome, string email, string senha)
    {
        UsuarioId = Guid.NewGuid();
        Nome = nome;
        Email = email;
        Senha = senha;
    }
}
