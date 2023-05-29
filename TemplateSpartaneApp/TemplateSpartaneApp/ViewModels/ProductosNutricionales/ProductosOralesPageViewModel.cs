using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.Models.ProductosOrales;

namespace TemplateSpartaneApp.ViewModels.ProductosNutricionales
{
    public class ProductosOralesPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(ProductosOralesPageViewModel);
        private ProductosOrales ProductSelected { get; set; }
        #endregion

        #region Vars Commands
        public DelegateCommand ButtonBackCommand { get; set; }
        public DelegateCommand<object> SelectProduct { get; private set; }
        #endregion

        #region Properties
        private ObservableCollectionExt<ProductosOrales> itemsProductosOrales;
        public ObservableCollectionExt<ProductosOrales> ItemsProductosOrales
        {
            get { return itemsProductosOrales; }
            set
            {
                SetProperty(ref itemsProductosOrales, value);
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
        public ProductosOralesPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
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
            ItemsProductosOrales = new ObservableCollectionExt<ProductosOrales>()
            {
                new ProductosOrales{ Id=0, ImageProduct="deslizar_black.png", NombreProducto="Ensure" },
                new ProductosOrales{ Id=1, ImageProduct="logo.png", NombreProducto="Advance active" },
                new ProductosOrales{ Id=2, ImageProduct="logo.png", NombreProducto="Producto 3" },
                new ProductosOrales{ Id=3, ImageProduct="logo.png", NombreProducto="Producto 4" },
                new ProductosOrales{  Id=4, ImageProduct="logo.png", NombreProducto = "Producto 5" }
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
            if (item is ProductosOrales)
            {
                ProductSelected = (ProductosOrales)item;
                Debug.WriteLine(ProductSelected.Id);
            }
            await NavigationService.NavigateAsync(new Uri("/Navigation/ProductoOral", UriKind.Absolute));
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
        /*public class ListProductos
        {
            public string ImageProduct { get; set; }
            public string NombreProducto { get; set; }
        }*/
        #endregion
    }
}
