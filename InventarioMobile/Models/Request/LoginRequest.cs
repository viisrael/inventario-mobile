namespace InventarioMobile.Models.Request;
public class LoginRequest
{
    public string Email { get; private set; }
    public string Senha { get; private set; }

    public LoginRequest(string email, string senha)
    {
        Senha = senha;
        Email = email;
    }
    
}
