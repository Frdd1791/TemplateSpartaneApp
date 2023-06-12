using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateSpartaneApp.Abstractions;

namespace TemplateSpartaneApp.Helpers
{
    public class GlobalMethods
    {
        public static TModel DeserializeObjectWithSlashes<TModel>(ResponseBase<string> value)
        {
            var result = value.Response.Replace("\\\"", "\"").Replace("\\\\\\\\", "\\\\").Replace("\\\"", "\"").TrimStart('"').TrimEnd('"');
            var requests = JsonConvert.DeserializeObject<TModel>(result);
            return requests;
        }
    }
}
