using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.Formulario;
using TemplateSpartaneApp.Models.Pacientes;
using TemplateSpartaneApp.Services.Pacientes;
using TemplateSpartaneApp.Settings;

namespace TemplateSpartaneApp.Services.Formulario
{
    public class FormularioService : IFormularioService
    {
        private readonly IFormularioService pacienteService;
        public FormularioService()
        {
            pacienteService = RestService.For<IFormularioService>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(AppConfiguration.Values.BaseUrl) }, new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CustomResolver()
                }
            });
        }

        public Task<FormularioModel> Get(int id)
        {
            return pacienteService.Get(id);
        }
    }
}
