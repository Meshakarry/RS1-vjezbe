using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSLuzba.Models
{
    public class EditOcjenaVM
    {
        public int studentPredmetID { get; set; }
        public string ImeStudenta { get; set; }
        public string NazivPredmeta { get; set; }
    
        public int ocjenaID{ get; set; }

        public List<SelectListItem> ocjene { get; set; }

    }
}
