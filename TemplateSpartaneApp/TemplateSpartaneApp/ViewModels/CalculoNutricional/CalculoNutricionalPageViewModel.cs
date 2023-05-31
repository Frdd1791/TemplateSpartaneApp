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

        public DelegateCommand NextPassOneCommand { get; set; }
        public DelegateCommand NextPassTwoCommand { get; set; }
        public DelegateCommand NextPassFourCommand { get; set; }
        public DelegateCommand NextPassFiveCommand { get; set; }
        public DelegateCommand NextPassSixCommand { get; set; }

        public DelegateCommand FinalCommand { get; set; }

        public DelegateCommand ButtonBackCommand { get; set; }
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

        private string buttonBack;
        public string ButtonBack
        {
            get { return buttonBack; }
            set
            {
                SetProperty(ref buttonBack, value);
            }
        }

        private string progressBarOpt;
        public string ProgressBarOpt
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

        private string headerContent;
        public string HeaderContent
        {
            get { return headerContent; }
            set
            {
                SetProperty(ref headerContent, value);
            }
        }

        private string boxLine;
        public string BoxLine
        {
            get { return boxLine; }
            set
            {
                SetProperty(ref boxLine, value);
            }
        }

        private string contentProgressBar;
        public string ContentProgressBar
        {
            get { return contentProgressBar; }
            set
            {
                SetProperty(ref contentProgressBar, value);
            }
        }
        private string contentViewUno;
        public string ContentViewUno
        {
            get { return contentViewUno; }
            set
            {
                SetProperty(ref contentViewUno, value);
            }
        }
        private string contentViewDos;
        public string ContentViewDos
        {
            get { return contentViewDos; }
            set
            {
                SetProperty(ref contentViewDos, value);
            }
        }
        private string contentViewTres;
        public string ContentViewTres
        {
            get { return contentViewTres; }
            set
            {
                SetProperty(ref contentViewTres, value);
            }
        }
        private string contentViewCuatro;
        public string ContentViewCuatro
        {
            get { return contentViewCuatro; }
            set
            {
                SetProperty(ref contentViewCuatro, value);
            }
        }
        private string contentViewCinco;
        public string ContentViewCinco
        {
            get { return contentViewCinco; }
            set
            {
                SetProperty(ref contentViewCinco, value);
            }
        }
        private string contentViewSeis;
        public string ContentViewSeis
        {
            get { return contentViewSeis; }
            set
            {
                SetProperty(ref contentViewSeis, value);
            }
        }
        private string contentViewResultado;
        public string ContentViewResultado
        {
            get { return contentViewResultado; }
            set
            {
                SetProperty(ref contentViewResultado, value);
            }
        }

        #endregion


        #region Contructor
        public CalculoNutricionalPageViewModel(INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            TxtIndicadorPaso = "Ruta de nutricion";
            ProgressBarOpt = "True";
            ButtonBack = "True";
            HexColorButton = "#ACACAC";
            EnabledButton = "False";
            HeaderContent = "True";
            BoxLine = "True";
            ContentProgressBar = "True";
            Rutas_selected = 0;

            ContentViewUno = "True";
            ContentViewDos = "False";
            ContentViewTres = "False";
            ContentViewCuatro = "False";
            ContentViewCinco = "False";
            ContentViewSeis = "False";
            ContentViewResultado = "False";

            GestureFrameOraAlimentosCommand = new DelegateCommand(HexColorAlimentosCommandExecuted);
            GestureFrameEnteralesCommand = new DelegateCommand(HexColorEnteralesCommandExecuted);
            GestureFrameParenteralesCommand = new DelegateCommand(HexColorParenteralesCommandExecuted);
            NextStepCommand = new DelegateCommand(NextStepCommandExecuted);
            AgregarSuplementoCommand = new DelegateCommand(AgregarSuplementoCommandExecuted);
            AgregarProductoCommand = new DelegateCommand(AgregarProductoCommandExecuted);

            NextPassOneCommand = new DelegateCommand(NexPassOneCommandExecuted);
            NextPassTwoCommand = new DelegateCommand(NextPassTwoCommandExecuted);
            NextPassFourCommand = new DelegateCommand(NextPassFourCommandExecuted);
            NextPassFiveCommand = new DelegateCommand(NextPassFiveCommandExecuted);
            NextPassSixCommand = new DelegateCommand(NextPassSixCommandExecuted);

            FinalCommand = new DelegateCommand(FinalCommandExecuted);

            ButtonBackCommand = new DelegateCommand(ButtonBackCommandExecuted);

            HexColorFrameAlimentos = "#EFEFEF";
            HexColorFrameEnterales = "#EFEFEF";
            HexColorFrameParenterales = "#EFEFEF";

            ImageSourceAlimentos = "frutas_gray.png";
            ImageSourceEnteral = "enteral_gray.png";
            ImageSourceParenteral = "paren_gray.png";
        }
        #endregion

        #region Commands Methods
        private async void ButtonBackCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/Home", UriKind.Absolute));
        }
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

        private void NexPassOneCommandExecuted()
        {
            ContentViewUno = "False";
            ContentViewDos = "True";
        }
        private void NextPassTwoCommandExecuted()
        {
            ContentViewDos = "False";
            ContentViewTres = "True";
            ContentViewCuatro = "True";
        }
        private void NextPassFourCommandExecuted()
        {
            ContentViewCuatro = "False";
            ContentViewCinco = "True";
        }
        private void NextPassFiveCommandExecuted()
        {
            ContentViewCinco = "False";
            ContentViewSeis = "True";
        }
        private void NextPassSixCommandExecuted()
        {
            ContentViewSeis = "False";
            ContentViewTres = "False";
            HeaderContent = "False";
            BoxLine = "False";
            ContentProgressBar = "False";
            ContentViewResultado = "True";
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

        private async void FinalCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri($"/Index/Navigation/Home", UriKind.Absolute));
        }
        #endregion
    }
}
