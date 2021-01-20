using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskaSLuzba.Models
{
    public class EditPrisustvoVM
    {
        public int prisustvoID { get; set; }
        public string ImeStudenta { get; set; }
        public string NazivPredmeta { get; set; }
        public bool IsPrisutan { get; set; }
        public string komentar { get; set; }

    }
}
