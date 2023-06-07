using System;
using TemplateSpartaneApp.Abstractions;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TemplateSpartaneApp.ViewModels.RegistroPago
{
    public class ValidarCuentaPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(ValidarCuentaPageViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand ValidarCommand { get; set; }
        public DelegateCommand ReenviarCodigoCommand { get; set; }
        #endregion

        #region Properties
        private string codigo;
        public string Codigo
        {
            get { return codigo; }
            set
            {
                SetProperty(ref codigo, value);
            }
        }
        private string backgraoundColorHexEntry;
        public string BackgraoundColorHexEntry
        {
            get { return backgraoundColorHexEntry; }
            set
            {
                SetProperty(ref backgraoundColorHexEntry, value);
            }
        }
        #endregion


        #region Contructor
        public ValidarCuentaPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            ValidarCommand = new DelegateCommand(ValidarCommandExecuted);
            ReenviarCodigoCommand = new DelegateCommand(ReenviarCodigoCommandExecuted);
            BackgraoundColorHexEntry = "White";
        }
        #endregion

        #region Commands Methods
        private async void ValidarCommandExecuted()
        {
            string state = await ValidateEntry();
            if (string.IsNullOrEmpty(state))
            {
                if (int.Parse(Codigo) == 1234)
                {
                    BackgraoundColorHexEntry = "#10BA52";
                    await NavigationService.NavigateAsync("PagoAndroid");
                }
            }
            else
            {
                UserDialogsService.Alert(state, "Alerta", "Aceptar");
            }
            UserDialogsService.HideLoading();
        }

        public async Task<string> ValidateEntry()
        {
            string state = "";

            if (string.IsNullOrEmpty(Codigo))
            {
                state = "Tiene que ingresar el codigo enviado a su correo!";
            }
            return state;
        }

        private void ReenviarCodigoCommandExecuted()
        {

        }
        #endregion
    }
}
