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
    public class InicioDosPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(InicioDosPageViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand NextPageCommand { get; set; }
        #endregion


        #region Contructor
        public InicioDosPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            NextPageCommand = new DelegateCommand(NextPageCommandExecuted);
        }
        #endregion

        #region Commands Methods
        private async void NextPageCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/InitThree", UriKind.Absolute));
        }
        #endregion
    }
}
