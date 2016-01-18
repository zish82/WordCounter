using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using WordCounter.Client.Core;
using WordCounter.Client.ViewModels;

namespace UnitTest.CoreTests
{
    [TestFixture]
    public class WhenCounting
    {
        [Test]
        public void EmptySearchReturnsNoResult()
        {
            const string countString = "";
            var searcher = new WordsCounterService();
            var countedWords = new ObservableCollection<WordCountViewModel>();

            searcher.Count(countString, countedWords);

            Assert.That(countedWords.Count, Is.EqualTo(0));
        }

        [Test]
        public void CounterReturnsCountedWords()
        {
            const string searchString = "this is a statement, and so is this.";
            var expectedResult = new ObservableCollection<WordCountViewModel>
            {
                new WordCountViewModel { Word = "this", Count = 2},
                new WordCountViewModel { Word = "is", Count = 2},
                new WordCountViewModel { Word = "a", Count = 1},
                new WordCountViewModel { Word = "statement", Count = 1},
                new WordCountViewModel { Word = "and", Count = 1},
                new WordCountViewModel { Word = "so", Count = 1}
            };
            var searcher = new WordsCounterService();
            var countedWords = new ObservableCollection<WordCountViewModel>();

            searcher.Count(searchString, countedWords);

            Assert.That(countedWords.Count, Is.EqualTo(expectedResult.Count));
            Assert.IsTrue(expectedResult.All(x => Contains(countedWords, x)));
        }

        private static bool Contains(IEnumerable<WordCountViewModel> values, WordCountViewModel x)
        {
            var contains = values.Any(y => y.Word == x.Word && y.Count == x.Count);
            return contains;
        }
    }
}
