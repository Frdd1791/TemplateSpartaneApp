using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.Models.Pacientes;
using TemplateSpartaneApp.Services.Catalogs;
using TemplateSpartaneApp.Services.Pacientes;
using TemplateSpartaneApp.ViewModels.RegistroPago;
using Xamarin.Forms;
using static TemplateSpartaneApp.ViewModels.Home.MainPageViewModel;

namespace TemplateSpartaneApp.ViewModels.Pacientes
{
    public class PacientesPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(PacientesPageViewModel);
        private readonly IPacientesService _pacienteService;
        #endregion

        #region Vars Commans
        public DelegateCommand OnSelectItemCommand { get; set; }
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
        public PacientesPageViewModel(INavigationService navigationService,
            IPacientesService pacienteService,
            IUserDialogs userDialogsService,
            IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            OnSelectItemCommand = new DelegateCommand(OnSelectItemCommandExecuted);
            _pacienteService = pacienteService;
            CreatedListPacientes();
        }
        #endregion

        #region Methods
        private async void CreatedListPacientes()
        {
            ItemsList = new ObservableCollectionExt<PacientesModel>()
            {
                new PacientesModel{ Nombre_del_Paciente="Mariana Estefania Calle Mendoza" },
                new PacientesModel{ Nombre_del_Paciente="Alberto Julian Martinez Jativa" },
                new PacientesModel{ Nombre_del_Paciente="Carmen Anthonella Casanova Rivas" }
            };

            /*var lista = await RunSafeApi<ListPacientes>(_pacienteService.ListaSelAll(0, 1000));
            if (lista.Status == TypeReponse.Ok)
            {
                if (lista.Response.RowCount > 0)
                {

                }
            }*/
        }
        #endregion

        #region Commands Methods

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
