using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.ConfiguraPreguntas;
using TemplateSpartaneApp.Models.Pacientes;

namespace TemplateSpartaneApp.Services.ConfiguraPreguntas
{
    public interface IConfiguraPreguntaService
    {
        [Get("/Configura_Pregunta/Get")]
        [Headers("Authorization: Bearer")]
        Task<ConfigPregunta> Get(int id);

        [Get("/Configura_Pregunta/GetAll")]
        [Headers("Authorization: Bearer")]
        Task<ListConfigPreguntaModel> GetAll();

        [Get("/Configura_Pregunta/ListaSelAll")]
        [Headers("Authorization: Bearer")]
        Task<ListConfigPreguntaModel> ListaSelAll(int startRowIndex, int maximumRows, string where = null, string order = null);

        [Post("/Configura_Pregunta/Post")]
        [Headers("Authorization: Bearer")]
        Task<int> Post([Body] ConfigPregunta item);

        [Put("/Configura_Pregunta/Put")]
        [Headers("Authorization: Bearer")]
        Task<int> Put(int id, [Body] ConfigPregunta item);

        [Delete("/Configura_Pregunta/Delete")]
        [Headers("Authorization: Bearer")]
        Task<bool> Delete(int id);
    }
}
