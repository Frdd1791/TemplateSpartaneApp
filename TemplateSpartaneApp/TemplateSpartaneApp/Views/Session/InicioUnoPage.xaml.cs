using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateSpartaneApp.Views.Session
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioUnoPage : ContentPage
    {
        public InicioUnoPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}