namespace InventarioMobile.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty] string nome;

    public MainViewModel()
    {
        Nome = "Hello, World!";
    }
}
