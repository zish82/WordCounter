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
        private bool isBusy;
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

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
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
            stringText = "awhat are you doing what are you doing";

        }

        private bool CountWordsCanExecute()
        {
            return !string.IsNullOrWhiteSpace(StringText) && !isBusy;
        }

        private void CountWordsExecute()
        {
            CountedWords.Clear();
            IsBusy = true;
            count.Count(StringText, CountedWords);
            IsBusy = false;
        }

        private void RaiseCanExecuteChanged()
        {
            var command = CountWordsCommand as DelegateCommand;
            command.RaiseCanExecuteChanged();
        }
    }
}
