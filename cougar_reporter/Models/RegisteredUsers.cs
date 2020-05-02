using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace cougar_reporter.Models
{
    //[Table(nameof(RegisteredUsers))]
    class RegisteredUsers
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int AccountType { get; set; }
    }
}
