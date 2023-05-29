using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.ViewModels.Evaluacion
{
    public class EvaluacionPageDosViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(EvaluacionPageDosViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand PagarCommand { get; set; }
        public DelegateCommand TabGestureListCommand { get; set; }
        private string textPeso;
        public string TextPeso
        {
            get { return textPeso; }
            set
            {
                SetProperty(ref textPeso, value);
            }
        }
        #endregion


        #region Contructor
        public EvaluacionPageDosViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            PagarCommand = new DelegateCommand(PagarCommandExecuted);
            TabGestureListCommand = new DelegateCommand(TabGestureListCommandExecuted);
            TextPeso = "Perdida de peso de >5 % en:";
        }
        #endregion

        #region Commands Methods
        private async void PagarCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/InitTwo", UriKind.Absolute));
        }
        private async void TabGestureListCommandExecuted()
        {
            await NavigationService.NavigateAsync("InfoListPacientes");
        }
        #endregion
    }
}
