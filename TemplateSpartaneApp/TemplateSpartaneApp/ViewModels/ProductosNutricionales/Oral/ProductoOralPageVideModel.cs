using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.ViewModels.Session;

namespace TemplateSpartaneApp.ViewModels.ProductosNutricionales.Oral
{
    public class ProductoOralPageVideModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(ProductoOralPageVideModel);
        #endregion

        #region Vars Commands
        public DelegateCommand ButtonBackCommand { get; set; }
        #endregion


        #region Contructor
        public ProductoOralPageVideModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
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
