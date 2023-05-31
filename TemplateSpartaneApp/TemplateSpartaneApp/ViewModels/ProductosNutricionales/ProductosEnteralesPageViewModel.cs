using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.Models.ProductosEnterales;
using TemplateSpartaneApp.Models.ProductosOrales;

namespace TemplateSpartaneApp.ViewModels.ProductosNutricionales
{
    public class ProductosEnteralesPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(ProductosEnteralesPageViewModel);
        private ProductosEnteralesModel ProductSelected { get; set; }
        #endregion

        #region Vars Commands
        public DelegateCommand ButtonBackCommand { get; set; }
        public DelegateCommand<object> SelectProduct { get; private set; }
        #endregion

        #region Properties
        private ObservableCollectionExt<ProductosEnteralesModel> itemsProductosEnterales;
        public ObservableCollectionExt<ProductosEnteralesModel> ItemsProductosEnterales
        {
            get { return itemsProductosEnterales; }
            set
            {
                SetProperty(ref itemsProductosEnterales, value);
            }

        }

        private string isVisibleBackButton;
        public string IsVisibleBackButton
        {
            get { return isVisibleBackButton; }
            set
            {
                SetProperty(ref isVisibleBackButton, value);
            }
        }

        #endregion


        #region Contructor
        public ProductosEnteralesPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            SelectProduct = new DelegateCommand<object>(SelectProductCommandExecute);
            CreatedListProductos();
        }
        #endregion

        #region Methods
        private void CreatedListProductos()
        {
            IsVisibleBackButton = "True";
            ButtonBackCommand = new DelegateCommand(ButtonBackCommandExecuted);
            ItemsProductosEnterales = new ObservableCollectionExt<ProductosEnteralesModel>()
            {
                new ProductosEnteralesModel{ Id=0, ImageProduct="deslizar_black.png", NombreProducto="Ensure" },
                new ProductosEnteralesModel{ Id=1, ImageProduct="logo.png", NombreProducto="Advance active" },
                new ProductosEnteralesModel{ Id=2, ImageProduct="logo.png", NombreProducto="Producto 3" },
                new ProductosEnteralesModel{ Id=3, ImageProduct="logo.png", NombreProducto="Producto 4" },
                new ProductosEnteralesModel{  Id=4, ImageProduct="logo.png", NombreProducto = "Producto 5" }
            };

            LoadAlert();
        }
        #endregion

        #region Commands Methods
        private async void NextPageCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/InitTwo", UriKind.Absolute));
        }

        private async void SelectProductCommandExecute(object item)
        {
            if (item is ProductosEnteralesModel)
            {
                ProductSelected = (ProductosEnteralesModel)item;
                Debug.WriteLine(ProductSelected.Id);
            }
            await NavigationService.NavigateAsync(new Uri("/Navigation/ProductoEnteral", UriKind.Absolute));
        }
        private async void LoadAlert()
        {
            await Task.Delay(1000);
            await NavigationService.NavigateAsync("AlertProducto");
        }

        private async void ButtonBackCommandExecuted()
        {
            Debug.WriteLine("press");
            await NavigationService.NavigateAsync(new Uri("/Index/Navigation/ProductosNutricionales", UriKind.Absolute));
        }
        #endregion

        #region Methods Life Cycle Page
        #endregion
    }
}
