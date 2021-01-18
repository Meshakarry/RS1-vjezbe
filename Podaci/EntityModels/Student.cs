using System;
using System.Collections.Generic;
using System.Text;

namespace Podaci.EntityModels
{
    public class Student
    {
        public int studentID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Br_Ind { get; set; }
        public Opstina Opstina { get; set; }
        public int opstinaID { get; set; }

        public Fakultet Fakultet { get; set; }
        public int fakultetID { get; set; }


    }
}
