using InventarioMobile.Models.Request;
using InventarioMobile.Models.Response;

namespace InventarioMobile.Repositories.Login;
public interface ILoginRepository
{
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
}
