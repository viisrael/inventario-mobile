using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using InventarioMobile.Models.Request;
using InventarioMobile.Repositories.Login;

namespace InventarioMobile.ViewModels;
public partial class LoginViewModel: BaseViewModel
{
    [ObservableProperty] private string email;
    [ObservableProperty] private string senha;

    private readonly ILoginRepository _loginRepository;

    public LoginViewModel(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }

    [RelayCommand]
    public async Task Login()
    {
        var loginRequest = new LoginRequest(Email, Senha);

        var result = await _loginRepository.LoginAsync(loginRequest);

        if (result is null || string.IsNullOrEmpty(result.accessToken))
        {
            var toast = Toast.Make("Falha ao realizar o login. Tente novamente", ToastDuration.Long);
            await toast.Show();

            return;
        }
    }
}
