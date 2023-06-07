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
using TemplateSpartaneApp.LocalData;
using TemplateSpartaneApp.Models.Pacientes;
using TemplateSpartaneApp.Services.Pacientes;
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
        private ObservableCollectionExt<MiPaciente> itemsList;
        public ObservableCollectionExt<MiPaciente> ItemsList
        {
            get { return itemsList; }
            set
            {
                SetProperty(ref itemsList, value);
            }
        }

        public MiPaciente selectItemPaciente;
        public MiPaciente SelectItemPaciente
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
            IUserDialogs userDialogsService,
            IPacientesService pacientesService,
            IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            OnSelectItemCommand = new DelegateCommand(OnSelectItemCommandExecuted);
            _pacienteService = pacientesService;
            LoadPacientes();
        }
        #endregion

        #region Methods
        private async void LoadPacientes()
        {
            var items = await RunSafeApi<ListPacientesModel>(_pacienteService.ListaSelAll(0, 100, $"Usuario = {Profile.Instance.Identifier}"));
            if (items.Status == TypeReponse.Ok)
            {
                if (items.Response.RowCount > 0)
                {
                    ItemsList = new ObservableCollectionExt<MiPaciente>(items.Response.listPacientes);
                }
            }
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

        #region Populating
        #endregion

        #region Methods Life Cycle Page
        #endregion
    }
}
