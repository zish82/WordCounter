using System.Collections.ObjectModel;
using WordCounter.Client.ViewModels;

namespace WordCounter.Client.Core
{
    public interface ICount
    {
        void Count(string searchString, ObservableCollection<WordCountViewModel> wordCount);
    }
}