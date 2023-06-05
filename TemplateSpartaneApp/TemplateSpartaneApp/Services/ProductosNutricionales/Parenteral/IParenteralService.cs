using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.ProductosEnterales;
using TemplateSpartaneApp.Models.ProductosParenterales;

namespace TemplateSpartaneApp.Services.ProductosNutricionales.Parenteral
{
    public interface IParenteralService
    {
        [Get("/Parenteral/Get")]
        [Headers("Authorization: Bearer")]
        Task<ProductosParenteralesModel> Get(int id);

        [Get("/Parenteral/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ListProductosParenteralesModel> GetAll();

        [Get("/Parenteral/ListaSelAll")]
        [Headers("Authorization: Bearer")]
        Task<ListProductosParenteralesModel> ListaSelAll(int startRowIndex, int maximumRows, string where = null, string order = null);

        [Post("/Parenteral/Post")]
        [Headers("Authorization: Bearer")]
        Task<int> Post([Body] ProductosParenteralesModel item);

        [Put("/Parenteral/Put")]
        [Headers("Authorization: Bearer")]
        Task<int> Put(int id, [Body] ProductosParenteralesModel item);

        [Delete("/Parenteral/Delete")]
        [Headers("Authorization: Bearer")]
        Task<bool> Delete(int id);
    }
}
