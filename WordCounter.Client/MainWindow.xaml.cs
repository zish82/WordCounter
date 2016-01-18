using System.Windows;
using WordCounter.Client.Core;
using WordCounter.Client.ViewModels;

namespace WordCounter.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainViewModel(new WordsCounterService());
            InitializeComponent();
        }
    }
}
