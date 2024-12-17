using Camera.MAUI;
using InventarioMobile.Repositorios.Login;
using InventarioMobile.Repositorios.Product;
using InventarioMobile.Repositorios.Signup;

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

        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<SignupViewModel>();
        builder.Services.AddTransient<ProductsViewModel>();
        builder.Services.AddTransient<AddProductViewModel>();
        builder.Services.AddTransient<EditProductViewModel>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<SignupPage>();
        builder.Services.AddTransient<ProductsPage>();
        builder.Services.AddTransient<AddProductPage>();
        builder.Services.AddTransient<EditProductPage>();

        builder.Services.AddScoped<ILoginRepositorio, LoginRepositorio>();
        builder.Services.AddScoped<ISignupRepositorio, SignupRepositorio>();
        builder.Services.AddScoped<IProductRepositorio, ProductRepositorio>();

        return builder.Build();
    }
}
