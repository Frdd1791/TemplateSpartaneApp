using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.Pacientes;
using TemplateSpartaneApp.Settings;

namespace TemplateSpartaneApp.Services.Pacientes
{
    public class PacientesService : IPacientesService
    {
        private readonly IPacientesService pacienteService;
        public PacientesService()
        {
            pacienteService = RestService.For<IPacientesService>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(AppConfiguration.Values.BaseUrl) }, new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CustomResolver()
                }
            });
        }

        public Task<bool> Delete(int id)
        {
            return pacienteService.Delete(id);
        }

        public Task<MiPaciente> Get(int id)
        {
            return pacienteService.Get(id);
        }

        public Task<ListPacientesModel> GetAll()
        {
            return pacienteService.GetAll();
        }

        public Task<ListPacientesModel> ListaSelAll(int startRowIndex, int maximumRows, string where = null, string order = null)
        {
            return pacienteService.ListaSelAll(startRowIndex, maximumRows, where, order);
        }

        public Task<int> Post([Body] MiPaciente item)
        {
            return pacienteService.Post(item);
        }

        public Task<int> Put(int id, [Body] MiPaciente item)
        {
            return pacienteService.Put(id, item);
        }
    }
}
