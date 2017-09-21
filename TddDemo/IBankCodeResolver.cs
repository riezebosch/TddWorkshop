using System.Collections.Generic;

namespace TddDemo
{
    interface IBankCodeResolver
    {
        IEnumerable<string> Resolve();
    }
}