using System.Collections.Generic;

namespace TddDemo
{
    public interface IBankCodeResolver
    {
        IEnumerable<string> Resolve();
    }
}