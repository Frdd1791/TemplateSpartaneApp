using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateSpartaneApp.Models.Spartane
{
    public class SpartaneQueryModel
    {
        [JsonProperty("query")]
        public string Query { get; set; }
    }
}
