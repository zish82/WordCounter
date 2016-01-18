using System;
using System.Collections.ObjectModel;
using System.Linq;
using WordCounter.Client.ViewModels;

namespace WordCounter.Client.Core
{
    public class WordsCounterService : ICount
    {
        public void Count(string sentence, ObservableCollection<WordCountViewModel> wordCount)
        {
            var source = GetSplitString(sentence);
            var matchQuery = source.Distinct();

            foreach (var item in matchQuery)
            {
                wordCount.Add(new WordCountViewModel { Word = item, Count = source.Count(x => x == item) });
            }
        }

        private string[] GetSplitString(string sentence)
        {
            var source = sentence.Split(new[] {'.', '?', '!', ' ', ';', ':', ','}, StringSplitOptions.RemoveEmptyEntries);
            return source;
        }
    }
}
