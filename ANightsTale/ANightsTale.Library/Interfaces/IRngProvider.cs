using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library.Interfaces
{
    public interface IRngProvider
    {
        Random Rng { get; set; }
    }
}
