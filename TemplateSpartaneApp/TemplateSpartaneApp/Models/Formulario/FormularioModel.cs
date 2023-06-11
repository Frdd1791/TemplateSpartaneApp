using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.Models.Formulario
{
    public partial class FormularioModel : ModelBase
    {
        public int Clave { get; set; }
        public string Description { get; set; }
    }
}
