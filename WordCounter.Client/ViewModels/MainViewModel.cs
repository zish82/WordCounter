using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using WordCounter.Client.Core;

namespace WordCounter.Client.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly ICount count;
        
        public string StringText { get; set; }

        public ICommand CountWordsCommand { get; set; }
        public ObservableCollection<WordCountViewModel> CountedWords { get; private set; }

        public MainViewModel(ICount count)
        {
            this.count = count;
            CountWordsCommand = new DelegateCommand(CountWordsExecute, CountWordsCanExecute);
            CountedWords = new ObservableCollection<WordCountViewModel>();
            StringText = "Please type your search here";
        }

        private bool CountWordsCanExecute()
        {
            return !string.IsNullOrWhiteSpace(StringText);
        }

        private void CountWordsExecute()
        {
            count.Count(StringText, CountedWords);
        }
    }
}
