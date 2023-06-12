using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.Models.ProductosOrales
{
    public partial class ListOrales : ModelBase
    {
        public List<OralesModel> listOrales { get; set; }

        [JsonProperty("RowCount")]
        public int RowCount { get; set; }
    }
    public partial class OralesModel : ModelBase
    {
        public string Grupo { get; set; }
        public string Nombre { get; set; }
        public string Medida_Detalle { get; set; }
        public string Medida_Medida { get; set; }
    }
}
