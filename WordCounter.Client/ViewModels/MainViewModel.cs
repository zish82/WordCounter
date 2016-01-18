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
        private string stringText;
        public ICommand CountWordsCommand { get; set; }

        public string StringText
        {
            get { return stringText; }
            set
            {
                stringText = value;
                OnPropertyChanged();
                RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<WordCountViewModel> CountedWords { get; private set; }

        public MainViewModel(ICount count)
        {
            this.count = count;
            CountWordsCommand = new DelegateCommand(CountWordsExecute, CountWordsCanExecute);
            CountedWords = new ObservableCollection<WordCountViewModel>();
        }

        private bool CountWordsCanExecute()
        {
            return !string.IsNullOrWhiteSpace(StringText);
        }

        private void CountWordsExecute()
        {
            count.Count(StringText, CountedWords);
        }

        private void RaiseCanExecuteChanged()
        {
            var command = CountWordsCommand as DelegateCommand;
            command.RaiseCanExecuteChanged();
        }
    }
}
