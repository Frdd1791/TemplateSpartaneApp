using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateSpartaneApp.Views.Home
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePrincipal : MasterDetailPage
    {
		public HomePrincipal ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}