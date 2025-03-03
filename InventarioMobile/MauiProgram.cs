using Camera.MAUI;
using InventarioMobile.Repositories.Login;
using InventarioMobile.Repositories.Product;
using InventarioMobile.Repositories.Signup;

namespace InventarioMobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCameraView()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//-- ViewModels
		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<SignupViewModel>();
		builder.Services.AddTransient<ProductViewModel>();
		builder.Services.AddTransient<AddProductViewModel>();

        //-- Views
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<SignupPage>();
        builder.Services.AddTransient<ProductsPage>();
        builder.Services.AddTransient<AddProductPage>();

        //-- Repositories
        builder.Services.AddScoped<ILoginRepository, LoginRepository>();
        builder.Services.AddScoped<ISignupRepository, SignupRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();

		return builder.Build();
	}
}
