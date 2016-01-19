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
            const string sentence = "";
            var counter = new WordsCounterService();
            var countedWords = new ObservableCollection<WordCountViewModel>();

            counter.Count(sentence, countedWords);

            Assert.IsEmpty(countedWords);
        }

        [TestCase(".")]
        [TestCase("?")]
        [TestCase("!")]
        [TestCase(" ")]
        [TestCase(";")]
        [TestCase(":")]
        [TestCase(",")]
        public void SentencesSplitOnSpecialCharacters(string specialCharacter)
        {
            var sentence = string.Format("firstPart{0}secondPart", specialCharacter);
            var counter = new WordsCounterService();
            var countedWords = new ObservableCollection<WordCountViewModel>();
            var wordCountViewModels = new ObservableCollection<WordCountViewModel> { new WordCountViewModel { Word = "firstPart", Count = 1 }, new WordCountViewModel { Word = "secondPart", Count = 1 } };

            counter.Count(sentence, countedWords);

            Assert.That(countedWords.All(x => Contains(wordCountViewModels, x)));
        }

        [TestCaseSource("CounterServiceReturnsCountedWordsSource")]
        public void CounterServiceReturnsCountedWords(string sentence, ObservableCollection<WordCountViewModel> expectedResult)
        {
            var searcher = new WordsCounterService();
            var countedWords = new ObservableCollection<WordCountViewModel>();

            searcher.Count(sentence, countedWords);

            Assert.That(countedWords.Count, Is.EqualTo(expectedResult.Count));
            Assert.IsTrue(expectedResult.All(x => Contains(countedWords, x)));
        }

        protected IEnumerable<TestCaseData> CounterServiceReturnsCountedWordsSource()
        {
            yield return new TestCaseData("this", new ObservableCollection<WordCountViewModel> { new WordCountViewModel { Word = "this", Count = 1}});
            yield return new TestCaseData("this is a ", new ObservableCollection<WordCountViewModel>
            {
                new WordCountViewModel { Word = "this", Count = 1},
                new WordCountViewModel { Word = "is", Count = 1},
                new WordCountViewModel { Word = "a", Count = 1}
            });
            yield return new TestCaseData("this is a statement, and so is this.", new ObservableCollection<WordCountViewModel>
            {
                new WordCountViewModel { Word = "this", Count = 2},
                new WordCountViewModel { Word = "is", Count = 2},
                new WordCountViewModel { Word = "a", Count = 1},
                new WordCountViewModel { Word = "statement", Count = 1},
                new WordCountViewModel { Word = "and", Count = 1},
                new WordCountViewModel { Word = "so", Count = 1}
            });
        }

        private static bool Contains(IEnumerable<WordCountViewModel> values, WordCountViewModel x)
        {
            var contains = values.Any(y => y.Word == x.Word && y.Count == x.Count);
            return contains;
        }
    }
}
