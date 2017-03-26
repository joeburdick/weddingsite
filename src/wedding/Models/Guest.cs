using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wedding.Models
{
    public class Guest : IdEntity
    {
        public string Name { get; set; }
        public bool OrderBeef { get; set; }
        public bool OrderChicken { get; set; }
        public bool OrderFish { get; set; }
    }
}
