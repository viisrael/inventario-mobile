using InventarioMobile.Models.Request;

namespace InventarioMobile.Repositories.Signup;
public interface ISignupRepository
{
    Task<bool> CreateAsync(SignupRequest request);
}
