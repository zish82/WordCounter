using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace WordCounter.Core
{
    public class StringCounter : ICount
    {
        private static string[] GetSplitString(string searchString)
        {
            string[] source = searchString.Split(new char[] {'.', '?', '!', ' ', ';', ':', ','},
                StringSplitOptions.RemoveEmptyEntries);
            return source;
        }

        public ObservableCollection<WordCountViewModel> Count(string searchString)
        {
            var result = new ObservableCollection<WordCountViewModel>();

            if (string.IsNullOrEmpty(searchString))
                return result;

            var source = GetSplitString(searchString);
            var matchQuery = source.Distinct();

            foreach (var item in matchQuery)
            {
                result.Add(new WordCountViewModel{ Word = item, Count = source.Count(x => x == item)});
            }

            return result;
        }
    }
}
