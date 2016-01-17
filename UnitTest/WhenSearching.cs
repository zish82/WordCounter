using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using WordCounter.Core;

namespace UnitTest
{
    [TestFixture]
    public class WhenSearching
    {
        [Test]
        public void EmptySearchReturnsNoResult()
        {
            const string searchString = "";
            var searcher = new StringCounter();

            var values = searcher.Search(searchString);

            Assert.That(values.Count, Is.EqualTo(0));
        }

        [Test]
        public void CounterReturnsCountedWords()
        {
            const string searchString = "how are you, what are you doing";
            var expectedResult = new Dictionary<string, int>
            {
                {"how", 1},
                {"are", 2},
                {"you", 2},
                {"what", 1},
                {"doing", 1}
            };
            var searcher = new StringCounter();

            var values = searcher.Search(searchString);

            Assert.That(values.Count, Is.EqualTo(expectedResult.Count));
            Assert.IsTrue(expectedResult.All(x => values.Contains(x)));
        }
    }
}
