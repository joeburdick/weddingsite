using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wedding.Models
{
    public class RSVP : IdEntity
    {       
        public RSVP()
        {
            Names = string.Empty;
            Attending = true;
            TriTip = 0;
            Chicken = 0;
            Salmon = 0;
        }

        public string Names { get; set; }

        public bool Attending { get; set; }

        public int TriTip { get; set; } 

        public int Chicken { get; set; }

        public int Salmon { get; set; }
    }
}
