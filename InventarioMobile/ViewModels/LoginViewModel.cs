using CommunityToolkit.Maui.Alerts;
using InventarioMobile.Contratos;
using InventarioMobile.Helpers;
using InventarioMobile.Models.Request;
using InventarioMobile.Repositorios.Login;
using System.Text;

namespace InventarioMobile.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        string email;

        [ObservableProperty]
        string senha;

        private readonly ILoginRepositorio _loginRepositorio;
        public LoginViewModel(ILoginRepositorio loginRepositorio)
        {
            _loginRepositorio = loginRepositorio;
        }

        [RelayCommand]
        public async Task GotoSignup()
            => await Shell.Current.GoToAsync(nameof(SignupPage));

        [RelayCommand]
        public async Task Login()
        {
            var loginRequest = new LoginRequest(Email, Senha);

            var contract = new LoginContract(loginRequest);

            if(!contract.IsValid)
            {
                var messages = contract.Notifications.Select(x => x.Message);
                var sb = new StringBuilder();

                foreach (var message in messages)
                    sb.Append($"{message}\n");

                await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "OK");
                return;
            }


            var result = await _loginRepositorio.LoginAsync(loginRequest);

            if (result is null || string.IsNullOrEmpty(result.accessToken))
            {
                var toast = Toast.Make("Falha ao realizar login, tenta novamente!", CommunityToolkit.Maui.Core.ToastDuration.Long);
                await toast.Show();
                return;
            }

            SessionHelper.SaveToken(result.accessToken, DateTime.Now.AddDays(1));
            await Shell.Current.GoToAsync($"//{nameof(ProductsPage)}");
        }
    }
}
