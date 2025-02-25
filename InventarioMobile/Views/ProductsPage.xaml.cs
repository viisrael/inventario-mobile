namespace InventarioMobile.Views;

public partial class ProductsPage : ContentPage
{
    private ProductViewModel _viewModel;
	public ProductsPage(ProductViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitAsync();
    }
}