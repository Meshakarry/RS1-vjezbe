using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSLuzba.Models
{
    public class StudentPredmetPrikaz
    {
        public int studentPredmetID { get; set; }
        public string NazivPredmeta { get; set; }
        public int Ocjena { get; set; }
        public DateTime Datum { get; set; }
    }
}
