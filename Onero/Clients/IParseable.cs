using System.Collections.Generic;

namespace Onero
{
    public interface IParseable
    {
        IEnumerable<string> Parse();
    }
}
