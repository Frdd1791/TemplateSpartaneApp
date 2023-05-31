using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.ViewModels.Session;

namespace TemplateSpartaneApp.ViewModels.ProductosNutricionales
{
    public class ProductosNutricionalesPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(ProductosNutricionalesPageViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand ProductosOralesCommand { get; set; }
        public DelegateCommand ProductosEnteralesCommand { get; set; }
        public DelegateCommand ProductosParenteralesCommand { get; set; }
        public DelegateCommand ButtonBackCommand { get; set; }
        #endregion


        #region Contructor
        public ProductosNutricionalesPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            ProductosOralesCommand = new DelegateCommand(ProductosOralesCommandExecuted);
            ProductosEnteralesCommand = new DelegateCommand(ProductosEnteralesCommandExecuted);
            ProductosParenteralesCommand = new DelegateCommand(ProductosParenteralesCommandExecuted);
            ButtonBackCommand = new DelegateCommand(ButtonBackCommandExecuted);
        }
        #endregion

        #region Commands Methods
        private async void ButtonBackCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri($"/Index/Navigation/Home", UriKind.Absolute));
        }
        private async void ProductosOralesCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/ProductosOrales", UriKind.Absolute));
        }

        private async void ProductosEnteralesCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/ProductosEnterales", UriKind.Absolute));
        }

        private async void ProductosParenteralesCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/ProductosParenterales", UriKind.Absolute));
        }
        #endregion
    }
}
