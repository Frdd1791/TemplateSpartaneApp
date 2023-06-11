using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.Spartane;

namespace TemplateSpartaneApp.Services.Spartane
{
    public interface ISpartaneQueryService
    {
        [Post("/Spartan_Query/Post")]
        [Headers("Authorization: Bearer")]
        Task<double?> PostQuery([Body] SpartaneQueryModel body);

        [Post("/Spartan_Query/Post")]
        [Headers("Authorization: Bearer")]
        Task<string> PostQueryString([Body] SpartaneQueryModel body);

        [Post("/Spartan_Query/GetRawQuery")]
        [Headers("Authorization: Bearer")]
        Task<T> GetRawQuery<T>([Body] SpartaneQueryModel body);
    }
}
