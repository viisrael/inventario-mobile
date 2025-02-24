using System.Text;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using InventarioMobile.Contracts;
using InventarioMobile.Models.Request;
using InventarioMobile.Repositories.Signup;

namespace InventarioMobile.ViewModels;
public partial class SignupViewModel: BaseViewModel
{
    [ObservableProperty] string nome;
    [ObservableProperty] string email;
    [ObservableProperty] string senha;

    private readonly ISignupRepository _repository;

    public SignupViewModel(ISignupRepository repository)
    {
        _repository = repository;
    }

    [RelayCommand]
    public async Task Signup()
    {
        var signupRequest = new SignupRequest(Nome, Email, Senha);
        var contract = new SignupContract(signupRequest);
        if (!contract.IsValid)
        {
            var messages = contract.Notifications.Select(n => n.Message);
            var sb = new StringBuilder();
            foreach (var message in messages)
                sb.AppendLine($"{message}\n");

            await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "Ok");
            return;
        }

        var result = await _repository.CreateAsync(signupRequest);
        if (!result)
        {
            var toast = Toast.Make("Falha ao realizar o cadastro. Tente novamente", ToastDuration.Long);
            await toast.Show();
            return;
        }

        var success = Toast.Make("Usuário Cadastrado com Sucesso", ToastDuration.Long);
        await success.Show();

        await Shell.Current.GoToAsync("..");
    }
}
