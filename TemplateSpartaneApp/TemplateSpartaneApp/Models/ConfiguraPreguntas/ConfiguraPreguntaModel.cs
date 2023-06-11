using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.Models.ConfiguraPreguntas
{
    public partial class ListConfigPreguntaModel : ModelBase
    {
        [JsonProperty("ConfigPregunta")]
        public List<ConfigPregunta> listPreguntas { get; set; }

        [JsonProperty("RowCount")]
        public int RowCount { get; set; }
    }
    public partial class ConfigPregunta : ModelBase
    {
        public int Clave { get; set; }
        public int Formulario { get; set; }
        public int Titulo { get; set; }
        public string subtitulo { get; set; }
        public int No_Paso { get; set; }
        public int Tipo { get; set; }
        public string Pregunta { get; set; }
        public bool Campo_Formula { get; set; }
        public int Tipo_Campo { get; set; }
        public int Tipo_Respuesta { get; set; }
        public int Requerido { get; set; }
        public int Mostrar_Globos { get; set; }
        public string Mensaje_del_Globo { get; set; }
        public bool Desactivar_Pregunta { get; set; }
    }
}
