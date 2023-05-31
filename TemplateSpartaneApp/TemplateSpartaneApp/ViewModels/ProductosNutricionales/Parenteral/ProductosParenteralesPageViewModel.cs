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
using TemplateSpartaneApp.Models.ProductosParenterales;

namespace TemplateSpartaneApp.ViewModels.ProductosNutricionales.Parenteral
{
    public class ProductosParenteralesPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(ProductosParenteralesPageViewModel);
        private ProductosParenteralesModel ProductSelected { get; set; }
        #endregion

        #region Vars Commands
        public DelegateCommand ButtonBackCommand { get; set; }
        public DelegateCommand<object> SelectProduct { get; private set; }
        #endregion

        #region Properties
        private ObservableCollectionExt<ProductosParenteralesModel> itemsProductosParenterales;
        public ObservableCollectionExt<ProductosParenteralesModel> ItemsProductosParenterales
        {
            get { return itemsProductosParenterales; }
            set
            {
                SetProperty(ref itemsProductosParenterales, value);
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
        public ProductosParenteralesPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
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
            ItemsProductosParenterales = new ObservableCollectionExt<ProductosParenteralesModel>()
            {
                new ProductosParenteralesModel{ Id=0, ImageProduct="deslizar_black.png", NombreProducto="Ensure" },
                new ProductosParenteralesModel{ Id=1, ImageProduct="logo.png", NombreProducto="Advance active" },
                new ProductosParenteralesModel{ Id=2, ImageProduct="logo.png", NombreProducto="Producto 3" },
                new ProductosParenteralesModel{ Id=3, ImageProduct="logo.png", NombreProducto="Producto 4" },
                new ProductosParenteralesModel{  Id=4, ImageProduct="logo.png", NombreProducto = "Producto 5" }
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
            if (item is ProductosParenteralesModel)
            {
                ProductSelected = (ProductosParenteralesModel)item;
                Debug.WriteLine(ProductSelected.Id);
            }
            await NavigationService.NavigateAsync(new Uri("/Navigation/ProductoParenteral", UriKind.Absolute));
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
