using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.Pacientes;
using TemplateSpartaneApp.Models.ProductosEnterales;

namespace TemplateSpartaneApp.Services.Pacientes
{
    public interface IPacientesService
    {
        [Get("/Mi_Paciente/Get")]
        [Headers("Authorization: Bearer")]
        Task<PacientesModel> Get(int id);

        [Get("/Mi_Paciente/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ListPacientes> GetAll();

        [Get("/Mi_Paciente/ListaSelAll")]
        [Headers("Authorization: Bearer")]
        Task<ListPacientes> ListaSelAll(int startRowIndex, int maximumRows, string where = null, string order = null);

        [Post("/Mi_Paciente/Post")]
        [Headers("Authorization: Bearer")]
        Task<int> Post([Body] PacientesModel item);

        [Put("/Mi_Paciente/Put")]
        [Headers("Authorization: Bearer")]
        Task<int> Put(int id, [Body] PacientesModel item);

        [Delete("/Mi_Paciente/Delete")]
        [Headers("Authorization: Bearer")]
        Task<bool> Delete(int id);
    }
}
