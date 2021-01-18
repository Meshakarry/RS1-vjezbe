using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Podaci;
using Podaci.EntityModels;
using StudentskaSLuzba.Models;

namespace StudentskaSLuzba.Controllers
{
    public class PredmetController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        //public IActionResult Prikaz()
        //{
        //    //mojDbContext dbContext = new mojDbContext();

        //    //List<predmetPrikazVM.Row> predmets = dbContext.predmets.
        //    //    Select(a => new predmetPrikazVM.Row
        //    //    {
        //    //        predmetID = a.predmetID,
        //    //        Naziv=a.Naziv,
        //    //        Ocjena=a.Ocjena.ocjena,
        //    //        Student=a.Student.Ime + " " + a.Student.Prezime

        //    //    }).ToList();

        //    //predmetPrikazVM pr = new predmetPrikazVM();
        //    //pr.predmeti = predmets;


        //    //return View(pr);
        //}
        //< td >< a href = "/Student/Obrisi?studentID=@s.studentID " style = "color:firebrick" > Obrisi</ a></ td >

        //             < td >< a href = "/Student/Edit?studentID=@s.studentID " style = "color:gold" > Edit</ a></ td >

        public IActionResult Obrisi(int predmetID)
        {
            mojDbContext dbContext = new mojDbContext();
            Predmet p = dbContext.predmets.Find(predmetID);
            dbContext.Remove(p);
            dbContext.SaveChanges();

            return Redirect("/Predmet/Prikaz");
        }

        public IActionResult Edit(int predmetStudentID)
        {
            mojDbContext dbContext = new mojDbContext();

            List<SelectListItem> ocjenee = dbContext.ocjenas.Select(a => new SelectListItem { Value = a.ID.ToString(), Text = a.ocjena.ToString() }).ToList();
            List<SelectListItem> studentii = dbContext.students.Select(a => new SelectListItem { Value = a.studentID.ToString(), Text = a.Ime }).ToList();
            List<SelectListItem> predmeti = dbContext.predmets.Select(a => new SelectListItem { Value = a.predmetID.ToString(), Text = a.Naziv }).ToList();

            DodajPredmetVM p = predmetStudentID == 0 ? new DodajPredmetVM() :
               dbContext.predmetOcjenas.Where(x => x.ID == predmetStudentID)
               .Select(p => new DodajPredmetVM
               {
                   predmetStudentID=p.ID,
                   ocjenaID=p.ocjenaID,
                   studentID=p.studentID,
                   predmetID=p.predmetID,
                   Datum=p.datum_polaganja
                   
               }).Single();

            p.ocjene = ocjenee;
            p.studenti = studentii;
            p.predmeti = predmeti;
            return View(p);
        }

        public IActionResult Snimi(DodajPredmetVM s)
        {
            mojDbContext dbContext = new mojDbContext();
            PredmetOcjena st;

            if (s.predmetStudentID == 0)
            {
                st = new PredmetOcjena();
                dbContext.Add(st);

            }
            else
            {
                st = dbContext.predmetOcjenas.Find(s.predmetStudentID);
            }
            st.predmetID = s.predmetID;
            st.ocjenaID = s.ocjenaID;
            st.studentID = s.studentID;
            st.datum_polaganja = s.Datum;


            dbContext.SaveChanges();
            return Redirect("/Student/Prikaz");
        }
    }
}
