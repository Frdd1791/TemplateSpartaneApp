using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateSpartaneApp.Views.ProductosNutricionales.Oral
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductosOralesPage : ContentPage
    {
        public ProductosOralesPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}