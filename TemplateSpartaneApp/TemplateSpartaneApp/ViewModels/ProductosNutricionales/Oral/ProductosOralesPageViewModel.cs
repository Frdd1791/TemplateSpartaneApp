using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.Helpers;
using TemplateSpartaneApp.LocalData;
using TemplateSpartaneApp.Models.ProductosOrales;
using TemplateSpartaneApp.Models.Spartane;
using TemplateSpartaneApp.Services.Spartane;

namespace TemplateSpartaneApp.ViewModels.ProductosNutricionales.Oral
{
    public class ProductosOralesPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(ProductosOralesPageViewModel);
        private ProductosOrales ProductSelected { get; set; }
        #endregion

        #region Vars Commands
        public DelegateCommand<object> SelectProduct { get; private set; }
        private readonly ISpartaneQueryService _spartaneQueryService;
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
        private ObservableCollection<OralesModel> itemsOrales;
        public ObservableCollection<OralesModel> ItemsOrales
        {
            get { return itemsOrales; }
            set
            {
                SetProperty(ref itemsOrales, value);
            }
        }

        private ObservableCollection<Verduras> itemsVerduras;
        public ObservableCollection<Verduras> ItemsVerduras
        {
            get { return itemsVerduras; }
            set
            {
                SetProperty(ref itemsVerduras, value);
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
        public ProductosOralesPageViewModel(INavigationService navigationService,
            ISpartaneQueryService spartaneQueryService,
            IUserDialogs userDialogsService,
            IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            _spartaneQueryService = spartaneQueryService;
            SelectProduct = new DelegateCommand<object>(SelectProductCommandExecute);
            CreatedListProductos();
        }
        #endregion

        #region Methods
        private async void CreatedListProductos()
        {   
            IsVisibleBackButton = "True";
            if (!AppSettings.Instance.isAviso)
            {
                LoadAlert();
            }

            var resp = await RunSafeApi(_spartaneQueryService.GetRawQuery<string>(new SpartaneQueryModel { Query = "exec sp_GetComplete_Productos_Nutricionales_Categoria 1" }));
            if (resp.Status == TypeReponse.Ok && !string.IsNullOrEmpty(resp.Response) && !resp.Response.ToLower().Equals("null"))
            {
                List<ProductosOrales> lista = GlobalMethods.DeserializeObjectWithSlashes<List<ProductosOrales>>(resp);
                ItemsProductosOrales = new ObservableCollectionExt<ProductosOrales>(lista);

                var productGroupedByCategoria = lista.GroupBy(item => item.Grupo_de_Alimentos_Descripcion);

                //foreach (var group in productGroupedByCategoria)
                //{
                //    Debug.WriteLine("Items from " + group.Key);
                //    foreach(var producto in group)
                //    {
                //        if (group.Key.Equals("Verduras"))
                //        {
                //            Debug.WriteLine(producto.Productos_Nutricionales_Nombre);
                //            ItemsVerduras.Add(new Verduras { Nombre = producto.Productos_Nutricionales_Nombre });
                //        }
                //    }
                //}
            }
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
                //Debug.WriteLine(ProductSelected.Id);
            }
            await NavigationService.NavigateAsync(new Uri("/Navigation/ProductoOral", UriKind.Absolute));
        }
        private async void LoadAlert()
        {
            await Task.Delay(1000);
            await NavigationService.NavigateAsync("AlertProducto");
        }
        #endregion

        #region Methods Life Cycle Page
        public class ListVerduras
        {
            List<Verduras> verduras { get; set; }
        }
        public class Verduras
        {
            public string Nombre { get; set; }
        }
        #endregion
    }
}
