using Prism.Mvvm;

namespace WordCounter.Client.ViewModels
{
    public class WordCountViewModel : BindableBase
    {
        public string Word { get; set; }
        public int Count { get; set; }
    }
}