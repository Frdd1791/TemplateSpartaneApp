using System;
using System.Diagnostics;
using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.LocalData;
using TemplateSpartaneApp.Models.Catalogs;
using TemplateSpartaneApp.Services.Catalogs;
using TemplateSpartaneApp.Views.Popups;
using Xamarin.Forms;

namespace TemplateSpartaneApp.ViewModels.Home
{
    public class MainPageViewModel : ViewModelBase
    {

        #region Vars
        private static string TAG = nameof(MainPageViewModel);
        public ObservableCollectionExt<ProgressReportModel> Items { get; set; }
        #endregion

        #region Vars Commands
        public DelegateCommand SelectItemCommand { get; set; }
        public DelegateCommand AddItemCommand { get; set; }
        public DelegateCommand OnSelectItemCommand { get; set; }
        public DelegateCommand PacientesCommand { get; set; }
        public DelegateCommand ProductosCommand { get; set; }
        public DelegateCommand EvaluacionCommand { get; set; }
        public DelegateCommand CalculoNutricionalCommand { get; set; }
        #endregion

        #region Properties
        private ProgressReportModel progressReportModel;
        public ProgressReportModel ProgressReportModel
        {
            get { return progressReportModel; }
            set
            {
                SetProperty(ref progressReportModel, value);
                SelectItemCommand.Execute();
            }
        }

        private ObservableCollectionExt<ListOptions> itemsListDash;
        public ObservableCollectionExt<ListOptions> ItemsListDash
        {
            get { return itemsListDash; }
            set
            {
                SetProperty(ref itemsListDash, value);
            }

        }
        public ListOptions selectItem;
        public ListOptions SelectItem
        {
            get { return selectItem; }
            set
            {
                SetProperty(ref selectItem, value);
                OnSelectItemCommand.Execute();
            }
        }

        public string frameColorUno;
        public string FrameColorUno
        {
            get { return frameColorUno; }
            set
            {
                SetProperty(ref frameColorUno, value);
            }
        }

        public string frameColorDos;
        public string FrameColorDos
        {
            get { return frameColorDos; }
            set
            {
                SetProperty(ref frameColorDos, value);
            }
        }

        public string frameColorTres;
        public string FrameColorTres
        {
            get { return frameColorTres; }
            set
            {
                SetProperty(ref frameColorTres, value);
            }
        }

        public string frameColorCuatro;
        public string FrameColorCuatro
        {
            get { return frameColorCuatro; }
            set
            {
                SetProperty(ref frameColorCuatro, value);
            }
        }

        public string frameOneEnabled;
        public string FrameOneEnabled
        {
            get { return frameOneEnabled; }
            set
            {
                SetProperty(ref frameOneEnabled, value);
            }
        }

        public string frameTwoEnabled;
        public string FrameTwoEnabled
        {
            get { return frameTwoEnabled; }
            set
            {
                SetProperty(ref frameTwoEnabled, value);
            }
        }

        public string frameThreeEnabled;
        public string FrameThreeEnabled
        {
            get { return frameThreeEnabled; }
            set
            {
                SetProperty(ref frameThreeEnabled, value);
            }
        }

        public string frameFourEnabled;
        public string FrameFourEnabled
        {
            get { return frameFourEnabled; }
            set
            {
                SetProperty(ref frameFourEnabled, value);
            }
        }
        #endregion

        #region Contructor
        public MainPageViewModel(INavigationService navigationService,
                                 IUserDialogs userDialogsService,
                                 IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            CreatedListDash();
            AddItemCommand = new DelegateCommand(AddItemCommandExecute);
            OnSelectItemCommand = new DelegateCommand(OnSelectItemCommandExecuted);

            PacientesCommand = new DelegateCommand(() => NavigationService.NavigateAsync("ListaPacientes"));
            ProductosCommand = new DelegateCommand(() => NavigationService.NavigateAsync("ProductosNutricionales"));
            EvaluacionCommand = new DelegateCommand(() => NavigationService.NavigateAsync("EvaluacionUno"));
            CalculoNutricionalCommand = new DelegateCommand(() => NavigationService.NavigateAsync("CalculoNutricional"));

            Items = new ObservableCollectionExt<ProgressReportModel>();

            if (AppSettings.Instance.Premium)
            {
                FrameColorUno = "#1F9017";
                FrameColorDos = "#1F9017";
                FrameColorTres = "#1F9017";
                FrameColorCuatro = "#1F9017";

                FrameTwoEnabled = "True";
                FrameThreeEnabled = "True";
                FrameFourEnabled = "True";
            }
            else
            {
                FrameColorUno = "#1F9017";
                FrameColorDos = "#A5D2A2";
                FrameColorTres = "#A5D2A2";
                FrameColorCuatro = "#A5D2A2";

                FrameTwoEnabled = "False";
                FrameThreeEnabled = "False";
                FrameFourEnabled = "False";
            }
        }
        #endregion

        #region Methods
        private void CreatedListDash()
        {
            ItemsListDash = new ObservableCollectionExt<ListOptions>()
            {
                new ListOptions{ Page="Home", Title="Evaluar a tu paciente", Icon="home.png", Detail="Descripcion para evaluacion del paciente", isEnabled=true },
                new ListOptions{ Page="Home", Title="Calculo nutricional", Icon="home.png", Detail="Descripcion para calculo nutricional", isEnabled=true },
                new ListOptions{ Page="Home", Title="Productos nutricionales", Icon="home.png", Detail="Descripcion para productos nutricionales", isEnabled=true },
                new ListOptions{ Page="Home", Title="Mis pacientes", Icon="home.png", Detail="Descripcion validar informacion de los pacientes", isEnabled=true },
            };
        }
        #endregion

        #region Populating
        #endregion

        #region Commands Methods
        private void OnSelectItemCommandExecuted()
        {
            try
            {
                if (SelectItem != null)
                {
                    NavigationService.NavigateAsync(new Uri($"/Index/Navigation/{SelectItem.Page}", UriKind.Absolute));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }
        }
        private void AddItemCommandExecute()
        {
            NavigationService.NavigateAsync(nameof(ProgressReportPopup));
        }
        #endregion

        #region Navigation Params
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("refresh"))
            {
                if (parameters.GetValue<bool>("refresh"))
                {
                    //PopulatingProgressReportList();
                }
            }
        }
        #endregion

        #region Methods Life Cycle Page
        public override void OnAppearing()
        {
            try
            {
                //PopulatingProgressReportList();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }

        }

        public class ListOptions
        {
            public string Title { get; set; }
            public string Detail { get; set; }
            public ImageSource Icon { get; set; }
            public string Page { get; set; }
            public bool isEnabled { get; set; }
        }
        #endregion

    }
}
