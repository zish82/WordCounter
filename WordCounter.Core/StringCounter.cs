using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCounter.Core
{
    public class StringCounter : ICount
    {
        public IDictionary<string, int> Search(string searchString)
        {
            var result = new Dictionary<string, int>();

            if (string.IsNullOrEmpty(searchString))
                return result;

            var source = GetSplitString(searchString);
            var matchQuery = source.Distinct();
            
            foreach (var item in matchQuery)
            {
                result.Add(item, source.Count(x => x == item));
            }

            return result;
        }

        private static string[] GetSplitString(string searchString)
        {
            string[] source = searchString.Split(new char[] {'.', '?', '!', ' ', ';', ':', ','},
                StringSplitOptions.RemoveEmptyEntries);
            return source;
        }
    }
}
