using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateSpartaneApp.Views.Evaluacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EvaluacionPageUno : ContentPage
    {
        public EvaluacionPageUno()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}