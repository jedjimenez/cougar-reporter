using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace cougar_reporter.Models
{
    [Table(nameof(RegUserTable))]
    class RegUserTable
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
