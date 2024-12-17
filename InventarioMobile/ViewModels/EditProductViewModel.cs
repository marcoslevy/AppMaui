using CommunityToolkit.Maui.Alerts;
using InventarioMobile.Contratos;
using InventarioMobile.Models.Request;
using InventarioMobile.Models.Response;
using InventarioMobile.Repositorios.Product;
using System.Text;

namespace InventarioMobile.ViewModels
{
    [QueryProperty(nameof(Product), nameof(Product))]
    public partial class EditProductViewModel : BaseViewModel
    {
        private ProductResponse _product;
        public ProductResponse Product
        {
            get => _product;
            set 
            {
                SetProperty(ref _product, value);

                if(value != null)
                { 
                    ProductId = value.ProductId;
                    Barcode = value.Barcode;
                    Descricao = value.Descricao;
                    Estoque = value.Estoque;
                    Preco = value.Preco;
                }
            }
        }


        [ObservableProperty]
        Guid productId;

        [ObservableProperty]
        string barcode;

        [ObservableProperty]
        string descricao;

        [ObservableProperty]
        int? estoque;

        [ObservableProperty]
        double? preco;

        private readonly IProductRepositorio _productRepositorio;
        public EditProductViewModel(IProductRepositorio productRepositorio)
        {
            _productRepositorio = productRepositorio;
        }

        public async Task GetInfoProductAsync(string barcode)
        {
            var product = await _productRepositorio.GetProductByBarCodeAsync(barcode);

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
            var productRequest = new ProductRequest
                (
                ProductId,
                Descricao,
                Estoque.Value,
                Barcode,
                Preco.Value
                );

            var contract = new ProductContract(productRequest);

            if (!contract.IsValid)
            {
                var messages = contract.Notifications.Select(x => x.Message);
                var sb = new StringBuilder();

                foreach (var mesage in messages)
                    sb.Append($"{mesage}\n");

                await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "OK");
                return;
            }

            var result = await _productRepositorio.UpdateAsync(productRequest);

            if (!result)
            {
                var toast = Toast.Make("Falha ao atualizar o estoque, tente novamente.",
                    CommunityToolkit.Maui.Core.ToastDuration.Long);
                await toast.Show();

                return;
            }

            var toastSuccess = Toast.Make("Estoque atualizado com sucesso.",
                CommunityToolkit.Maui.Core.ToastDuration.Long);
            await toastSuccess.Show();

            await Shell.Current.GoToAsync($"//{nameof(ProductsPage)}");
        }
    }
}
