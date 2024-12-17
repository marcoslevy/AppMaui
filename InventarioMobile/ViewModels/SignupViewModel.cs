using CommunityToolkit.Maui.Alerts;
using InventarioMobile.Contratos;
using InventarioMobile.Models.Request;
using InventarioMobile.Repositorios.Signup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioMobile.ViewModels
{
    public partial class SignupViewModel : BaseViewModel
    {
        [ObservableProperty]
        string nome;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string senha;

        private readonly ISignupRepositorio _signupRepositorio;
        public SignupViewModel(ISignupRepositorio signupRepositorio)
        {
            _signupRepositorio = signupRepositorio;
        }

        [RelayCommand]
        public async Task Signup()
        {
            var request = new SignupRequest(Nome, Email, Senha);

            var contract = new SignupContract(request);

            if (!contract.IsValid)
            {
                var messages = contract.Notifications.Select(x => x.Message);
                var sb = new StringBuilder();

                foreach (var message in messages)
                    sb.Append($"{message}\n");

                await Shell.Current.DisplayAlert("Atenção", sb.ToString(), "OK");
                return;
            }

            var result = await _signupRepositorio.CreateAsync(request);

            if (result)
            {
                var toast = Toast
                    .Make("Usuário cadastrado com sucesso!", CommunityToolkit.Maui.Core.ToastDuration.Long);

                await toast.Show();

                await Shell.Current.GoToAsync("..");
            }
            else
            {
                var toast = Toast
                    .Make("Erro ao cadastrar usuário!", CommunityToolkit.Maui.Core.ToastDuration.Long);

                await toast.Show();
            }
        }
    }
}
