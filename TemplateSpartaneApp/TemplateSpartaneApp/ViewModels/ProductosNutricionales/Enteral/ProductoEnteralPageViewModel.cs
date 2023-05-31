using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.ViewModels.ProductosNutricionales.Enteral
{
    public class ProductoEnteralPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(ProductoEnteralPageViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand ButtonBackCommand { get; set; }
        #endregion


        #region Contructor
        public ProductoEnteralPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            ButtonBackCommand = new DelegateCommand(ButtonBackCommandExecuted);
        }
        #endregion

        #region Commands Methods
        private async void ButtonBackCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Index/Navigation/ProductosOrales", UriKind.Absolute));
        }
        #endregion
    }
}
