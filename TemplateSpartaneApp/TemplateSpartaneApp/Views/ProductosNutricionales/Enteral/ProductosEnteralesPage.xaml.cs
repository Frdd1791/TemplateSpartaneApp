using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateSpartaneApp.Views.ProductosNutricionales.Enteral
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductosEnteralesPage : ContentPage
    {
        public ProductosEnteralesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}