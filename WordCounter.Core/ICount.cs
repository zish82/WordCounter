using System.Collections.ObjectModel;

namespace WordCounter.Core
{
    public interface ICount
    {
        ObservableCollection<WordCount> Count(string searchString);
    }
}