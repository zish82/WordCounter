using System.Collections.ObjectModel;
using Moq;
using NUnit.Framework;
using WordCounter.Client.Core;
using WordCounter.Client.ViewModels;

namespace UnitTest.ViewModelTests
{
    [TestFixture]
    public class WhenCountingWords
    {
        [TestCase("this is text", false, ExpectedResult = true)]
        [TestCase("", false, ExpectedResult = false)]
        [TestCase(" ", false, ExpectedResult = false)]
        [TestCase("this is text", true, ExpectedResult = false)]
        [TestCase("", true, ExpectedResult = false)]
        [TestCase(" ", true, ExpectedResult = false)]
        public bool CanCountWordsWhenStringSearch(string stringText, bool isBusy)
        {
            var counter = new StringCounter();
            var viewModel = new MainViewModel(counter) {StringText = stringText, IsBusy = isBusy};

            var countedWords = viewModel.CountWordsCommand;

            return countedWords.CanExecute(null);
        }

        [Test]
        public void CallsStringCounterOnExecute()
        {
            const string stringText = "hello how are you";
            var counter = new Mock<ICount>();
            var viewModel = new MainViewModel(counter.Object) { StringText = stringText };

            viewModel.CountWordsCommand.Execute(null);

            counter.Verify(x => x.Count(It.Is<string>(s => s == stringText), It.IsAny<ObservableCollection<WordCountViewModel>>()));
        }

        [Test]
        public void ExecuteCommandClearsPrviousResults()
        {
            const string stringText = "hello how are you";
            var counter = new Mock<ICount>();
            var viewModel = new MainViewModel(counter.Object) { StringText = stringText };
            viewModel.CountedWords.Add(new WordCountViewModel());

            viewModel.CountWordsCommand.Execute(null);

            Assert.That(viewModel.CountedWords.Count, Is.EqualTo(0));
        }
    }
}
