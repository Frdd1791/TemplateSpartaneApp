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
        #endregion


        #region Contructor
        public ProductosNutricionalesPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            ProductosOralesCommand = new DelegateCommand(() => NavigationService.NavigateAsync("ProductosOrales"));
            ProductosEnteralesCommand = new DelegateCommand(() => NavigationService.NavigateAsync("ProductosEnterales"));
            ProductosParenteralesCommand = new DelegateCommand(() => NavigationService.NavigateAsync("ProductosParenterales"));
        }
        #endregion

        #region Commands Methods
        #endregion
    }
}
