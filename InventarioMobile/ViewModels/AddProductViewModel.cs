using CommunityToolkit.Maui.Alerts;
using InventarioMobile.Contratos;
using InventarioMobile.Models.Request;
using InventarioMobile.Repositorios.Product;
using System.Text;

namespace InventarioMobile.ViewModels
{
    public partial class AddProductViewModel : BaseViewModel
    {
        [ObservableProperty]
        string barcode;

        [ObservableProperty]
        string descricao;

        [ObservableProperty]
        int? estoque;

        [ObservableProperty]
        double? preco;

        private readonly IProductRepositorio _productRepositorio;
        public AddProductViewModel(IProductRepositorio productRepositorio)
        {
            _productRepositorio = productRepositorio;
        }

        [RelayCommand]
        public async Task Save()
        {
            var productRequest = new ProductRequest
                (
                    Descricao,
                    Estoque.Value,
                    Barcode,
                    "Unidade",
                    Preco.Value,
                    DateTime.Now
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

            var result = await _productRepositorio.AddAsync(productRequest);

            if (!result)
            {
                var toast = Toast.Make("Falha ao cadastrar o produto, tente novamente.",
                    CommunityToolkit.Maui.Core.ToastDuration.Long);

                await toast.Show();
                return;
            }

            var toastSuccess = Toast.Make("Produto cadastrado com sucesso!", CommunityToolkit.Maui.Core.ToastDuration.Long);
            await toastSuccess.Show();

            await Shell.Current.GoToAsync("..");
        }
    }
}
