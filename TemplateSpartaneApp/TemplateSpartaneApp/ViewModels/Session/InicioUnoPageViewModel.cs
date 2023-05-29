using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.Models.Catalogs;
using TemplateSpartaneApp.Services.Session;

namespace TemplateSpartaneApp.ViewModels.Session
{
    public class InicioUnoPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(InicioUnoPageViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand NextPageCommand { get; set; }
        #endregion


        #region Contructor
        public InicioUnoPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            NextPageCommand = new DelegateCommand(NextPageCommandExecuted);
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
