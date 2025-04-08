using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventarioMobile.Models.Response;
using InventarioMobile.Repositories.Product;

namespace InventarioMobile.ViewModels;
public partial class ProductViewModel: BaseViewModel
{
    public ObservableCollection<ProductResponse> Products { get; set; } = new ObservableCollection<ProductResponse>();

    private readonly IProductRepository _productRepository;

    public ProductViewModel(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    internal async Task InitAsync()
    {
        IsBusy = true;
        Products.Clear();

        var products = await _productRepository.GetProductsAsync();
        foreach (var product in products)
            Products.Add(product);

        IsBusy = false;
    }

    [RelayCommand]
    public async Task GotoAddProduct() => await Shell.Current.GoToAsync(nameof(AddProductPage));

    [RelayCommand]
    public async Task GoToEditCommand(ProductResponse product) {

        if (product is null)
            return;

        var navigationParams = new Dictionary<string, object>
        {
            {"Product", product }
        };

        await Shell.Current.GoToAsync(nameof(EditProductPage), navigationParams); 
    
    }
}
