using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using Xamarin.Forms;

namespace TemplateSpartaneApp.Models.Pacientes
{
    public partial class ListPacientes : ModelBase
    {
        [JsonProperty("Pacientes")]
        public List<PacientesModel> listPacientes { get; set; }

        [JsonProperty("RowCount")]
        public int RowCount { get; set; }
    }
    public partial class PacientesModel : ModelBase
    {
        public string Name { get; set; }
        public ImageSource Icon { get; set; }
    }
}
