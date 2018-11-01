using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace GraphLib.DynamicModel
{
    public class DynamicDataTable
    {
        public string Name { get; set; }

        public string InternalName { get; set; }

        public List<DynamicField> Fields { get; set; }

        public JObject Data { get; set; }
    }
}