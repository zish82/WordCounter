using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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
                Task.Delay(2000);
            }
        }

        private static string[] GetSplitString(string searchString)
        {
            string[] source = searchString.Split(new char[] {'.', '?', '!', ' ', ';', ':', ','},
                StringSplitOptions.RemoveEmptyEntries);
            return source;
        }
    }
}
