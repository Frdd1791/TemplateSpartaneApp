using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using TemplateSpartaneApp.Models.Evaluaciones;
using Xamarin.Forms;

namespace TemplateSpartaneApp.Models.CalculosNutricionales
{
    public partial class ListCalculosN : ModelBase
    {
        [JsonProperty("Evaluaciones")]
        public List<CalculosNModel> listCalculosN { get; set; }

        [JsonProperty("RowCount")]
        public int RowCount { get; set; }
    }
    public partial class CalculosNModel : ModelBase
    {
        public string Fecha { get; set; }
    }
}
