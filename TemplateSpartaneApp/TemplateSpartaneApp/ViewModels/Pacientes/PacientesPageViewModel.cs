using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.ViewModels.RegistroPago;
using Xamarin.Forms;
using static TemplateSpartaneApp.ViewModels.Home.MainPageViewModel;

namespace TemplateSpartaneApp.ViewModels.Pacientes
{
    public class PacientesPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(PacientesPageViewModel);
        #endregion

        #region Properties
        private ObservableCollectionExt<ListPacientes> itemsList;
        public ObservableCollectionExt<ListPacientes> ItemsList
        {
            get { return itemsList; }
            set
            {
                SetProperty(ref itemsList, value);
            }

        }

        #endregion

        #region Vars Commands
        public DelegateCommand PagarCommand { get; set; }
        #endregion


        #region Contructor
        public PacientesPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            PagarCommand = new DelegateCommand(PagarCommandExecuted);
            CreatedListPacientes();
        }
        #endregion

        #region Methods
        private void CreatedListPacientes()
        {
            ItemsList = new ObservableCollectionExt<ListPacientes>()
            {
                new ListPacientes{ Name="Mariana Estefania Calle Mendoza", Icon="usuario.png" },
                new ListPacientes{ Name="Alberto Julian Martinez Jativa", Icon="usuario.png" },
                new ListPacientes{ Name="Carmen Anthonella Casanova Rivas", Icon="usuario.png"},
                new ListPacientes{ Name="Melissa Fabiola Vera Gomez", Icon="usuario.png"},
                new ListPacientes{ Name="Mariana Estefania Calle Mendoza", Icon="usuario.png" },
                new ListPacientes{ Name="Alberto Julian Martinez Jativa", Icon="usuario.png" },
                new ListPacientes{ Name="Carmen Anthonella Casanova Rivas", Icon="usuario.png"},
                new ListPacientes{ Name="Melissa Fabiola Vera Gomez", Icon="usuario.png"},
                new ListPacientes{ Name="Mariana Estefania Calle Mendoza", Icon="usuario.png" },
                new ListPacientes{ Name="Alberto Julian Martinez Jativa", Icon="usuario.png" },
                new ListPacientes{ Name="Carmen Anthonella Casanova Rivas", Icon="usuario.png"},
                new ListPacientes{ Name="Melissa Fabiola Vera Gomez", Icon="usuario.png"},
                new ListPacientes{ Name="Mariana Estefania Calle Mendoza", Icon="usuario.png" },
                new ListPacientes{ Name="Alberto Julian Martinez Jativa", Icon="usuario.png" },
                new ListPacientes{ Name="Carmen Anthonella Casanova Rivas", Icon="usuario.png"},
                new ListPacientes{ Name="Melissa Fabiola Vera Gomez", Icon="usuario.png"},
                new ListPacientes{ Name="Mariana Estefania Calle Mendoza", Icon="usuario.png" },
                new ListPacientes{ Name="Alberto Julian Martinez Jativa", Icon="usuario.png" },
                new ListPacientes{ Name="Carmen Anthonella Casanova Rivas", Icon="usuario.png"},
                new ListPacientes{ Name="Melissa Fabiola Vera Gomez", Icon="usuario.png"},
            };
        }
        #endregion

        #region Commands Methods
        private async void PagarCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/InitTwo", UriKind.Absolute));
        }
        #endregion

        #region Methods Life Cycle Page
        public class ListPacientes
        {
            public string Name { get; set; }
            public ImageSource Icon { get; set; }
        }
        #endregion
    }
}
