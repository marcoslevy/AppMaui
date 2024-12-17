using InventarioMobile.Models.Response;
using InventarioMobile.Repositorios.Product;

namespace InventarioMobile.ViewModels
{
    public partial class ProductsViewModel : BaseViewModel
    {
        public ObservableCollection<ProductResponse> Products { get; set; }
            = new ObservableCollection<ProductResponse>();

        private readonly IProductRepositorio _productRepositorio;
        public ProductsViewModel(IProductRepositorio productRepositorio)
        {
            _productRepositorio = productRepositorio;
        }

        internal async Task InitiAsync()
        {
            IsBusy = true;

            var products = await _productRepositorio.GetProductsAsync();

            Products.Clear();

            foreach (var product in products)
                Products.Add(product);

            IsBusy = false;
        }

        [RelayCommand]
        public async Task GoToAddProduct()
            => await Shell.Current.GoToAsync(nameof(AddProductPage));

        [RelayCommand]
        public async Task GoToEdit(ProductResponse product)
        { 
            if(product is null)
                return;

            var navigationParams = new Dictionary<string, object>
            {
                {"Product", product }
            };

            await Shell.Current.GoToAsync(nameof(EditProductPage), navigationParams);
        }
    }
}
