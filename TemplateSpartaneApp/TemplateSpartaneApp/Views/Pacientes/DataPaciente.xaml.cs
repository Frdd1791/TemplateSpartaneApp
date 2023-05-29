using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateSpartaneApp.Views.Pacientes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPaciente : ContentPage
    {
        public DataPaciente()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}