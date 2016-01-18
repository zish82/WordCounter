using System;
using System.Collections.ObjectModel;
using System.Linq;
using WordCounter.Client.ViewModels;

namespace WordCounter.Client.Core
{
    public class StringCounter : ICount
    {
        public ObservableCollection<WordCountViewModel> Count(string searchString, ObservableCollection<WordCountViewModel> wordCount)
        {
            var result = new ObservableCollection<WordCountViewModel>();

            if (string.IsNullOrEmpty(searchString))
                return wordCount;

            var source = GetSplitString(searchString);
            var matchQuery = source.Distinct();

            foreach (var item in matchQuery)
            {
                wordCount.Add(new WordCountViewModel { Word = item, Count = source.Count(x => x == item) });
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
