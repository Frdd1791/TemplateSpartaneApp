using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.ViewModels.RegistroPago;
using Xamarin.Forms;

namespace TemplateSpartaneApp.ViewModels.Evaluacion
{
    public class EvaluacionPageUnoViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(EvaluacionPageUnoViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand NextEvoUnoCommand { get; set; }
        public DelegateCommand NextEvoDosCommand { get; set; }
        public DelegateCommand NextEvoMas65Command { get; set; }
        public DelegateCommand NextEvoCuatroCommand { get; set; }
        public DelegateCommand TabGestureListCommand { get; set; }

        /*
         * Commands ContentView mas65
         */
        public DelegateCommand ActionGeneroCommand { get; set; }
        public DelegateCommand ActionAlimentacionCommand { get; set; }
        public DelegateCommand ActionPesoCommand { get; set; }
        public DelegateCommand ActionMovilidadCommand { get; set; }
        public DelegateCommand ActionProblemasCommand { get; set; }

        /*
         * Commands ContentView criterios NICE
         */
        public DelegateCommand ActionPesoCNCommand { get; set; }
        public DelegateCommand ActionAlimentacionCNCommand { get; set; }
        public DelegateCommand ActionNivelesCNCommand { get; set; }
        public DelegateCommand ActionHistoriaCNCommand { get; set; }

        public DelegateCommand NexFinalProcessCommand { get; set; }


        public DelegateCommand SaveResultCommand { get; set; }
        public DelegateCommand DownloadResultCommand { get; set; }
        public DelegateCommand FinalCommand { get; set; }
        #endregion

        #region Properties
        private string txtIndicadorPaso;
        public string TxtIndicadorPaso
        {
            get { return txtIndicadorPaso; }
            set
            {
                SetProperty(ref txtIndicadorPaso, value);
            }
        }

        private bool isActiveEvoUno;
        public bool IsActiveEvoUno
        {
            get { return isActiveEvoUno; }
            set
            {
                SetProperty(ref isActiveEvoUno, value);
            }
        }

        private bool isActiveEvoDos;
        public bool IsActiveEvoDos
        {
            get { return isActiveEvoDos; }
            set
            {
                SetProperty(ref isActiveEvoDos, value);
            }
        }

        private bool isActiveEvoTres;
        public bool IsActiveEvoTres
        {
            get { return isActiveEvoTres; }
            set
            {
                SetProperty(ref isActiveEvoTres, value);
            }
        }

        private bool isActiveEvoCuatro;
        public bool IsActiveEvoCuatro
        {
            get { return isActiveEvoCuatro; }
            set
            {
                SetProperty(ref isActiveEvoCuatro, value);
            }
        }

        private bool isActiveEvoResultado;
        public bool IsActiveEvoResultado
        {
            get { return isActiveEvoResultado; }
            set
            {
                SetProperty(ref isActiveEvoResultado, value);
            }
        }

        private string textPeso;
        public string TextPeso
        {
            get { return textPeso; }
            set
            {
                SetProperty(ref textPeso, value);
            }
        }

        private string textGenero;
        public string TextGenero
        {
            get { return textGenero; }
            set
            {
                SetProperty(ref textGenero, value);
            }
        }

        private string textAlimentacionMas65;
        public string TextAlimentacionMas65
        {
            get { return textAlimentacionMas65; }
            set
            {
                SetProperty(ref textAlimentacionMas65, value);
            }
        }
        private string textPesoMas65;
        public string TextPesoMas65
        {
            get { return textPesoMas65; }
            set
            {
                SetProperty(ref textPesoMas65, value);
            }
        }
        private string textMovilidadMas65;
        public string TextMovilidadMas65
        {
            get { return textMovilidadMas65; }
            set
            {
                SetProperty(ref textMovilidadMas65, value);
            }
        }
        private string textProblemasMas65;
        public string TextProblemasMas65
        {
            get { return textProblemasMas65; }
            set
            {
                SetProperty(ref textProblemasMas65, value);
            }
        }

        private int masaCorporal;
        public int MasaCorporal
        {
            get { return masaCorporal; }
            set
            {
                SetProperty(ref masaCorporal, value);
            }
        }

        private string textPesoCNC;
        public string TextPesoCNC
        {
            get { return textPesoCNC; }
            set
            {
                SetProperty(ref textPesoCNC, value);
            }
        }
        private string textAlimentacionCNC;
        public string TextAlimentacionCNC
        {
            get { return textAlimentacionCNC; }
            set
            {
                SetProperty(ref textAlimentacionCNC, value);
            }
        }
        private string textNivelesCNC;
        public string TextNivelesCNC
        {
            get { return textNivelesCNC; }
            set
            {
                SetProperty(ref textNivelesCNC, value);
            }
        }
        private string textHistoriaCNC;
        public string TextHistoriaCNC
        {
            get { return textHistoriaCNC; }
            set
            {
                SetProperty(ref textHistoriaCNC, value);
            }
        }

        private bool buttonBack;
        public bool ButtonBack
        {
            get { return buttonBack; }
            set
            {
                SetProperty(ref buttonBack, value);
            }
        }

        private bool progressBarOpt;
        public bool ProgressBarOpt
        {
            get { return progressBarOpt; }
            set
            {
                SetProperty(ref progressBarOpt, value);
            }
        }

        private bool buttonSaveData;
        public bool ButtonSaveData
        {
            get { return buttonSaveData; }
            set
            {
                SetProperty(ref buttonSaveData, value);
            }
        }

        private string colorHexButtonSave;
        public string ColorHexButtonSave
        {
            get { return colorHexButtonSave; }
            set
            {
                SetProperty(ref colorHexButtonSave, value);
            }
        }
        #endregion


        #region Contructor
        public EvaluacionPageUnoViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            ButtonBack = true;
            ProgressBarOpt = true;
            ButtonSaveData = false;
            colorHexButtonSave = "#D9D9D9";

            NextEvoUnoCommand = new DelegateCommand(NextEvoUnoCommandExecuted);
            TabGestureListCommand = new DelegateCommand(TabGestureListCommandExecuted);
            NextEvoMas65Command = new DelegateCommand(Mas65CommandExecuted);
            NextEvoDosCommand = new DelegateCommand(NextEvoDosCommandExecuted);
            NextEvoCuatroCommand = new DelegateCommand(NextEvoCuatroCommandExecuted);

            ActionGeneroCommand = new DelegateCommand(ActionSheetCommandExecuted);
            ActionAlimentacionCommand = new DelegateCommand(ActionSheetAlimentacionCommandExecuted);
            ActionPesoCommand = new DelegateCommand(ActionSheetPesoCommandExecuted);
            ActionMovilidadCommand = new DelegateCommand(ActionSheetMovilidadCommandExecuted);
            ActionProblemasCommand = new DelegateCommand(ActionSheetProblemasCommandExecuted);

            ActionPesoCNCommand = new DelegateCommand(ActionSheetPesoCNCCommandExecuted);
            ActionAlimentacionCNCommand = new DelegateCommand(ActionSheetAlimentacionCNCCommandExecuted);
            ActionNivelesCNCommand = new DelegateCommand(ActionSheetNivelesCNCCommandExecuted);
            ActionHistoriaCNCommand = new DelegateCommand(ActionSheetHistoriaCNCCommandExecuted);

            NexFinalProcessCommand = new DelegateCommand(NexFinalProcessCommandExecuted);

            SaveResultCommand = new DelegateCommand(SaveResultCommandExecuted);
            DownloadResultCommand = new DelegateCommand(DownloadResultCommandExecuted);
            FinalCommand = new DelegateCommand(FinalCommandExecuted);


            TxtIndicadorPaso = "Indicanos algunos datos de tu paciente";
            TextPeso = "Perdida de peso de >5 % en:";
            IsActiveEvoUno = true;
            isActiveEvoDos = false;
            IsActiveEvoTres = false;
            IsActiveEvoCuatro = false;
            IsActiveEvoResultado = false;

            TextGenero = "Hombre";
            TextAlimentacionMas65 = "Ha comido mucho menos";
            TextPesoMas65 = "Perdida de peso en los ultimos 3 meses";
            TextMovilidadMas65 = "De la cama al sillon";
            TextProblemasMas65 = "Demencia o depresion grave";

            TextPesoCNC = "No ha perdido peso";
            TextAlimentacionCNC = "No lo se";
            TextNivelesCNC = "No lo se";
            TextHistoriaCNC = "No lo se";
        }
        #endregion

        #region Commands Methods
        private void NextEvoUnoCommandExecuted()
        {
            IsActiveEvoUno = false;
            IsActiveEvoDos = true;

            TxtIndicadorPaso = "Indice de riesgo nutricional";
        }

        private void NextEvoDosCommandExecuted()
        {
            IsActiveEvoDos = false;
            IsActiveEvoCuatro = true;
            TxtIndicadorPaso = "Ingresa criterios NICE";
        }
        private void NextEvoCuatroCommandExecuted()
        {
            IsActiveEvoTres = false;
            IsActiveEvoCuatro = true;
            TxtIndicadorPaso = "Ingresa criterios NICE";
        }
        private async void TabGestureListCommandExecuted()
        {
            await NavigationService.NavigateAsync("InfoListPacientes");
        }

        private void Mas65CommandExecuted()
        {
            IsActiveEvoDos = false;
            IsActiveEvoTres = true;
            TxtIndicadorPaso = "Valoracion nutricional minima";
        }

        private async void ActionSheetCommandExecuted()
        {
            string genero = await Application.Current.MainPage.DisplayActionSheet("Sexo: ", "Cancel", null, "Hombre", "Mujer");
            TextGenero = genero.ToString();

        }

        private async void ActionSheetAlimentacionCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Alimentacion: ", "Cancel", null, "Ha comido mucho menos", "Ha comido menos", "Ha comido igual");
            TextAlimentacionMas65 = action.ToString();

        }

        private async void ActionSheetPesoCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Peso: ", "Cancel", null, "Perdida de peso >3 kilos", "No lo sabe", "Perdida de peso entre 1 a 3 kilos", "No ha habido perdida de peso");
            TextPesoMas65 = action.ToString();

        }
        private async void ActionSheetMovilidadCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Movilidad: ", "Cancel", null, "De la cama al sillon", "Autonomia en el interior", "Sale del domicilio");
            TextMovilidadMas65 = action.ToString();

        }
        private async void ActionSheetProblemasCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Problemas: ", "Cancel", null, "Demencia o depresion grave", "Demencia moderada", "Sin problemas psicologicos");
            TextProblemasMas65 = action.ToString();

        }

        private async void ActionSheetAlimentacionCNCCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Problemas: ", "Cancel", null, "No", "En los ultimos 5 dias", "En los ultimos 10 dias", "No lo se");
            TextAlimentacionCNC = action.ToString();
        }
        private async void ActionSheetPesoCNCCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Problemas: ", "Cancel", null, "No ha perdido peso", ">15% en los ultimos 3 a 6 meses", ">10% ultimos 6 meses", "No lo se");
            TextPesoCNC = action.ToString();
        }
        private async void ActionSheetNivelesCNCCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Problemas: ", "Cancel", null, "Si", "No", "No lo se");
            TextNivelesCNC = action.ToString();
        }
        private async void ActionSheetHistoriaCNCCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Problemas: ", "Cancel", null, "Si", "No", "No lo se");
            TextHistoriaCNC = action.ToString();
        }

        private void NexFinalProcessCommandExecuted()
        {
            ButtonBack = false;
            TxtIndicadorPaso = "Resultados de la evaluacion";
            IsActiveEvoResultado = true;
            IsActiveEvoCuatro = false;
            ProgressBarOpt = false;
        }

        private void SaveResultCommandExecuted()
        {

        }

        private void DownloadResultCommandExecuted()
        {

        }

        private async void FinalCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri($"/Index/Navigation/Home", UriKind.Absolute));
        }
        #endregion
    }
}
