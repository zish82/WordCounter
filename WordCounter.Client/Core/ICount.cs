using System.Collections.ObjectModel;
using WordCounter.Client.ViewModels;

namespace WordCounter.Client.Core
{
    public interface ICount
    {
        ObservableCollection<WordCountViewModel> Count(string searchString, ObservableCollection<WordCountViewModel> wordCount);
    }
}