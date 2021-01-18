using System;
using System.Collections.Generic;
using System.Text;

namespace Podaci.EntityModels
{
    public class PredmetOcjena
    {
        public int ID { get; set; }

        public int ocjenaID { get; set; }
        public  Ocjena ocjena { get; set; }

        public int predmetID { get; set; }
        public Predmet predmet { get; set; }

        public int studentID { get; set; }
        public Student student  { get; set; }

        public DateTime datum_polaganja { get; set; }




    }
}
