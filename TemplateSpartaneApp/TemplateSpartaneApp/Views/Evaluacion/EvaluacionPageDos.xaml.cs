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
	public partial class EvaluacionPageDos : ContentPage
	{
		public EvaluacionPageDos ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}