using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.ProductosEnterales;
using TemplateSpartaneApp.Models.ProductosParenterales;
using TemplateSpartaneApp.Services.ProductosNutricionales.Enteral;
using TemplateSpartaneApp.Settings;

namespace TemplateSpartaneApp.Services.ProductosNutricionales.Parenteral
{
    public class ParenteralService : IParenteralService
    {
        private readonly IParenteralService parenteralService;
        public ParenteralService()
        {
            parenteralService = RestService.For<IParenteralService>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(AppConfiguration.Values.BaseUrl) }, new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CustomResolver()
                }
            });
        }

        public Task<bool> Delete(int id)
        {
            return parenteralService.Delete(id);
        }

        public Task<ProductosParenteralesModel> Get(int id)
        {
            return parenteralService.Get(id);
        }

        public Task<ListProductosParenteralesModel> GetAll()
        {
            return parenteralService.GetAll();
        }

        public Task<ListProductosParenteralesModel> ListaSelAll(int startRowIndex, int maximumRows, string where = null, string order = null)
        {
            return parenteralService.ListaSelAll(startRowIndex, maximumRows, where, order);
        }

        public Task<int> Post([Body] ProductosParenteralesModel item)
        {
            return parenteralService.Post(item);
        }

        public Task<int> Put(int id, [Body] ProductosParenteralesModel item)
        {
            return parenteralService.Put(id, item);
        }
    }
}
