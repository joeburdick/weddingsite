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
            Guests = new List<Guest>();
            SongRequest = string.Empty;
            SongBan = string.Empty;
        }

        public string SongRequest { get; set; }
        public string SongBan { get; set; }
        public IList<Guest> Guests { get; set; }
    }
}
