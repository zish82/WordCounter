using System.Collections.Generic;

namespace WordCounter.Core
{
    public interface ICount
    {
        IDictionary<string, int> Search(string searchString);
    }
}