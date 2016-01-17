using NUnit.Framework;
using WordCounter.Core;

namespace UnitTest
{
    [TestFixture]
    public class WhenSearching
    {
        [Test]
        public void NothingFound()
        {
            var searchString = "";
            var searcher = new StringCounter();

            var values = searcher.Search(searchString);

            Assert.That(values.Count, Is.EqualTo(0));
        }
    }
}
