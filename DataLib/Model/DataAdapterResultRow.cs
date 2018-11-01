using System.Collections.Generic;

namespace DataLib.Model
{
    public class DataAdapterResultRow
    {
        public IEnumerable<KeyValuePair<string, string>> Fields { get; set; }
    }
}