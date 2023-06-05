using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.ProductosEnterales;
using TemplateSpartaneApp.Settings;

namespace TemplateSpartaneApp.Services.ProductosNutricionales.Enteral
{
    public class EnteralService : IEnteralService
    {
        private readonly IEnteralService enteralService;
        public EnteralService()
        {
            enteralService = RestService.For<IEnteralService>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(AppConfiguration.Values.BaseUrl) }, new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CustomResolver()
                }
            });
        }

        public Task<bool> Delete(int id)
        {
            return enteralService.Delete(id);
        }

        public Task<ProductosEnteralesModel> Get(int id)
        {
            return enteralService.Get(id);
        }

        public Task<ListProductosEnteralesModel> GetAll()
        {
            return enteralService.GetAll();
        }

        public Task<ListProductosEnteralesModel> ListaSelAll(int startRowIndex, int maximumRows, string where = null, string order = null)
        {
            return enteralService.ListaSelAll(startRowIndex, maximumRows, where, order);
        }

        public Task<int> Post([Body] ProductosEnteralesModel item)
        {
            return enteralService.Post(item);
        }

        public Task<int> Put(int id, [Body] ProductosEnteralesModel item)
        {
            return enteralService.Put(id, item);
        }
    }
}
