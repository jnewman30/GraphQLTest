using System.Collections.Generic;

namespace GraphLib.DynamicModel
{
    public class DynamicDataRow
    {
        public IEnumerable<KeyValuePair<string, string>> Fields { get; set; }
    }
}