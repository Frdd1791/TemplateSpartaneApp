using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.ViewModels.Session
{
    public class InicioTresPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(InicioTresPageViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand NextPageCommand { get; set; }
        #endregion


        #region Contructor
        public InicioTresPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            NextPageCommand = new DelegateCommand(NextPageCommandExecuted);
        }
        #endregion

        #region Commands Methods
        private async void NextPageCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Index/Navigation/Home", UriKind.Absolute));
        }
        #endregion
    }
}
