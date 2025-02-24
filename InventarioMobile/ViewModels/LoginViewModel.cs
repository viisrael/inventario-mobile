using System.Text;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using InventarioMobile.Contracts;
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
        var contract = new LoginContract(loginRequest);

        if (!contract.IsValid)
        {
            var messages = contract.Notifications.Select(n => n.Message);
            var sb = new StringBuilder();

            foreach (var message in messages)
                sb.AppendLine($"{message}\n");

            await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "Ok");
            return;

        }


        var result = await _loginRepository.LoginAsync(loginRequest);

        if (result is null || string.IsNullOrEmpty(result.accessToken))
        {
            var toast = Toast.Make("Falha ao realizar o login. Tente novamente", ToastDuration.Long);
            await toast.Show();

            return;
        }
    }
}
