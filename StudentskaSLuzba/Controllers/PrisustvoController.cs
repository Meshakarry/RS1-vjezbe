using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Podaci;
using Podaci.EntityModels;
using StudentskaSLuzba.Models;

namespace StudentskaSLuzba.Controllers
{
    public class PrisustvoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
            mojDbContext dbContext = new mojDbContext();
        public IActionResult PrikazPrisustva(int studentID)
        {
            var m = new prisustvoPrikazVM();
            Student s = dbContext.students.Find(studentID);
            m.NazivStudenta = s.Ime + " " + s.Prezime;

            m.prisustva = dbContext.prisustvoNaNastavis.Where(x => x.studentID == studentID).Select(
                s => new prisustvoPrikazVM.Zapis
                {
                    prisustvoID=s.ID,

                    Predmet = s.predmet.Naziv,
                    datum = s.datum_prisustva,
                    IsPrisutan=s.IsPrisutan,

                    komentar=s.komentar

                }
                ).ToList();




            return View(m);
        }
        public IActionResult EditPrisustvo(int prisustvoID)
        {
            EditPrisustvoVM pr = dbContext.prisustvoNaNastavis.Where(x => x.ID == prisustvoID).
               Select(x => new EditPrisustvoVM
               {
                   prisustvoID = x.ID,
                   NazivPredmeta=x.predmet.Naziv,
                   ImeStudenta=x.student.Ime + " " + x.student.Prezime,
                   IsPrisutan=x.IsPrisutan,
                   komentar=x.komentar
               }).Single();

            return View(pr);
        }

        public IActionResult snimi(EditPrisustvoVM x)
        {
           PrisustvoNaNastavi redovan= dbContext.prisustvoNaNastavis.Find(x.prisustvoID);

            redovan.IsPrisutan = x.IsPrisutan;
            redovan.komentar = x.komentar;
            dbContext.SaveChanges();
            return Redirect("/Student/Prikaz");
        }
    }
}
