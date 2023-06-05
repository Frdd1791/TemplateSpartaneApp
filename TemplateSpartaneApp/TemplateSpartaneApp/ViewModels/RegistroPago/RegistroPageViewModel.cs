using Acr.UserDialogs;
using Plugin.Connectivity.Abstractions;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.Helpers;
using TemplateSpartaneApp.Models.Catalogs;
using TemplateSpartaneApp.Services.Session;
using TemplateSpartaneApp.ViewModels.Session;

namespace TemplateSpartaneApp.ViewModels.RegistroPago
{
    public class RegistroPageViewModel : ViewModelBase
    {
        #region Vars
        private static string TAG = nameof(RegistroPageViewModel);
        private ISessionService _sessionService;
        #endregion

        #region Vars Commands
        public DelegateCommand NextPageCommand { get; set; }
        public DelegateCommand ShowPageLoginCommand { get; set; }
        public DelegateCommand RegisterCommand { get; set; }
        #endregion

        #region Properties
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                SetProperty(ref email, value);
            }
        }
        private string pass;
        public string Pass
        {
            get { return pass; }
            set
            {
                SetProperty(ref pass, value);
            }
        }
        private string rePass;
        public string RePass
        {
            get { return rePass; }
            set
            {
                SetProperty(ref rePass, value);
            }
        }
        #endregion


        #region Contructor
        public RegistroPageViewModel(ISessionService sessionService, INavigationService navigationService, IUserDialogs userDialogsService, IConnectivity connectivity) : base(navigationService, userDialogsService, connectivity)
        {
            _sessionService = sessionService;
            RegisterCommand = new DelegateCommand(RegisterCommandExecute);
            ShowPageLoginCommand = new DelegateCommand(() => NavigationService.NavigateAsync("LogIn"));
        }
        #endregion

        #region Commands Methods
        private async void RegisterCommandExecute()
        {
            UserDialogsService.ShowLoading("Registrando...");
            string state = await ValidateEntry();
            if (string.IsNullOrEmpty(state))
            {

                UserSpartaneModel model = new UserSpartaneModel()
                {
                    IdUser = 0,
                    Name = Name,
                    Email = Email,
                    Status = 1,
                    Username = Email,
                    Password = HelperEncrypt.EncryptPassword(Pass)
                };
                ResponseBase<int> insert = await RunSafeApi<int>(_sessionService.Post(model));
                if (insert.Status == TypeReponse.Ok)
                {
                    UserDialogsService.HideLoading();
                    await NavigationService.GoBackAsync();
                }
                else
                {
                    UserDialogsService.HideLoading();
                    UserDialogsService.Alert("Error al crear nuevo usuario", "Alerta", "Aceptar");
                }
            }
            else
            {
                UserDialogsService.Alert(state, "Alerta", "Aceptar");
            }
            UserDialogsService.HideLoading();

        }
        public async Task<string> ValidateEntry()
        {
            string state = "";

            if (string.IsNullOrEmpty(Name))
            {
                state = "Por favor ingresé su Nombre.";
            }
            else if (string.IsNullOrEmpty(Email))
            {
                state = "El campo correó no puede estar vacío.";
            }
            else if (!IsValidEmail(Email))
            {
                state = "Por favor ingresé un correo válido.";
            }
            else if (await validateAccount(Email))
            {
                state = "Correo ya asociado a una cuenta, Por favor registre otro correo.";
            }
            else if (string.IsNullOrEmpty(Pass) || string.IsNullOrEmpty(RePass))
            {
                state = "Debe ingresar una contraseña.";
            }
            else if (ValidatePassword(Pass, RePass))
            {
                state = "Las contraseñas no coinciden.";
            }


            return state;
        }
        public async Task<bool> validateAccount(string email)
        {
            bool state = false;
            var resp = await RunSafeApi<SpartanUserList>(_sessionService.VerifyAccount(email));
            if (resp.Status == TypeReponse.Ok)
            {
                if (resp.Response.SpartanUsers != null && resp.Response.RowCount > 0)
                {
                    var user = resp.Response.SpartanUsers[0];
                    if (user.Username.Equals(email))
                    {
                        state = true;
                    }
                }
            }
            return state;
        }

        public bool ValidatePassword(string Pass, string RePass)
        {
            bool state = false;
            if (string.IsNullOrEmpty(Pass) || string.IsNullOrEmpty(RePass))
            {
                state = true;
            }
            else
            {
                if (Pass != RePass)
                {
                    state = true;
                }
            }
            return state;
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
        private async void NextPageCommandExecuted()
        {
            await NavigationService.NavigateAsync(new Uri("/Navigation/InitTwo", UriKind.Absolute));
        }

        #endregion
    }
}
