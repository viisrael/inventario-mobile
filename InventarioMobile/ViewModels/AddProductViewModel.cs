using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using InventarioMobile.Contracts;
using InventarioMobile.Models.Request;
using InventarioMobile.Repositories.Product;
using System.Text;
using Camera.MAUI;

namespace InventarioMobile.ViewModels
{
    public partial class AddProductViewModel: BaseViewModel
    {
        private readonly IProductRepository _repository;
        public CameraInfo SelectedCamera { get; set; }
        public ObservableCollection<CameraInfo> Cameras { get; } = new();

        [ObservableProperty] string barcode;
        [ObservableProperty] string descricao;
        [ObservableProperty] int? estoque;
        [ObservableProperty] double? preco;
        [ObservableProperty] string unidadeMedida;

        public AddProductViewModel(IProductRepository repository)
        {
            _repository = repository;
        }

        [RelayCommand]
        public async Task Save()
        {
            var product = new ProductRequest(Descricao, Estoque.Value, Barcode, UnidadeMedida, Preco.Value, DateTime.Now);

            var contract = new ProductContract(product);

            if (!contract.IsValid)
            {
                var messages = contract.Notifications.Select(n => n.Message);
                var sb = new StringBuilder();
               
                foreach (var message in messages) sb.Append($"{message}\n");

                await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "Ok");
                return;
            }

            var result = await _repository.AddProductAsync(product);

            IToast toast = new Toast();

            if (!result)
            {
                toast = Toast.Make("Erro ao cadastrar produto");
                return;
            }
            
            toast = Toast.Make("Produto Cadastrado com sucesso!");
            return;

            await toast.Show();

            await Shell.Current.GoToAsync("..");

        }

        [RelayCommand]
        private async Task ActivateCamera()
        {
            if (SelectedCamera is not null)
                await Shell.Current.DisplayAlert("Câmera Selecionado",
                    $"A câmera que você selecionou foi {SelectedCamera.Name}. Ative-a pressionando o botão da Câmera no app.",
                    "Ok");
            else
                await Shell.Current.DisplayAlert("Atenção", "Selecione uma câmera", "Ok");
        }
    }
}
