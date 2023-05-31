using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.Models.ProductosEnterales
{
    public partial class ListProductosEnteralesModel : ModelBase
    {
        [JsonProperty("ProductosEnterales")]
        public List<ProductosEnteralesModel> listProductosEnterales { get; set; }

        [JsonProperty("RowCount")]
        public int RowCount { get; set; }
    }
    public partial class ProductosEnteralesModel : ModelBase
    {
        public int Id { get; set; }
        public string ImageProduct { get; set; }
        public string NombreProducto { get; set; }
    }
}
