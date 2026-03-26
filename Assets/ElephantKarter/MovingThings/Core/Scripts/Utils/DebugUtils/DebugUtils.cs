using System.Collections.Generic;

namespace CoreDomain.Scripts.Utils.DebugUtils
{
    public static class DebugUtils
    {
        public static string CollectionToString<TElement>(ICollection<TElement> elements)
        {
            var str = "";
            foreach (var e in elements)
            {
                str += e.ToString() + "\n";
            }
            return str;
        }
        public static string DictionaryToString<TKey, TValue>(Dictionary<TKey, TValue> dictinoary)
        {
            var str = "";
            foreach (var kvp in dictinoary)
            {
                str += $"{kvp.Key} : {kvp.Value} \n";
            }
            return str;
        }
    }
}
