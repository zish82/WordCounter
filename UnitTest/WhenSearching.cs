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
            var searchString = "";
            var searcher = new StringCounter();

            var values = searcher.Search(searchString);

            Assert.That(values.Count, Is.EqualTo(0));
        }
    }
}
