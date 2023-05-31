using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateSpartaneApp.LocalData
{
    public class Validaciones
    {
        /// <summary>
        /// Settings service
        /// </summary>
        private ISettings settingsService;

        /// <summary>
        /// Instance
        /// </summary>
        private static Validaciones instance;

        /// <summary>
        /// Instance
        /// </summary>
        public static Validaciones Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = new Validaciones();
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
        public bool Premium
        {
            get
            {
                return settingsService.GetValueOrDefault($"{nameof(Validaciones)}{nameof(Premium)}", default(bool));
            }

            set
            {
                settingsService.AddOrUpdateValue($"{nameof(Validaciones)}{nameof(Premium)}", value);
            }
        }

        /// <summary>
        /// Clear values
        /// </summary>
        public void ClearValues()
        {
            Premium = default(bool);
        }
    }
}
