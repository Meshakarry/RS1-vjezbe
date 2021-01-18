using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSLuzba.Models
{
    public class studentPrikazVM
    {
        public class Row
        {
            public int studentID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public string Br_Ind { get; set; }
            public string Fakultet { get; set; }
            public string Opstina { get; set; }

        }

        public List<Row> studenti { get; set; }

        public string query { get; set; }
    }
}
