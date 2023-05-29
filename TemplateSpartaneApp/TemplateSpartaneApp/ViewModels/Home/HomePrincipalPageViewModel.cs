using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.LocalData;
using TemplateSpartaneApp.ViewModels.RegistroPago;
using Xamarin.Forms;

namespace TemplateSpartaneApp.ViewModels.Home
{
    public class HomePrincipalPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(HomePrincipalPageViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand PagarCommand { get; set; }
        #endregion


        #region Contructor
        public HomePrincipalPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
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
