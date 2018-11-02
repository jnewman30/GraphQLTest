using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace DataLib
{
    public static class JsonExtensions
    {
        public static IDictionary<string, string> ToValueDictionary(this JToken root)
        {
            return root
                .WalkTokens()
                .OfType<JValue>()
                .ToDictionary(value => value.Path, value => value.Value.ToString());
        }

        private static IEnumerable<JToken> WalkTokens(this JToken node)
        {
            if (node == null)
            {
                yield break;
            }

            yield return node;
            foreach (var child in node.Children())
            foreach (var childNode in child.WalkTokens())
            {
                yield return childNode;
            }
        }
    }
}