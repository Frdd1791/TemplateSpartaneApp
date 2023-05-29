using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateSpartaneApp.Views.ProductosNutricionales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductoOralSeleccionadoPage : ContentPage
    {
        public ProductoOralSeleccionadoPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}