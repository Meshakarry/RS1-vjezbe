using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSLuzba.Models
{
    public class predmetPrikazVM
    {
        public class Row
        {
            public int predmetID { get; set; }
            public string Naziv { get; set; }
            public int Ocjena { get; set; }
            public string Student { get; set; }

        }

        public List<Row> predmeti { get; set; }
    }
}
