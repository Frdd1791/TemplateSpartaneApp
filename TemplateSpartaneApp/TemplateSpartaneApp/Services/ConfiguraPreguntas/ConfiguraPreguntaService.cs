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

        public Task<ConfigPregunta> Get(int id)
        {
            return configuraPreguntaService.Get(id);
        }

        public Task<ListConfigPreguntaModel> GetAll()
        {
            return configuraPreguntaService.GetAll();
        }

        public Task<ListConfigPreguntaModel> ListaSelAll(int startRowIndex, int maximumRows, string where = null, string order = null)
        {
            return configuraPreguntaService.ListaSelAll(startRowIndex, maximumRows, where, order);
        }

        public Task<int> Post([Body] ConfigPregunta item)
        {
            return configuraPreguntaService.Post(item);
        }

        public Task<int> Put(int id, [Body] ConfigPregunta item)
        {
            return configuraPreguntaService.Put(id, item);
        }
    }
}
