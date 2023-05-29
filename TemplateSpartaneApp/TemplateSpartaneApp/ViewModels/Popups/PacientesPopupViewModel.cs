using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.ViewModels.Evaluacion;
using Xamarin.Forms;
using static TemplateSpartaneApp.ViewModels.Pacientes.PacientesPageViewModel;

namespace TemplateSpartaneApp.ViewModels.Popups
{
    public class PacientesPopupViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(PacientesPopupViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand CloseCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
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


        #region Contructor
        public PacientesPopupViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            CloseCommand = new DelegateCommand(CloseCommandExecuted);
            NextCommand = new DelegateCommand(NextCommandExecuted);
            CreatedListPacientes();
        }
        #endregion

        #region Methods
        private void CreatedListPacientes()
        {
            ItemsList = new ObservableCollectionExt<ListPacientes>()
            {
                new ListPacientes{ Name="Mariana Estefania Calle Mendoza" },
                new ListPacientes{ Name="Alberto Julian Martinez Jativa" },
                new ListPacientes{ Name="Carmen Anthonella Casanova Rivas"},
                new ListPacientes{ Name="Melissa Fabiola Vera Gomez"},
                new ListPacientes{ Name="Mariana Estefania Calle Mendoza" },
                new ListPacientes{ Name="Alberto Julian Martinez Jativa" },
                new ListPacientes{ Name="Carmen Anthonella Casanova Rivas" }
            };
        }
        #endregion

        #region Commands Methods
        private async void CloseCommandExecuted()
        {
            await NavigationService.GoBackAsync();
        }
        private async void NextCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/InitTwo", UriKind.Absolute));
        }
        #endregion

        #region Methods Life Cycle Page
        public class ListPacientes
        {
            public string Name { get; set; }
        }
        #endregion
    }
}
