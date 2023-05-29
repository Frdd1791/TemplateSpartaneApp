using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateSpartaneApp.ViewModels.RegistroPago
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ValidarCuentaPage : ContentPage
    {
        public ValidarCuentaPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}