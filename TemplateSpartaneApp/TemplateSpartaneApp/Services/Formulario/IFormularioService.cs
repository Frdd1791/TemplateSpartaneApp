using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateSpartaneApp.Models.Formulario;

namespace TemplateSpartaneApp.Services.Formulario
{
    public interface IFormularioService
    {
        [Get("/Formulario/Get")]
        [Headers("Authorization: Bearer")]
        Task<FormularioModel> Get(int id);
    }
}
