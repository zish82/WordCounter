using System;
using System.Collections.ObjectModel;
using System.Linq;
using WordCounter.Client.ViewModels;

namespace WordCounter.Client.Core
{
    public class StringCounter : ICount
    {
        public void Count(string searchString, ObservableCollection<WordCountViewModel> wordCount)
        {
            var source = GetSplitString(searchString);
            var matchQuery = source.Distinct();

            foreach (var item in matchQuery)
            {
                wordCount.Add(new WordCountViewModel { Word = item, Count = source.Count(x => x == item) });
            }
        }

        private static string[] GetSplitString(string searchString)
        {
            var source = searchString.Split(new[] {'.', '?', '!', ' ', ';', ':', ','}, StringSplitOptions.RemoveEmptyEntries);
            return source;
        }
    }
}
