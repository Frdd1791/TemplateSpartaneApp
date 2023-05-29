using System;
using TemplateSpartaneApp.Abstractions;
using System.Collections.Generic;
using System.Text;
using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;

namespace TemplateSpartaneApp.ViewModels.RegistroPago
{
    public class ValidarCuentaPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(ValidarCuentaPageViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand ValidarCommand { get; set; }
        #endregion


        #region Contructor
        public ValidarCuentaPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            ValidarCommand = new DelegateCommand(ValidarCommandExecuted);
        }
        #endregion

        #region Commands Methods
        private async void ValidarCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/InitTwo", UriKind.Absolute));
        }
        #endregion
    }
}
