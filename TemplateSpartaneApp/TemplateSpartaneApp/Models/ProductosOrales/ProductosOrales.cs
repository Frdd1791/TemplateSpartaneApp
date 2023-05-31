﻿using Newtonsoft.Json;
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
        public int Id { get; set; }
        public string ImageProduct { get; set; }
        public string NombreProducto { get; set; }
    }
}
