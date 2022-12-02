using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firebase.Models
{
    public class Room
    {
        public int index { get; set; }
        public string RoomName { get; set; }
        public int Set_Temp { get; set; }
        public int Status { get; set; }
        public int Temp { get; set; }
        public int Voltage { get; set; }
    }

}
