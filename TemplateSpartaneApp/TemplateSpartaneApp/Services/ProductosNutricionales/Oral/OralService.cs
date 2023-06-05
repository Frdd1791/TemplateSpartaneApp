using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.ProductosEnterales;
using TemplateSpartaneApp.Models.ProductosOrales;
using TemplateSpartaneApp.Services.ProductosNutricionales.Enteral;
using TemplateSpartaneApp.Settings;

namespace TemplateSpartaneApp.Services.ProductosNutricionales.Oral
{
    public class OralService : IOralService
    {
        private readonly IOralService oralService;
        public OralService()
        {
            oralService = RestService.For<IOralService>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(AppConfiguration.Values.BaseUrl) }, new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CustomResolver()
                }
            });
        }

        public Task<bool> Delete(int id)
        {
            return oralService.Delete(id);
        }

        public Task<ProductosOrales> Get(int id)
        {
            return oralService.Get(id);
        }

        public Task<ListProductosOralesModel> GetAll()
        {
            return oralService.GetAll();
        }

        public Task<ListProductosOralesModel> ListaSelAll(int startRowIndex, int maximumRows, string where = null, string order = null)
        {
            return oralService.ListaSelAll(startRowIndex, maximumRows, where, order);
        }

        public Task<int> Post([Body] ProductosOrales item)
        {
            return oralService.Post(item);
        }

        public Task<int> Put(int id, [Body] ProductosOrales item)
        {
            return oralService.Put(id, item);
        }
    }
}
