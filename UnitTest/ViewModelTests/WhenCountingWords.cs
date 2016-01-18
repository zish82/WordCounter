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
        [TestCase("this is text", ExpectedResult = true)]
        [TestCase("", ExpectedResult = false)]
        [TestCase(" ", ExpectedResult = false)]
        public bool CanCountWords(string stringText)
        {
            var counter = new StringCounter();
            var viewModel = new MainViewModel(counter) {StringText = stringText};

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
        
        [Test]
        public void ExecuteCommandSetsAndClearsBusyStatus()
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
