using ANightsTale.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library
{
    public class RngProvider : IRngProvider
    {
        public Random Rng { get; set; } = new Random();
    }
}
