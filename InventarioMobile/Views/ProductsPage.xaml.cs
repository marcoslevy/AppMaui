namespace InventarioMobile.Views;

public partial class ProductsPage : ContentPage
{
    private ProductsViewModel _viewModel;
    public ProductsPage(ProductsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitiAsync();
    }
}