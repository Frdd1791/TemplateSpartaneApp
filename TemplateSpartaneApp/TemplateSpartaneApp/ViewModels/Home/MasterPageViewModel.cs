using System;
using System.Diagnostics;
using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.LocalData;
using Xamarin.Forms;

namespace TemplateSpartaneApp.ViewModels.Home
{
    public class MasterPageViewModel : ViewModelBase
    {

        #region Vars
        private static string TAG = nameof(MasterPageViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand OnSelectItemCommand { get; set; }
        public DelegateCommand CloseSessionCommand { get; set; }
        public DelegateCommand HomeCommand { get; set; }
        #endregion

        #region Properties
        private ObservableCollectionExt<Menu> itemsMenu;
        public ObservableCollectionExt<Menu> ItemsMenu
        {
            get { return itemsMenu; }
            set
            {
                SetProperty(ref itemsMenu, value);
            }

        }
        public Menu selectItem;
        public Menu SelectItem
        {
            get { return selectItem; }
            set
            {
                SetProperty(ref selectItem, value);
                OnSelectItemCommand.Execute();
            }
        }

        public string textUserName;
        public string TextUserName
        {
            get { return textUserName; }
            set
            {
                SetProperty(ref textUserName, value);
            }
        }

        #endregion

        #region Constructor
        public MasterPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            TextUserName = "Hola, " + Profile.Instance.Name;
            CreatedMenu();
            OnSelectItemCommand = new DelegateCommand(OnSelectItemCommandExecuted);
            CloseSessionCommand = new DelegateCommand(CloseSessionCommandExecuted);
            HomeCommand = new DelegateCommand(HomeCommandExecuted);
        }
        #endregion

        #region Methods
        private void CreatedMenu()
        {
            ItemsMenu = new ObservableCollectionExt<Menu>()
            {
                new Menu{ Page= "Home", MenuTitle="Inicio", Icon="home_black.png"},
                new Menu{ Page= "Home", MenuTitle="Acerca de nosotros", Icon="business_black.png"},
                new Menu{ Page= "Home", MenuTitle="Necesitas ayuda", Icon="manager_black.png"},
            };
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
        private void CloseSessionCommandExecuted()
        {
            try
            {
                Profile.Instance.ClearValues();
                AppSettings.Instance.ClearValues();
                NavigationService.NavigateAsync(new Uri("/Navigation/LogIn", UriKind.Absolute));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, TAG);
            }
        }
        private void HomeCommandExecuted()
        {
            NavigationService.NavigateAsync(new Uri($"/Index/Navigation/Home", UriKind.Absolute));
        }
        public class Menu
        {
            public string MenuTitle { get; set; }
            public string MenuDetail { get; set; }
            public ImageSource Icon { get; set; }
            public string Page { get; set; }
        }
        #endregion

    }
}
