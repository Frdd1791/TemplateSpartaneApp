using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.Models.ProductosParenterales
{
    public partial class ListProductosParenteralesModel : ModelBase
    {
        [JsonProperty("ProductosParenterales")]
        public List<ProductosParenteralesModel> listProductosParenterales { get; set; }

        [JsonProperty("RowCount")]
        public int RowCount { get; set; }
    }
    public partial class ProductosParenteralesModel : ModelBase
    {
        public int Id { get; set; }
        public string ImageProduct { get; set; }
        public string NombreProducto { get; set; }
    }
}
