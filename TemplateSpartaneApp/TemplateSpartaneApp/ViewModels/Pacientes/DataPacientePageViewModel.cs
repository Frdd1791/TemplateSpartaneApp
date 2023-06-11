using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.LocalData;
using TemplateSpartaneApp.Models.CalculosNutricionales;
using TemplateSpartaneApp.Models.ConfiguraPreguntas;
using TemplateSpartaneApp.Models.Evaluaciones;
using TemplateSpartaneApp.Models.Pacientes;
using TemplateSpartaneApp.Services.ConfiguraPreguntas;
using TemplateSpartaneApp.Services.Pacientes;
using TemplateSpartaneApp.ViewModels.Session;
using Xamarin.Forms;
using static TemplateSpartaneApp.ViewModels.Pacientes.PacientesPageViewModel;

namespace TemplateSpartaneApp.ViewModels.Pacientes
{
    public class DataPacientePageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(DataPacientePageViewModel);
        private readonly IConfiguraPreguntaService _configuraPreguntaService;
        #endregion

        #region Vars Commands
        public DelegateCommand NewEvaluacionCommand { get; set; }
        public DelegateCommand NewCalculoCommand { get; set; }
        public DelegateCommand EvaluacionCommand { get; set; }
        public DelegateCommand CalculoCommand { get; set; }
        public DelegateCommand ButtonBackCommand { get; set; }
        public DelegateCommand ActionSelectDiasEvCommand { get; set; }
        public DelegateCommand ActionSelectDiasCalCommand { get; set; }
        #endregion

        #region Properties
        private ObservableCollectionExt<EvaluacionesModel> itemsList;
        public ObservableCollectionExt<EvaluacionesModel> ItemsList
        {
            get { return itemsList; }
            set
            {
                SetProperty(ref itemsList, value);
            }
        }

        private ObservableCollectionExt<CalculosNModel> itemsListCalculos;
        public ObservableCollectionExt<CalculosNModel> ItemsListCalculos
        {
            get { return itemsListCalculos; }
            set
            {
                SetProperty(ref itemsListCalculos, value);
            }
        }
        private ObservableCollectionExt<ConfigPregunta> preguntasList;
        public ObservableCollectionExt<ConfigPregunta> PreguntasList
        {
            get { return preguntasList; }
            set
            {
                SetProperty(ref preguntasList, value);
            }
        }

        private bool contentEvaluacion;
        public bool ContentEvaluacion
        {
            get { return contentEvaluacion; }
            set
            {
                SetProperty(ref contentEvaluacion, value);
            }
        }

        private bool contentCalculo;
        public bool ContentCalculo
        {
            get { return contentCalculo; }
            set
            {
                SetProperty(ref contentCalculo, value);
            }
        }

        private string colorTextEv;
        public string ColorTextEv
        {
            get { return colorTextEv; }
            set
            {
                SetProperty(ref colorTextEv, value);
            }
        }

        private string colorTextCal;
        public string ColorTextCal
        {
            get { return colorTextCal; }
            set
            {
                SetProperty(ref colorTextCal, value);
            }
        }

        private string backColorEv;
        public string BackColorEv
        {
            get { return backColorEv; }
            set
            {
                SetProperty(ref backColorEv, value);
            }
        }

        private string backColorCal;
        public string BackColorCal
        {
            get { return backColorCal; }
            set
            {
                SetProperty(ref backColorCal, value);
            }
        }

        private string nombrePaciente;
        public string NombrePaciente
        {
            get { return nombrePaciente; }
            set
            {
                SetProperty(ref nombrePaciente, value);
            }
        }

        private string textSelectDiasEv;
        public string TextSelectDiasEv
        {
            get { return textSelectDiasEv; }
            set
            {
                SetProperty(ref textSelectDiasEv, value);
            }
        }

        private string textSelectDiasCal;
        public string TextSelectDiasCal
        {
            get { return textSelectDiasCal; }
            set
            {
                SetProperty(ref textSelectDiasCal, value);
            }
        }

        #endregion

        #region Contructor
        public DataPacientePageViewModel(INavigationService navigationService,
            IUserDialogs userDialogsService,
            IConfiguraPreguntaService configuraPreguntaService,
            IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            NewEvaluacionCommand = new DelegateCommand(NewEvaluacionCommandExecuted);
            NewCalculoCommand = new DelegateCommand(NewCalculoCommandExecuted);

            EvaluacionCommand = new DelegateCommand(EvaluacionCommandExecuted);
            CalculoCommand = new DelegateCommand(CalculoCommandExecuted);
            ButtonBackCommand = new DelegateCommand(ButtonBackCommandExecuted);

            ActionSelectDiasEvCommand = new DelegateCommand(ActionSheetDiasSelectedEvCommandExecuted);
            ActionSelectDiasCalCommand = new DelegateCommand(ActionSheetDiasSelectedCalCommandExecuted);

            CreatedListaEvaluaciones();
            CreatedListaCalculos();
            ContentEvaluacion = true;
            ContentCalculo = false;
            ColorTextEv = "#2B43A0";
            ColorTextCal = "Black";

            BackColorEv = "#EFF4FF";
            BackColorCal = "White";

            TextSelectDiasEv = "Ultimos 7 dias";
            TextSelectDiasCal = "Ultimos 7 dias";
            _configuraPreguntaService = configuraPreguntaService;
            LoadPreguntas();
        }
        #endregion

        #region Methods
        private async void LoadPreguntas()
        {
            var items = await RunSafeApi<ListConfigPreguntaModel>(_configuraPreguntaService.ListaSelAll(0, 100, $"Clave = 1"));
            if (items.Status == TypeReponse.Ok)
            {
                if (items.Response.RowCount > 0)
                {
                    PreguntasList = new ObservableCollectionExt<ConfigPregunta>(items.Response.listPreguntas);
                }
            }
        }
        private async void ButtonBackCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/ListaPacientes", UriKind.Absolute));
        }

        private void CreatedListaEvaluaciones()
        {
            ItemsList = new ObservableCollectionExt<EvaluacionesModel>()
            {
                new EvaluacionesModel{ Fecha="10 Febrero 2023" },
                new EvaluacionesModel{Fecha = "20 Marzo 2023" },
                new EvaluacionesModel{Fecha = "15 Mayo 2023" }
            };
        }

        private void CreatedListaCalculos()
        {
            ItemsListCalculos = new ObservableCollectionExt<CalculosNModel>()
            {
                new CalculosNModel{ Fecha="10 Febrero 2023" },
                new CalculosNModel{ Fecha = "20 Marzo 2023" },
            };
        }
        #endregion

        #region Commands Methods
        private async void NewEvaluacionCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/EvaluacionUno", UriKind.Absolute));
        }
        private async void NewCalculoCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/CalculoNutricional", UriKind.Absolute));
        }
        private async void ActionSheetDiasSelectedEvCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Evaluaciones: ", "Cancel", null, "Ultimos 7 dias", "Ultimos 10 dias", "Ultimos 30 dias", "Ultimos 3 meses");
            TextSelectDiasEv = action.ToString();
        }

        private async void ActionSheetDiasSelectedCalCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Calculos Nutricionales: ", "Cancel", null, "Ultimos 7 dias", "Ultimos 10 dias", "Ultimos 30 dias", "Ultimos 3 meses");
            TextSelectDiasCal = action.ToString();
        }

        private void EvaluacionCommandExecuted()
        {
            ContentEvaluacion = true;
            ContentCalculo = false;
            ColorTextEv = "#2B43A0";
            ColorTextCal = "Black";
            BackColorEv = "#EFF4FF";
            BackColorCal = "White";
        }

        private void CalculoCommandExecuted()
        {
            ContentEvaluacion = false;
            ContentCalculo = true;
            ColorTextEv = "Black";
            ColorTextCal = "#2B43A0";
            BackColorEv = "White";
            BackColorCal = "#EFF4FF";
        }
        #endregion

        #region Populating
        private void PopulateView(MiPaciente item)
        {
            if (item != null)
            {
                NombrePaciente = item.Nombre_del_Paciente;
            }
        }
        #endregion

        #region Navigation Params
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            try
            {
                if (parameters.ContainsKey("Paciente"))
                {
                    var item = parameters.GetValue<MiPaciente>("Paciente");
                    PopulateView(item);
                }
                else
                {
                    PopulateView(null);
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }
        }
        #endregion

        #region Methods Life Cycle Page
        #endregion
    }
}
