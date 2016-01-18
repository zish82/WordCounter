using System.Collections.ObjectModel;

namespace WordCounter.Core
{
    public interface ICount
    {
        ObservableCollection<WordCountViewModel> Count(string searchString);
    }
}