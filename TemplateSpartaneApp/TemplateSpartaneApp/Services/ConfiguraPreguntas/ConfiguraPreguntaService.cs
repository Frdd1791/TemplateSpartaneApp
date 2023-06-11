using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.ConfiguraPreguntas;
using TemplateSpartaneApp.Models.Pacientes;
using TemplateSpartaneApp.Services.Pacientes;
using TemplateSpartaneApp.Settings;

namespace TemplateSpartaneApp.Services.ConfiguraPreguntas
{
    public class ConfiguraPreguntaService : IConfiguraPreguntaService
    {
        private readonly IConfiguraPreguntaService configuraPreguntaService;
        public ConfiguraPreguntaService()
        {
            configuraPreguntaService = RestService.For<IConfiguraPreguntaService>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(AppConfiguration.Values.BaseUrl) }, new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CustomResolver()
                }
            });
        }

        public Task<bool> Delete(int id)
        {
            return configuraPreguntaService.Delete(id);
        }

        public Task<ConfiguraPregunta> Get(int id)
        {
            return configuraPreguntaService.Get(id);
        }

        public Task<ListConfiguracionPreguntaModel> GetAll()
        {
            return configuraPreguntaService.GetAll();
        }

        public Task<ListConfiguracionPreguntaModel> ListaSelAll(int startRowIndex, int maximumRows, string where = null, string order = null)
        {
            return configuraPreguntaService.ListaSelAll(startRowIndex, maximumRows, where, order);
        }

        public Task<int> Post([Body] ConfiguraPregunta item)
        {
            return configuraPreguntaService.Post(item);
        }

        public Task<int> Put(int id, [Body] ConfiguraPregunta item)
        {
            return configuraPreguntaService.Put(id, item);
        }
    }
}
