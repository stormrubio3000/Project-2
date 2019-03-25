using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANightsTaleAPI.Models
{
    public class AccountDetails
    {
        public string Username { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
