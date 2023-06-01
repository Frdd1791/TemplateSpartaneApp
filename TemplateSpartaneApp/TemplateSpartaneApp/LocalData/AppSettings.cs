using Plugin.Settings.Abstractions;

namespace TemplateSpartaneApp.LocalData
{
    public class AppSettings
    {
        /// <summary>
        /// Settings service
        /// </summary>
        private ISettings settingsService;

        /// <summary>
        /// Instance
        /// </summary>
        private static AppSettings instance;

        /// <summary>
        /// Instance
        /// </summary>
        public static AppSettings Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new AppSettings();
                }

                return instance;
            }
        }

        /// <summary>
        /// Initialize the app data service
        /// </summary>
        /// <param name="settingsService">Settings Service</param>
        public void Initialize(ISettings settingsService)
        {
            this.settingsService = settingsService;
        }

        /// <summary>
        /// User is logged
        /// </summary>
        public bool Logged
        {
            get
            {
                return settingsService.GetValueOrDefault($"{nameof(AppSettings)}{nameof(Logged)}", default(bool));
            }

            set
            {
                settingsService.AddOrUpdateValue($"{nameof(AppSettings)}{nameof(Logged)}", value);
            }
        }

        /// <summary>
        /// User is Premium
        /// </summary>
        public bool Premium
        {
            get
            {
                return settingsService.GetValueOrDefault($"{nameof(AppSettings)}{nameof(Premium)}", default(bool));
            }

            set
            {
                settingsService.AddOrUpdateValue($"{nameof(AppSettings)}{nameof(Premium)}", value);
            }
        }

        /// <summary>
        /// Aviso Oral
        /// </summary>
        public bool isAviso
        {
            get
            {
                return settingsService.GetValueOrDefault($"{nameof(AppSettings)}{nameof(isAviso)}", default(bool));
            }

            set
            {
                settingsService.AddOrUpdateValue($"{nameof(AppSettings)}{nameof(isAviso)}", value);
            }
        }

        /// <summary>
        /// Remember username
        /// </summary>
        public bool RememberUserName
        {
            get => settingsService.GetValueOrDefault($"{nameof(AppSettings)}{nameof(RememberUserName)}", default(bool));
            set => settingsService.AddOrUpdateValue($"{nameof(AppSettings)}{nameof(RememberUserName)}", value);
        }

        /// <summary>
        /// Clear values
        /// </summary>
        public void ClearValues()
        {
            Logged = default(bool);
            Premium = default(bool);
            isAviso = default(bool);
        }
    }
}
