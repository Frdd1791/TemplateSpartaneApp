using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.ViewModels.RegistroPago
{
    public class PagoApplePageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(PagoApplePageViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand PagarCommand { get; set; }
        #endregion


        #region Contructor
        public PagoApplePageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            PagarCommand = new DelegateCommand(PagarCommandExecuted);
        }
        #endregion

        #region Commands Methods
        private async void PagarCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/InitTwo", UriKind.Absolute));
        }
        #endregion
    }
}
