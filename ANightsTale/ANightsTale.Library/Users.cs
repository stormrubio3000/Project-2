using System;
using System.Collections.Generic;
using System.Text;

namespace ANightsTale.Library
{
    public class Users
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Permission { get; set; }
        public string Email { get; set; }
    }
}
