using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;
using Xamarin.Forms;

namespace TemplateSpartaneApp.Models.Pacientes
{
    public partial class ListPacientesModel : ModelBase
    {
        [JsonProperty("Mi_Pacientes")]
        public List<MiPaciente> listPacientes { get; set; }

        [JsonProperty("RowCount")]
        public int RowCount { get; set; }
    }
    public partial class MiPaciente : ModelBase
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int Usuario { get; set; }
        public string Nombre_del_Paciente { get; set; }
        public string Apellidoss { get; set; }
        public int Sexo { get; set; }
        public double Talla { get; set; }
        public double Peso_Actual { get; set; }
        public double Peso_Usual { get; set; }
        public double Peso_Ideal { get; set; }
        public double Peso_para_Calculo { get; set; }
        public double Creatinina { get; set; }
    }
}
