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
    public partial class ProductoOralPage : ContentPage
    {
        public ProductoOralPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}