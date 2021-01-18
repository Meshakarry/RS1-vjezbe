using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSLuzba.Models
{
    public class DodajPredmetVM
    {
        public int predmetStudentID { get; set; }

        public int ocjenaID { get; set; }
        public int studentID { get; set; }
        public int predmetID { get; set; }

        public DateTime Datum { get; set; }

        public List<SelectListItem> ocjene { get; set; }
        public List<SelectListItem> studenti { get; set; }
        public List<SelectListItem> predmeti { get; set; }

    }
}
