using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.ProductosEnterales;

namespace TemplateSpartaneApp.Services.ProductosNutricionales.Enteral
{
    public interface IEnteralService
    {
        [Get("/Enteral/Get")]
        [Headers("Authorization: Bearer")]
        Task<ProductosEnteralesModel> Get(int id);

        [Get("/Enteral/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ListProductosEnteralesModel> GetAll();

        [Get("/Enteral/ListaSelAll")]
        [Headers("Authorization: Bearer")]
        Task<ListProductosEnteralesModel> ListaSelAll(int startRowIndex, int maximumRows, string where = null, string order = null);

        [Post("/Enteral/Post")]
        [Headers("Authorization: Bearer")]
        Task<int> Post([Body] ProductosEnteralesModel item);

        [Put("/Enteral/Put")]
        [Headers("Authorization: Bearer")]
        Task<int> Put(int id, [Body] ProductosEnteralesModel item);

        [Delete("/Enteral/Delete")]
        [Headers("Authorization: Bearer")]
        Task<bool> Delete(int id);
    }
}
