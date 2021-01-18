using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSLuzba.Models
{
    public class DodajStudentaVM
    {
        public int studentID { get; set; }
        public  string Ime { get; set; }
        public  string Prezime { get; set; }
        public string Br_Ind  { get; set; }
        public int fakultetID { get; set; }
        public int opstinaID { get; set; }

        public List<SelectListItem> fakulteti   { get; set; }
        public List<SelectListItem> opstine   { get; set; }
    }
}
