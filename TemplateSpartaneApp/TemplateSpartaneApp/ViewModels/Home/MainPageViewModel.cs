using System;
using System.Diagnostics;
using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using TemplateSpartaneApp.Abstractions;
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
        private readonly IProgressReportService _progressReportService;
        #endregion

        #region Vars Commands
        public DelegateCommand SelectItemCommand { get; set; }
        public DelegateCommand AddItemCommand { get; set; }
        public DelegateCommand OnSelectItemCommand { get; set; }
        public DelegateCommand PacientesCommand { get; set; }
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
        #endregion

        #region Contructor
        public MainPageViewModel(IProgressReportService progressReportService,
                                 INavigationService navigationService,
                                 IUserDialogs userDialogsService,
                                 IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            CreatedListDash();
            _progressReportService = progressReportService;
            SelectItemCommand = new DelegateCommand(SelectItemCommandExecute);
            AddItemCommand = new DelegateCommand(AddItemCommandExecute);
            OnSelectItemCommand = new DelegateCommand(OnSelectItemCommandExecuted);
            PacientesCommand = new DelegateCommand(PacientesCommandExecuted);

            Items = new ObservableCollectionExt<ProgressReportModel>();

            int premium = 1;

            if (premium == 1)
            {
                FrameColorUno = "#1F9017";
                FrameColorDos = "#1F9017";
                FrameColorTres = "#1F9017";
                FrameColorCuatro = "#1F9017";
            }
            else
            {
                FrameColorUno = "#1F9017";
                FrameColorDos = "#A5D2A2";
                FrameColorTres = "#A5D2A2";
                FrameColorCuatro = "#A5D2A2";
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
        private async void PopulatingProgressReportList()
        {
            var result = await RunSafeApi<ProgressReportList>(_progressReportService.ListaSelAll(1, 100));
            if (result.Status == TypeReponse.Ok)
            {
                if (result.Response.Message != null)
                {
                    UserDialogsService.Alert(result.Response.Message, "Alert", "Ok");
                    return;
                }
                if (result.Response.ProgressReports != null && result.Response.RowCount > 0)
                {
                    Items.Reset(result.Response.ProgressReports);
                }
                else
                {
                    UserDialogsService.Alert("No Data", "Alert", "Ok");
                }
            }
        }
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
        private async void SelectItemCommandExecute()
        {
            if (ProgressReportModel == null) return;
            var result = await UserDialogsService.ConfirmAsync("What do you want to do?", "Alert", "Edit", "Delete");
            if (result)
            {
                var navigationParams = new NavigationParameters
                {
                    {"currentProgressReport", ProgressReportModel}
                };
                await NavigationService.NavigateAsync(nameof(ProgressReportPopup), navigationParams);
            }
            else
            {
                var resultDelete = await RunSafeApi<bool>(_progressReportService.Delete(ProgressReportModel.ReportId));
                if (resultDelete.Status == TypeReponse.Ok)
                {
                    if (resultDelete.Response)
                    {
                        await UserDialogsService.AlertAsync("Delete success", "Success", "Ok");
                        Items.Remove(ProgressReportModel);
                    }
                    else
                    {
                        await UserDialogsService.AlertAsync("Delete error", "Alert", "Ok");
                    }
                }
            }
            progressReportModel = null;
        }
        private void AddItemCommandExecute()
        {
            NavigationService.NavigateAsync(nameof(ProgressReportPopup));
        }

        private async void PacientesCommandExecuted()
        {
            Debug.WriteLine("test");
            await NavigationService.NavigateAsync(new Uri($"/Index/Navigation/ListaPacientes", UriKind.Absolute));
        }
        #endregion

        #region Navigation Params
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("refresh"))
            {
                if (parameters.GetValue<bool>("refresh"))
                {
                    PopulatingProgressReportList();
                }
            }
        }
        #endregion

        #region Methods Life Cycle Page
        public override void OnAppearing()
        {
            try
            {
                PopulatingProgressReportList();
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
