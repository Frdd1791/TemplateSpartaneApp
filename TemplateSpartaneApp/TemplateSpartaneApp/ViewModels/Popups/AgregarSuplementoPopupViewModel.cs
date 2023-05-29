using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.ViewModels.Popups
{
    public class AgregarSuplementoPopupViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(AgregarSuplementoPopupViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand CloseCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand SelectedChangedCommand { get; set; }
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

        private int selectedIndexPorcion;
        public int SelectedIndexPorcion
        {
            get => selectedIndexPorcion;
            set
            {
                SetProperty(ref selectedIndexPorcion, value);
            }
        }

        private string textPorcion;
        public string TextPorcion
        {
            get => textPorcion;
            set
            {
                SetProperty(ref textPorcion, value);
            }
        }

        private string entryPorcion;
        public string EntryPorcion
        {
            get => entryPorcion;
            set
            {
                SetProperty(ref entryPorcion, value);
            }
        }

        private string placeHolderPorcion;
        public string PlaceHolderPorcion
        {
            get => placeHolderPorcion;
            set
            {
                SetProperty(ref placeHolderPorcion, value);
            }
        }

        #endregion


        #region Contructor
        public AgregarSuplementoPopupViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            CloseCommand = new DelegateCommand(CloseCommandExecuted);
            NextCommand = new DelegateCommand(NextCommandExecuted);
            SelectedChangedCommand = new DelegateCommand(SelectedChangedCommandExecuted);
            EntryPorcion = "False";
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

        private void SelectedChangedCommandExecuted()
        {
            int indexSelected = SelectedIndexPorcion;

            if (indexSelected == 0)
            {
                TextPorcion = "Ml que quiere aportar al dia";
                PlaceHolderPorcion = "ml";
            }
            else
            {
                TextPorcion = "Gramos que quiere aportar al dia";
                PlaceHolderPorcion = "gr";
            }
            EntryPorcion = "True";
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
