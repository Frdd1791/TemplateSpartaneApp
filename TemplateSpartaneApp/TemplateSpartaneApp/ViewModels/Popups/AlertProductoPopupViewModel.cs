using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.ViewModels.Popups
{
    public class AlertProductoPopupViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(AlertProductoPopupViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand CloseCommand { get; set; }
        public DelegateCommand NextCommand { get; set; }
        public DelegateCommand SelectedChangedCommand { get; set; }
        #endregion

        #region Properties
        private int selectedIndexPorcion;
        public int SelectedIndexPorcion
        {
            get => selectedIndexPorcion;
            set
            {
                SetProperty(ref selectedIndexPorcion, value);
            }
        }

        private string textPorcion;
        public string TextPorcion
        {
            get => textPorcion;
            set
            {
                SetProperty(ref textPorcion, value);
            }
        }

        private string entryPorcion;
        public string EntryPorcion
        {
            get => entryPorcion;
            set
            {
                SetProperty(ref entryPorcion, value);
            }
        }

        private string placeHolderPorcion;
        public string PlaceHolderPorcion
        {
            get => placeHolderPorcion;
            set
            {
                SetProperty(ref placeHolderPorcion, value);
            }
        }

        #endregion


        #region Contructor
        public AlertProductoPopupViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            CloseCommand = new DelegateCommand(CloseCommandExecuted);
            NextCommand = new DelegateCommand(NextCommandExecuted);
        }
        #endregion

        #region Methods
        #endregion

        #region Commands Methods
        private async void CloseCommandExecuted()
        {
            await NavigationService.GoBackAsync();
        }
        private async void NextCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/InitTwo", UriKind.Absolute));
        }
        #endregion

        #region Methods Life Cycle Page
        #endregion
    }
}
