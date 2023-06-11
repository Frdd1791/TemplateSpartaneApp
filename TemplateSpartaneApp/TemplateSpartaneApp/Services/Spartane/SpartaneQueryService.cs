using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.Spartane;
using TemplateSpartaneApp.Settings;

namespace TemplateSpartaneApp.Services.Spartane
{
    public class SpartaneQueryService : ISpartaneQueryService
    {
        private readonly ISpartaneQueryService _ServiceQuery;

        public SpartaneQueryService()
        {
            _ServiceQuery = RestService.For<ISpartaneQueryService>(new HttpClient(new HttpLoggingHandler(TokenManager.GetToken)) { BaseAddress = new Uri(AppConfiguration.Values.BaseUrl) }, new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CustomResolver()
                }
            });
        }

        public Task<T> GetRawQuery<T>([Body] SpartaneQueryModel body)
        {
            return _ServiceQuery.GetRawQuery<T>(body);
        }

        public Task<double?> PostQuery([Body] SpartaneQueryModel body)
        {
            return _ServiceQuery.PostQuery(body);
        }

        public Task<string> PostQueryString([Body] SpartaneQueryModel body)
        {
            return _ServiceQuery.PostQueryString(body);
        }
    }
}
