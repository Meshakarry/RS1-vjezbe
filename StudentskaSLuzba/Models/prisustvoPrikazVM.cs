using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSLuzba.Models
{
    public class prisustvoPrikazVM
    {
        public string NazivStudenta { get; set; }

        public class Zapis
        {

            public string Predmet { get; set; }
            public DateTime datum { get; set; }


        }
        public List<Zapis> prisustva { get; set; }


    }
}
