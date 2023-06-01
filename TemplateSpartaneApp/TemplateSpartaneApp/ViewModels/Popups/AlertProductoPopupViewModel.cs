using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.LocalData;

namespace TemplateSpartaneApp.ViewModels.Popups
{
    public class AlertProductoPopupViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(AlertProductoPopupViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand CloseCommand { get; set; }
        #endregion


        #region Contructor
        public AlertProductoPopupViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            CloseCommand = new DelegateCommand(CloseCommandExecuted);
        }
        #endregion

        #region Methods
        #endregion

        #region Commands Methods
        private async void CloseCommandExecuted()
        {
            AppSettings.Instance.isAviso = true;
            await NavigationService.GoBackAsync();
        }
        #endregion

        #region Methods Life Cycle Page
        #endregion
    }
}
