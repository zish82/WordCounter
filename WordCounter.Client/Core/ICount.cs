using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WordCounter.Client.ViewModels;

namespace WordCounter.Client.Core
{
    public interface ICount
    {
        Task<ObservableCollection<WordCountViewModel>> Count(string searchString, ObservableCollection<WordCountViewModel> wordCount);
    }
}