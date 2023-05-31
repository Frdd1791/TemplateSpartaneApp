using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.LocalData;

namespace TemplateSpartaneApp.ViewModels.Session
{
    public class InicioTresPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(InicioTresPageViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand FreePlanCommand { get; set; }
        public DelegateCommand PremiumPlanCommand { get; set; }
        #endregion


        #region Contructor
        public InicioTresPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            FreePlanCommand = new DelegateCommand(FreePlanCommandExecuted);
            PremiumPlanCommand = new DelegateCommand(PremiumPlanCommandExecuted);
        }
        #endregion

        #region Commands Methods
        private async void FreePlanCommandExecuted()
        {
            AppSettings.Instance.Premium = false; 
            await NavigationService.NavigateAsync(new Uri("/Index/Navigation/Home", UriKind.Absolute));
        }
        private async void PremiumPlanCommandExecuted()
        {
            AppSettings.Instance.Premium = true;
            await NavigationService.NavigateAsync(new Uri("/Index/Navigation/Home", UriKind.Absolute));
        }
        #endregion
    }
}
