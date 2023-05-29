using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.ViewModels.Session;

namespace TemplateSpartaneApp.ViewModels.CalculoNutricional
{
    public class CalculoNutricionalPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(CalculoNutricionalPageViewModel);
        #endregion

        #region Vars Commands
        public DelegateCommand GestureFrameOraAlimentosCommand { get; set; }
        public DelegateCommand GestureFrameEnteralesCommand { get; set; }
        public DelegateCommand GestureFrameParenteralesCommand { get; set; }
        public DelegateCommand NextStepCommand { get; set; }
        public DelegateCommand AgregarSuplementoCommand { get; set; }
        public DelegateCommand AgregarProductoCommand { get; set; }
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

        private int selectedIndexCalorias;
        public int SelectedIndexCalorias
        {
            get => selectedIndexCalorias;
            set
            {
                SetProperty(ref selectedIndexCalorias, value);
            }
        }

        private int selectedIndexProteinas;
        public int SelectedIndexProteinas
        {
            get => selectedIndexProteinas;
            set
            {
                SetProperty(ref selectedIndexProteinas, value);
            }
        }

        private string hexColorFrameAlimentos;
        public string HexColorFrameAlimentos
        {
            get { return hexColorFrameAlimentos; }
            set
            {
                SetProperty(ref hexColorFrameAlimentos, value);
            }
        }

        private string hexColorFrameEnterales;
        public string HexColorFrameEnterales
        {
            get { return hexColorFrameEnterales; }
            set
            {
                SetProperty(ref hexColorFrameEnterales, value);
            }
        }

        private string hexColorFrameParenterales;
        public string HexColorFrameParenterales
        {
            get { return hexColorFrameParenterales; }
            set
            {
                SetProperty(ref hexColorFrameParenterales, value);
            }
        }

        private string imageSourceAlimentos;
        public string ImageSourceAlimentos
        {
            get { return imageSourceAlimentos; }
            set
            {
                SetProperty(ref imageSourceAlimentos, value);
            }
        }

        private string imageSourceEnteral;
        public string ImageSourceEnteral
        {
            get { return imageSourceEnteral; }
            set
            {
                SetProperty(ref imageSourceEnteral, value);
            }
        }

        private string imageSourceParenteral;
        public string ImageSourceParenteral
        {
            get { return imageSourceParenteral; }
            set
            {
                SetProperty(ref imageSourceParenteral, value);
            }
        }

        private string hexColorButton;
        public string HexColorButton
        {
            get { return hexColorButton; }
            set
            {
                SetProperty(ref hexColorButton, value);
            }
        }

        private string enabledButton;
        public string EnabledButton
        {
            get { return enabledButton; }
            set
            {
                SetProperty(ref enabledButton, value);
            }
        }

        private int rutas_selected;
        public int Rutas_selected
        {
            get { return rutas_selected; }
            set
            {
                SetProperty(ref rutas_selected, value);
            }
        }
        #endregion


        #region Contructor
        public CalculoNutricionalPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            TxtIndicadorPaso = "Ruta de nutricion";
            ProgressBarOpt = true;
            ButtonBack = true;
            HexColorButton = "#ACACAC";
            EnabledButton = "False";

            Rutas_selected = 0;

            GestureFrameOraAlimentosCommand = new DelegateCommand(HexColorAlimentosCommandExecuted);
            GestureFrameEnteralesCommand = new DelegateCommand(HexColorEnteralesCommandExecuted);
            GestureFrameParenteralesCommand = new DelegateCommand(HexColorParenteralesCommandExecuted);
            NextStepCommand = new DelegateCommand(NextStepCommandExecuted);
            AgregarSuplementoCommand = new DelegateCommand(AgregarSuplementoCommandExecuted);
            AgregarProductoCommand = new DelegateCommand(AgregarProductoCommandExecuted);

            HexColorFrameAlimentos = "#EFEFEF";
            HexColorFrameEnterales = "#EFEFEF";
            HexColorFrameParenterales = "#EFEFEF";

            ImageSourceAlimentos = "frutas_gray.png";
            ImageSourceEnteral = "enteral_gray.png";
            ImageSourceParenteral = "paren_gray.png";
        }
        #endregion

        #region Commands Methods
        private void HexColorAlimentosCommandExecuted()
        {
            if (HexColorFrameAlimentos.Equals("#64C55D"))
            {
                HexColorFrameAlimentos = "#EFEFEF";
                ImageSourceAlimentos = "frutas_gray.png";

                if (HexColorFrameEnterales.Equals("#EFEFEF") && HexColorFrameParenterales.Equals("#EFEFEF"))
                {
                    EnabledButton = "False";
                    HexColorButton = "#ACACAC";
                }

                if (Rutas_selected > 0)
                {
                    Rutas_selected--;
                }
            }
            else
            {
                HexColorFrameAlimentos = "#64C55D";
                ImageSourceAlimentos = "frutas_white.png";

                if (EnabledButton.Equals("False"))
                {
                    EnabledButton = "True";
                    HexColorButton = "#165BE2";
                }
                Rutas_selected++;
            }
        }

        private void HexColorEnteralesCommandExecuted()
        {
            if (HexColorFrameEnterales.Equals("#64C55D"))
            {
                HexColorFrameEnterales = "#EFEFEF";
                ImageSourceEnteral = "enteral_gray.png";

                if (HexColorFrameAlimentos.Equals("#EFEFEF") && HexColorFrameParenterales.Equals("#EFEFEF"))
                {
                    EnabledButton = "False";
                    HexColorButton = "#ACACAC";
                }

                if (Rutas_selected > 0)
                {
                    Rutas_selected--;
                }
            }
            else
            {
                HexColorFrameEnterales = "#64C55D";
                ImageSourceEnteral = "enteral_white.png";

                if (EnabledButton.Equals("False"))
                {
                    EnabledButton = "True";
                    HexColorButton = "#165BE2";
                }
                Rutas_selected++;
            }
        }

        private void HexColorParenteralesCommandExecuted()
        {
            if (HexColorFrameParenterales.Equals("#64C55D"))
            {
                HexColorFrameParenterales = "#EFEFEF";
                ImageSourceParenteral = "enteral_gray.png";

                if (HexColorFrameAlimentos.Equals("#EFEFEF") && HexColorFrameEnterales.Equals("#EFEFEF"))
                {
                    EnabledButton = "False";
                    HexColorButton = "#ACACAC";
                }

                if (Rutas_selected > 0)
                {
                    Rutas_selected--;
                }
            }
            else
            {
                HexColorFrameParenterales = "#64C55D";
                ImageSourceParenteral = "paren_white.png";

                if (EnabledButton.Equals("False"))
                {
                    EnabledButton = "True";
                    HexColorButton = "#165BE2";
                }
                Rutas_selected++;
            }
        }

        private void NextStepCommandExecuted()
        {
            Debug.WriteLine("testing");
        }
        private async void AgregarSuplementoCommandExecuted()
        {
            await NavigationService.NavigateAsync("AgregarSuplemento");
        }
        private async void AgregarProductoCommandExecuted()
        {
            await NavigationService.NavigateAsync("AgregarProducto");
        }
        #endregion
    }
}
