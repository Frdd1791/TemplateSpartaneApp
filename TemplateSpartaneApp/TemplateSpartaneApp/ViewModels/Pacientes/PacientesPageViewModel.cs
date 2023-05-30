using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.Models.Pacientes;
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

        #region Vars Commans
        public DelegateCommand OnSelectItemCommand { get; set; }
        public DelegateCommand ButtonBackCommand { get; set; }
        #endregion

        #region Properties
        private ObservableCollectionExt<PacientesModel> itemsList;
        public ObservableCollectionExt<PacientesModel> ItemsList
        {
            get { return itemsList; }
            set
            {
                SetProperty(ref itemsList, value);
            }
        }

        public PacientesModel selectItemPaciente;
        public PacientesModel SelectItemPaciente
        {
            get { return selectItemPaciente; }
            set
            {
                SetProperty(ref selectItemPaciente, value);
                OnSelectItemCommand.Execute();
            }
        }

        #endregion


        #region Contructor
        public PacientesPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            ButtonBackCommand = new DelegateCommand(ButtonBackCommandExecuted);
            OnSelectItemCommand = new DelegateCommand(OnSelectItemCommandExecuted);
            CreatedListPacientes();
        }
        #endregion

        #region Methods
        private void CreatedListPacientes()
        {
            ItemsList = new ObservableCollectionExt<PacientesModel>()
            {
                new PacientesModel{ Name="Mariana Estefania Calle Mendoza", Icon="icon_pacientes.png" },
                new PacientesModel{ Name="Alberto Julian Martinez Jativa", Icon="icon_pacientes.png" },
                new PacientesModel{ Name="Carmen Anthonella Casanova Rivas", Icon="icon_pacientes.png"},
                new PacientesModel{ Name="Melissa Fabiola Vera Gomez", Icon="icon_pacientes.png"},
                new PacientesModel{ Name="Mariana Estefania Calle Mendoza", Icon="icon_pacientes.png" },
                new PacientesModel{ Name="Alberto Julian Martinez Jativa", Icon="icon_pacientes.png" },
                new PacientesModel{ Name="Carmen Anthonella Casanova Rivas", Icon="icon_pacientes.png"},
                new PacientesModel{ Name="Melissa Fabiola Vera Gomez", Icon="icon_pacientes.png"},
                new PacientesModel{ Name="Mariana Estefania Calle Mendoza", Icon="icon_pacientes.png" },
                new PacientesModel{ Name="Alberto Julian Martinez Jativa", Icon="icon_pacientes.png" },
                new PacientesModel{ Name="Carmen Anthonella Casanova Rivas", Icon="icon_pacientes.png"},
                new PacientesModel{ Name="Melissa Fabiola Vera Gomez", Icon="icon_pacientes.png"},
                new PacientesModel{ Name="Mariana Estefania Calle Mendoza", Icon="icon_pacientes.png" },
                new PacientesModel{ Name="Alberto Julian Martinez Jativa", Icon="icon_pacientes.png" },
                new PacientesModel{ Name="Carmen Anthonella Casanova Rivas", Icon="icon_pacientes.png"},
                new PacientesModel{ Name="Melissa Fabiola Vera Gomez", Icon="icon_pacientes.png"},
                new PacientesModel{ Name="Mariana Estefania Calle Mendoza", Icon="icon_pacientes.png" },
                new PacientesModel{ Name="Alberto Julian Martinez Jativa", Icon="icon_pacientes.png" },
                new PacientesModel{ Name="Carmen Anthonella Casanova Rivas", Icon="icon_pacientes.png"},
                new PacientesModel{ Name="Melissa Fabiola Vera Gomez", Icon="icon_pacientes.png"},
            };
        }
        #endregion

        #region Commands Methods
        private async void ButtonBackCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/Home", UriKind.Absolute));
        }

        private async void OnSelectItemCommandExecuted()
        {
            try
            {
                if (SelectItemPaciente != null)
                {
                    var navigationParams = new NavigationParameters
                    {
                        {"Paciente", SelectItemPaciente}
                    };
                    await NavigationService.NavigateAsync("DataPaciente", navigationParams);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }
        }
        #endregion

        #region Methods Life Cycle Page
        #endregion
    }
}
