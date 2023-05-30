using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using Xamarin.Forms;

namespace TemplateSpartaneApp.Models.Evaluaciones
{
    public partial class ListEvaluaciones : ModelBase
    {
        [JsonProperty("Evaluaciones")]
        public List<EvaluacionesModel> listEvaluaciones { get; set; }

        [JsonProperty("RowCount")]
        public int RowCount { get; set; }
    }
    public partial class EvaluacionesModel : ModelBase
    {
        public string Fecha { get; set; }
    }
}
