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

namespace TemplateSpartaneApp.ViewModels.ProductosNutricionales
{
    public class ProductoOralSeleccionadoPageVideModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(ProductoOralSeleccionadoPageVideModel);
        #endregion

        #region Vars Commands
        public DelegateCommand ButtonBackCommand { get; set; }
        #endregion


        #region Contructor
        public ProductoOralSeleccionadoPageVideModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            ButtonBackCommand = new DelegateCommand(ButtonBackCommandExecuted);
        }
        #endregion

        #region Commands Methods
        private async void ButtonBackCommandExecuted()
        {
            Debug.WriteLine("press");
            await NavigationService.NavigateAsync(new Uri("/Index/Navigation/ProductosOrales", UriKind.Absolute));
        }
        #endregion
    }
}
