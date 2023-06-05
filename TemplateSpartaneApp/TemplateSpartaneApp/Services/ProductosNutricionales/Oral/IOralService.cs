using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.ProductosEnterales;
using TemplateSpartaneApp.Models.ProductosOrales;

namespace TemplateSpartaneApp.Services.ProductosNutricionales.Oral
{
    public interface IOralService
    {
        [Get("/Oral/Get")]
        [Headers("Authorization: Bearer")]
        Task<ProductosOrales> Get(int id);

        [Get("/Oral/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ListProductosOralesModel> GetAll();

        [Get("/Oral/ListaSelAll")]
        [Headers("Authorization: Bearer")]
        Task<ListProductosOralesModel> ListaSelAll(int startRowIndex, int maximumRows, string where = null, string order = null);

        [Post("/Oral/Post")]
        [Headers("Authorization: Bearer")]
        Task<int> Post([Body] ProductosOrales item);

        [Put("/Oral/Put")]
        [Headers("Authorization: Bearer")]
        Task<int> Put(int id, [Body] ProductosOrales item);

        [Delete("/Oral/Delete")]
        [Headers("Authorization: Bearer")]
        Task<bool> Delete(int id);
    }
}
