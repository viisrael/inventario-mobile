using Flurl;
using Flurl.Http;
using InventarioMobile.Helpers;
using InventarioMobile.Models.Request;

namespace InventarioMobile.Repositories.Signup;
public class SignupRepository: ISignupRepository
{

    public async Task<bool> CreateAsync(SignupRequest request)
    {
        var response = await Constants.API_URL
                                      .AppendPathSegment("/users")
                                      .PostJsonAsync(request);

        return response.ResponseMessage.IsSuccessStatusCode;
    }
}
