using System;
using System.Collections.Generic;
using System.Text;

namespace cougar_reporter.Models
{
    class Ticket
    {
        /*Ticket Information*/
        public string RepairType { get; set; }
        public string Building { get; set; }
        public string RoomNum { get; set; }
        public string Description { get; set; }
    }
}
