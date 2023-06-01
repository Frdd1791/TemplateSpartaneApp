using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.ViewModels.Session;

namespace TemplateSpartaneApp.ViewModels.RegistroPago
{
    public class RegistroPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(RegistroPageViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand NextPageCommand { get; set; }
        public DelegateCommand ShowPageLoginCommand { get; set; }
        #endregion


        #region Contructor
        public RegistroPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            NextPageCommand = new DelegateCommand(NextPageCommandExecuted);
            ShowPageLoginCommand = new DelegateCommand(() => NavigationService.NavigateAsync("LogIn"));
        }
        #endregion

        #region Commands Methods
        private async void NextPageCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/InitTwo", UriKind.Absolute));
        }

        #endregion
    }
}
