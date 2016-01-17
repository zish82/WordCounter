using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using WordCounter.Core;

namespace UnitTest.CoreTests
{
    [TestFixture]
    public class WhenSearching
    {
        [Test]
        public void EmptySearchReturnsNoResult()
        {
            const string searchString = "";
            var searcher = new StringCounter();

            var values = searcher.Count(searchString);

            Assert.That(values.Count, Is.EqualTo(0));
        }

        [Test]
        public void CounterReturnsCountedWords()
        {
            const string searchString = "how are you, what are you doing";
            var expectedResult = new ObservableCollection<WordCount>
            {
                new WordCount { Word = "how", Count = 1},
                new WordCount { Word = "are", Count = 2},
                new WordCount { Word = "you", Count = 2},
                new WordCount { Word = "what", Count = 1},
                new WordCount { Word = "doing", Count = 1}
            };
            var searcher = new StringCounter();

            var values = searcher.Count(searchString);

            Assert.That(values.Count, Is.EqualTo(expectedResult.Count));
            Assert.IsTrue(expectedResult.All(x => Contains(values, x)));
        }

        private static bool Contains(IEnumerable<WordCount> values, WordCount x)
        {
            var contains = values.Any(y => y.Word == x.Word && y.Count == x.Count);
            return contains;
        }
    }
}
