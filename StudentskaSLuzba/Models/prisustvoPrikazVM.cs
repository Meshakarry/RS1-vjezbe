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
            public bool IsPrisutan { get; set; }
            public string komentar { get; set; }
            public int prisustvoID { get; set; }


        }
        public List<Zapis> prisustva { get; set; }


    }
}
