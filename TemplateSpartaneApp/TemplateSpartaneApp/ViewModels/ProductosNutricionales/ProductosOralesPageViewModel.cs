using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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
        public DelegateCommand NextPageCommand { get; set; }
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
            ItemsProductosOrales = new ObservableCollectionExt<ProductosOrales>()
            {
                new ProductosOrales{ ImageProduct="deslizar_black.png", NombreProducto="Ensure" },
                new ProductosOrales{ ImageProduct="logo.png", NombreProducto="Advance active" },
                new ProductosOrales{ ImageProduct="logo.png", NombreProducto="Producto 3" },
                new ProductosOrales{ ImageProduct="logo.png", NombreProducto="Producto 4" },
                new ProductosOrales{ ImageProduct="logo.png", NombreProducto = "Producto 5" }
            };
        }
        #endregion

        #region Commands Methods
        private async void NextPageCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/InitTwo", UriKind.Absolute));
        }

        private void SelectProductCommandExecute(object item)
        {
            if (item is ProductosOrales)
            {
                ProductSelected = (ProductosOrales)item;
                Debug.WriteLine(ProductSelected.NombreProducto);
            }
        }
        #endregion

        #region Methods Life Cycle Page
        public class ListProductos
        {
            public string ImageProduct { get; set; }
            public string NombreProducto { get; set; }
        }
        #endregion
    }
}
