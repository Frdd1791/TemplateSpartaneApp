using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.Helpers;
using TemplateSpartaneApp.LocalData;
using TemplateSpartaneApp.Models.Catalogs;
using TemplateSpartaneApp.Models.ConfiguraPreguntas;
using TemplateSpartaneApp.Models.Pacientes;
using TemplateSpartaneApp.Services.ConfiguraPreguntas;
using TemplateSpartaneApp.Services.Formulario;
using TemplateSpartaneApp.Services.Pacientes;
using TemplateSpartaneApp.ViewModels.RegistroPago;
using Xamarin.Forms;

namespace TemplateSpartaneApp.ViewModels.Evaluacion
{
    public class EvaluacionPageUnoViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(EvaluacionPageUnoViewModel);
        private readonly IPacientesService _pacienteService;
        private readonly IConfiguraPreguntaService _configuraPreguntaService;
        #endregion

        #region Vars Commands
        public DelegateCommand NextEvoUnoCommand { get; set; }
        public DelegateCommand NextEvoDosCommand { get; set; }
        public DelegateCommand NextEvoMas65Command { get; set; }
        public DelegateCommand NextEvoCuatroCommand { get; set; }
        public DelegateCommand TabGestureListCommand { get; set; }

        public DelegateCommand ActionPerdidaPesoCommand { get; set; }
        public DelegateCommand ActionIngestaAlimentosCommand { get; set; }

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
        /*
         *  Properties Algunos datos del paciente
         */
        private string textPregunta1;
        public string TextPregunta1
        {
            get { return textPregunta1; }
            set
            {
                SetProperty(ref textPregunta1, value);
            }
        }
        private string textPregunta2;
        public string TextPregunta2
        {
            get { return textPregunta2; }
            set
            {
                SetProperty(ref textPregunta2, value);
            }
        }
        private string textPregunta3;
        public string TextPregunta3
        {
            get { return textPregunta3; }
            set
            {
                SetProperty(ref textPregunta3, value);
            }
        }
        private string textPregunta4;
        public string TextPregunta4
        {
            get { return textPregunta4; }
            set
            {
                SetProperty(ref textPregunta4, value);
            }
        }
        private string textPregunta5;
        public string TextPregunta5
        {
            get { return textPregunta5; }
            set
            {
                SetProperty(ref textPregunta5, value);
            }
        }
        private string textPregunta6;
        public string TextPregunta6
        {
            get { return textPregunta6; }
            set
            {
                SetProperty(ref textPregunta6, value);
            }
        }
        private string nombre_del_Paciente;
        public string Nombre_del_Paciente
        {
            get { return nombre_del_Paciente; }
            set
            {
                SetProperty(ref nombre_del_Paciente, value);
            }
        }

        private string sexoValue;
        public string SexoValue
        {
            get { return sexoValue; }
            set
            {
                SetProperty(ref sexoValue, value);
            }
        }

        private int sexo;
        public int Sexo
        {
            get { return sexo; }
            set
            {
                SetProperty(ref sexo, value);
            }
        }
        private string talla;
        public string Talla
        {
            get { return talla; }
            set
            {
                SetProperty(ref talla, value);
            }
        }
        private string peso_Actual;
        public string Peso_Actual
        {
            get { return peso_Actual; }
            set
            {
                SetProperty(ref peso_Actual, value);
            }
        }
        private string peso_Usual;
        public string Peso_Usual
        {
            get { return peso_Usual; }
            set
            {
                SetProperty(ref peso_Usual, value);
            }
        }
        private string peso_Ideal;
        public string Peso_Ideal
        {
            get { return peso_Ideal; }
            set
            {
                SetProperty(ref peso_Ideal, value);
            }
        }
        private string creatinina;
        public string Creatinina
        {
            get { return creatinina; }
            set
            {
                SetProperty(ref creatinina, value);
            }
        }
        /********** Final properties Datos del paciente **********/

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

        private string textPerdidaPeso;
        public string TextPerdidaPeso
        {
            get { return textPerdidaPeso; }
            set
            {
                SetProperty(ref textPerdidaPeso, value);
            }
        }

        private string textIngestaAlimentos;
        public string TextIngestaAlimentos
        {
            get { return textIngestaAlimentos; }
            set
            {
                SetProperty(ref textIngestaAlimentos, value);
            }
        }
        #endregion


        #region Contructor
        public EvaluacionPageUnoViewModel(INavigationService navigationService,
            IPacientesService pacientesService,
            IConfiguraPreguntaService configuraPreguntaService,
            IUserDialogs userDialogsService,
            IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            _pacienteService = pacientesService;
            _configuraPreguntaService = configuraPreguntaService;
            LoadPreguntas();

            ButtonBack = true;
            ProgressBarOpt = true;
            ButtonSaveData = false;
            colorHexButtonSave = "#D9D9D9";

            NextEvoUnoCommand = new DelegateCommand(NextEvoUnoCommandExecuted);
            TabGestureListCommand = new DelegateCommand(TabGestureListCommandExecuted);
            NextEvoMas65Command = new DelegateCommand(Mas65CommandExecuted);
            NextEvoDosCommand = new DelegateCommand(NextEvoDosCommandExecuted);
            NextEvoCuatroCommand = new DelegateCommand(NextEvoCuatroCommandExecuted);

            ActionPerdidaPesoCommand = new DelegateCommand(ActionSheetPerdidaPesoCommandExecuted);
            ActionIngestaAlimentosCommand = new DelegateCommand(ActionSheetIngestaAlimentosCommandExecuted);

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

            TextPerdidaPeso = "No ha perdido peso";
            TextIngestaAlimentos = "Normal";

            TextPeso = "Perdida de peso de >5 % en:";
            IsActiveEvoUno = true;
            isActiveEvoDos = false;
            IsActiveEvoTres = false;
            IsActiveEvoCuatro = false;
            IsActiveEvoResultado = false;

            SexoValue = "Hombre";
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
        private async void LoadPreguntas()
        {
            var configuraciones = await RunSafeApi<ListConfiguracionPreguntaModel>(_configuraPreguntaService.ListaSelAll(0, 100));
            if (configuraciones.Status == TypeReponse.Ok)
            {
                if (configuraciones.Response.RowCount > 0)
                {
                    for (int i = 0; i < configuraciones.Response.RowCount; i++)
                    {
                        if (configuraciones.Response.Configura_Preguntas[i] != null)
                        {
                            if (configuraciones.Response.Configura_Preguntas[i].Formulario == 1)
                            {
                                if (configuraciones.Response.Configura_Preguntas[i].Titulo_Seccion_de_Formulario.Clave == 1 && configuraciones.Response.Configura_Preguntas[i].Clave == 1)
                                {
                                    TxtIndicadorPaso = configuraciones.Response.Configura_Preguntas[i].Titulo_Seccion_de_Formulario.Descripcion.ToString();
                                    Debug.WriteLine(configuraciones.Response.Configura_Preguntas[i].Titulo_Seccion_de_Formulario.Descripcion.ToString());
                                }

                                if (configuraciones.Response.Configura_Preguntas[i].Clave == 1)
                                {
                                    TextPregunta1 = configuraciones.Response.Configura_Preguntas[i].Pregunta;
                                }
                                else if (configuraciones.Response.Configura_Preguntas[i].Clave == 2)
                                {
                                    TextPregunta2 = configuraciones.Response.Configura_Preguntas[i].Pregunta;
                                }
                                else if (configuraciones.Response.Configura_Preguntas[i].Clave == 3)
                                {
                                    TextPregunta3 = configuraciones.Response.Configura_Preguntas[i].Pregunta;
                                }
                                else if (configuraciones.Response.Configura_Preguntas[i].Clave == 4)
                                {
                                    TextPregunta4 = configuraciones.Response.Configura_Preguntas[i].Pregunta;
                                }
                                else if (configuraciones.Response.Configura_Preguntas[i].Clave == 5)
                                {
                                    TextPregunta5 = configuraciones.Response.Configura_Preguntas[i].Pregunta;
                                }
                                else if (configuraciones.Response.Configura_Preguntas[i].Clave == 6)
                                {
                                    TextPregunta6 = configuraciones.Response.Configura_Preguntas[i].Pregunta;
                                }
                            }
                        }
                    }
                }
            }
        }
        public async Task<string> ValidateEntry()
        {
            string state = "";

            if (string.IsNullOrEmpty(Nombre_del_Paciente))
            {
                state = "Por favor ingrese Nombre del Paciente.";
            }
            else if (string.IsNullOrEmpty(Talla))
            {
                state = "El campo Talla no puede estar vacío.";
            }
            else if (string.IsNullOrEmpty(SexoValue))
            {
                state = "El campo Sexo no puede estar vacío.";
            }
            else if (string.IsNullOrEmpty(Peso_Actual))
            {
                state = "El campo Peso Actual no puede estar vacío.";
            }
            else if (string.IsNullOrEmpty(Peso_Usual))
            {
                state = "El campo Peso Usual no puede estar vacío.";
            }
            else if (string.IsNullOrEmpty(Peso_Ideal))
            {
                state = "El campo Peso Ideal no puede estar vacío.";
            }
            else if (string.IsNullOrEmpty(Creatinina))
            {
                state = "El campo Creatinina no puede estar vacío.";
            }
            if (!string.IsNullOrEmpty(Talla))
            {
                double talla = double.Parse(Talla);
                if (talla <= 0 || talla > 2.2)
                {
                    state = "El rango permitido del campo talla es de 1 a 2.2";
                }
            }
            if (!string.IsNullOrEmpty(Peso_Actual))
            {
                double peso_actual = double.Parse(Peso_Actual);
                if (peso_actual < 15 || peso_actual > 120)
                {
                    state = "El rango permitido del campo peso actual es de 15 y 120";
                }
            }
            if (!string.IsNullOrEmpty(Peso_Usual))
            {
                double peso_usual = double.Parse(Peso_Usual);
                if (peso_usual < 15 || peso_usual > 120)
                {
                    state = "El rango permitido del campo peso usual es de 15 y 120";
                }
            }
            if (!string.IsNullOrEmpty(Creatinina))
            {
                double creatinina = double.Parse(Creatinina);
                if (creatinina < 0.01 || creatinina > 8)
                {
                    state = "El rango permitido del campo creatinina es de 0.01 a 8";
                }
            }
            return state;
        }
        private async void NextEvoUnoCommandExecuted()
        {
            UserDialogsService.ShowLoading("Registrando...");
            string state = await ValidateEntry();
            if (string.IsNullOrEmpty(state))
            {

                MiPaciente model = new MiPaciente()
                {
                    Fecha_de_Registro = DateTime.Now,
                    Hora_de_Registro = DateTime.Now.ToString("HH:mm"),
                    Usuario = Profile.Instance.Identifier,
                    Nombre_del_Paciente = Nombre_del_Paciente,
                    Apellidoss = "Vacio",
                    Sexo = Sexo,
                    Talla = double.Parse(Talla),
                    Peso_Actual = double.Parse(Peso_Actual),
                    Peso_Usual = double.Parse(Peso_Usual),
                    Peso_Ideal = double.Parse(Peso_Ideal),
                    Peso_para_Calculo = 80.50,
                    Creatinina = double.Parse(Creatinina)
                };
                ResponseBase<int> insert = await RunSafeApi<int>(_pacienteService.Post(model));
                if (insert.Status == TypeReponse.Ok)
                {
                    UserDialogsService.HideLoading();
                    IsActiveEvoUno = false;
                    IsActiveEvoDos = true;

                    TxtIndicadorPaso = "Indice de riesgo nutricional";
                }
                else
                {
                    UserDialogsService.HideLoading();
                    UserDialogsService.Alert("Error al crear nuevo paciente", "Alerta", "Aceptar");
                }
            }
            else
            {
                UserDialogsService.Alert(state, "Alerta", "Aceptar");
            }

            UserDialogsService.HideLoading();
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
            if (genero.Equals("Calcel"))
            {
                Debug.WriteLine("Valor no admitido");
            }
            else
            {
                SexoValue = genero.ToString();
                if (genero.Equals("Hombre"))
                {
                    Sexo = 1;
                }
                else if (genero.Equals("Mujer"))
                {
                    Sexo = 2;
                }
            }
        }

        private async void ActionSheetAlimentacionCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Alimentacion: ", "Cancel", null, "Ha comido mucho menos", "Ha comido menos", "Ha comido igual");
            if (action.Equals("Calcel"))
            {
                Debug.WriteLine("Valor no admitido");
            }
            else
            {
                TextAlimentacionMas65 = action.ToString();
            }
        }

        private async void ActionSheetPesoCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Peso: ", "Cancel", null, "Perdida de peso >3 kilos", "No lo sabe", "Perdida de peso entre 1 a 3 kilos", "No ha habido perdida de peso");
            if (action.Equals("Calcel"))
            {
                Debug.WriteLine("Valor no admitido");
            }
            else
            {
                TextPesoMas65 = action.ToString();
            }
        }
        private async void ActionSheetMovilidadCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Movilidad: ", "Cancel", null, "De la cama al sillon", "Autonomia en el interior", "Sale del domicilio");
            if (action.Equals("Calcel"))
            {
                Debug.WriteLine("Valor no admitido");
            }
            else
            {
                TextMovilidadMas65 = action.ToString();
            }
        }
        private async void ActionSheetProblemasCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Problemas: ", "Cancel", null, "Demencia o depresion grave", "Demencia moderada", "Sin problemas psicologicos");
            if (action.Equals("Calcel"))
            {
                Debug.WriteLine("Valor no admitido");
            }
            else
            {
                TextProblemasMas65 = action.ToString();
            }
        }

        private async void ActionSheetAlimentacionCNCCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Alimentacion: ", "Cancel", null, "No", "En los ultimos 5 dias", "En los ultimos 10 dias", "No lo se");
            if (action.Equals("Calcel"))
            {
                Debug.WriteLine("Valor no admitido");
            }
            else
            {
                TextAlimentacionCNC = action.ToString();
            }
        }
        private async void ActionSheetPesoCNCCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Peso: ", "Cancel", null, "No ha perdido peso", ">15% en los ultimos 3 a 6 meses", ">10% ultimos 6 meses", "No lo se");
            if (action.Equals("Calcel"))
            {
                Debug.WriteLine("Valor no admitido");
            }
            else
            {
                TextPesoCNC = action.ToString();
            }
        }
        private async void ActionSheetNivelesCNCCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Niveles: ", "Cancel", null, "Si", "No", "No lo se");
            if (action.Equals("Calcel"))
            {
                Debug.WriteLine("Valor no admitido");
            }
            else
            {
                TextNivelesCNC = action.ToString();
            }
        }
        private async void ActionSheetHistoriaCNCCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Historia: ", "Cancel", null, "Si", "No", "No lo se");
            if (action.Equals("Calcel"))
            {
                Debug.WriteLine("Valor no admitido");
            }
            else
            {
                TextHistoriaCNC = action.ToString();
            }
        }
        private async void ActionSheetPerdidaPesoCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Perdida de peso: ", "Cancel", null, "No ha perdido peso", "Ultimo mes", "2 meses", "3 meses", ">15% en tiempo indefinido");
            if (action.Equals("Calcel"))
            {
                Debug.WriteLine("Valor no admitido");
            }
            else
            {
                TextPerdidaPeso = action.ToString();
            }
        }

        private async void ActionSheetIngestaAlimentosCommandExecuted()
        {
            string action = await Application.Current.MainPage.DisplayActionSheet("Perdida de peso: ", "Cancel", null, "Normal", "del 50 al 75%", "del 25 al 50%", "del 0 al 25%");
            if (action.Equals("Calcel"))
            {
                Debug.WriteLine("Valor no admitido");
            }
            else
            {
                TextIngestaAlimentos = action.ToString();
            }
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
