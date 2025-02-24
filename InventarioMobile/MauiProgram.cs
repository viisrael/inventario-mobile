using InventarioMobile.Repositories.Login;

namespace InventarioMobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//-- ViewModels
		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<LoginViewModel>();

        //-- Views
        builder.Services.AddTransient<MainPage>();

        //-- Repositories
        builder.Services.AddScoped<ILoginRepository, LoginRepository>();

		return builder.Build();
	}
}
