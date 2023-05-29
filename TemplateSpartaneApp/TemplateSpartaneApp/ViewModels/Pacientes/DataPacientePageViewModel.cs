using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.ViewModels.Session;
using Xamarin.Forms;
using static TemplateSpartaneApp.ViewModels.Pacientes.PacientesPageViewModel;

namespace TemplateSpartaneApp.ViewModels.Pacientes
{
    public class DataPacientePageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(DataPacientePageViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand NewEvaluacionCommand { get; set; }
        public DelegateCommand NewCalculoCommand { get; set; }
        public DelegateCommand EvaluacionCommand { get; set; }
        public DelegateCommand CalculoCommand { get; set; }
        #endregion

        #region Properties
        private ObservableCollectionExt<ListEvaluaciones> itemsList;
        public ObservableCollectionExt<ListEvaluaciones> ItemsList
        {
            get { return itemsList; }
            set
            {
                SetProperty(ref itemsList, value);
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

        #endregion

        #region Contructor
        public DataPacientePageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            NewEvaluacionCommand = new DelegateCommand(NewEvaluacionCommandExecuted);
            NewCalculoCommand = new DelegateCommand(NewCalculoCommandExecuted);

            EvaluacionCommand = new DelegateCommand(EvaluacionCommandExecuted);
            CalculoCommand = new DelegateCommand(CalculoCommandExecuted);

            CreatedListaEvaluaciones();
            ContentEvaluacion = true;
            ContentCalculo = false;
            ColorTextEv = "#2B43A0";
            ColorTextCal = "Black";

            BackColorEv = "#EFF4FF";
            BackColorCal = "White";
        }
        #endregion

        #region Methods
        private void CreatedListaEvaluaciones()
        {
            ItemsList = new ObservableCollectionExt<ListEvaluaciones>()
            {
                new ListEvaluaciones{ Fecha="10 Febrero 2023", Icon="calendar.png", IconLeft="right_arrow.png" },
                new ListEvaluaciones{ Fecha="20 Marzo 2023", Icon="calendar.png", IconLeft="right_arrow.png" },
                new ListEvaluaciones{ Fecha="15 Mayo 2023", Icon="calendar.png", IconLeft="right_arrow.png" }
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
            await NavigationService.NavigateAsync(new Uri("/Navigation/InitThree", UriKind.Absolute));
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

        #region Methods Life Cycle Page
        public class ListEvaluaciones
        {
            public string Fecha { get; set; }
            public ImageSource Icon { get; set; }
            public ImageSource IconLeft { get; set; }
        }
        #endregion
    }
}
