using System.Text;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using InventarioMobile.Contracts;
using InventarioMobile.Models.Request;
using InventarioMobile.Models.Response;
using InventarioMobile.Repositories.Product;

namespace InventarioMobile.ViewModels;

[QueryProperty(nameof(Product), nameof(Product))]
public partial class EditProductViewModel: BaseViewModel
{
    private readonly IProductRepository _productRepository;
    
    public ProductResponse _product;
    public ProductResponse Product
    {
        get => _product;
        set {
            SetProperty(ref _product, value);

            if (value != null)
            {
                ProductId = value.ProductId;
                Barcode = value.Barcode;
                Descricao = value.Descricao;
                Estoque = value.Estoque;
                Preco = value.Preco;
            }
        }
    }
    
    
    [ObservableProperty] private Guid productId;
    [ObservableProperty] private string barcode;
    [ObservableProperty] private string descricao;
    [ObservableProperty] private int? estoque;
    [ObservableProperty] private double? preco;

    public EditProductViewModel(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task getInfoProductAsync(string barcode)
    {
        var product = await _productRepository.GetProductByBarCodeAsync(barcode);

        if (product is null)
            return;
        
        ProductId = product.ProductId;
        Barcode = product.Barcode;
        Descricao = product.Descricao;
        Estoque = product.Estoque;
        Preco = product.Preco;
    }
    
    [RelayCommand]
    public async Task Save()
    {
        var request = new ProductRequest(ProductId, Descricao, Estoque, Barcode, Preco);
        var contract = new ProductContract(request);

        if (!contract.IsValid)
        {
            var messages = contract.Notifications.Select(n => n.Message);
            var sb = new StringBuilder();

            foreach (var message in messages)
                sb.Append($"{messages}\n");
            
            await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "OK");
            return;
        }
        
        var result = await _productRepository.UpdateProduct(request);

        if (!result)
        {
            var toast = Toast.Make("Falha ao atualizar o estoque, tente novamente", ToastDuration.Long);
            
            await toast.Show();
            return;
        }

        var totastSucess = Toast.Make("Estoque atualizado com Sucesso!", ToastDuration.Long);
        await totastSucess.Show();
        
        await Shell.Current.GoToAsync($"//{nameof(ProductsPage)}");
    }
}