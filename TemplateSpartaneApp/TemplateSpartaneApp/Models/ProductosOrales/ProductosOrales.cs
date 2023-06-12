using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.Models.ProductosOrales
{

    public partial class ListProductosOralesModel : ModelBase
    {
        [JsonProperty("ProductosOrales")]
        public List<ProductosOrales> listProductosOrales { get; set; }

        [JsonProperty("RowCount")]
        public int RowCount { get; set; }
    }
    public partial class ProductosOrales : ModelBase
    {
        public int Productos_Nutricionales_Clave { get; set; }
        public string Productos_Nutricionales_Nombre { get; set; }
        public int Productos_Nutricionales_Grupo_de_Alimentos { get; set; }
        public string Grupo_de_Alimentos_Descripcion { get; set; }
        public int Productos_Nutricionales_Categoria { get; set; }
        public string Categoria_Descripcion { get; set; }
        public int? Productos_Nutricionales_Imagen { get; set; }
        public string Medidas_Oral_Medida { get; set; }
        public string Medidas_Oral_Detalle { get; set; }
    }
}
