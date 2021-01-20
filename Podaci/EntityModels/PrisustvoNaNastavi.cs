using System;
using System.Collections.Generic;
using System.Text;

namespace Podaci.EntityModels
{
     public class PrisustvoNaNastavi
    {
        public int ID { get; set; }
        public int studentID { get; set; }
        public Student student { get; set; }
        public int predmetID { get; set; }
        public Predmet predmet { get; set; }

        public DateTime datum_prisustva { get; set; }

        public bool IsPrisutan { get; set; }
        public string komentar { get; set; }
    }
}
