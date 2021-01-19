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

        //public IActionResult Edit(int predmetStudentID)
        //{
        //    mojDbContext dbContext = new mojDbContext();

        //    List<SelectListItem> ocjenee = dbContext.ocjenas.Select(a => new SelectListItem { Value = a.ID.ToString(), Text = a.ocjena.ToString() }).ToList();
        //    List<SelectListItem> studentii = dbContext.students.Select(a => new SelectListItem { Value = a.studentID.ToString(), Text = a.Ime }).ToList();
        //    List<SelectListItem> predmeti = dbContext.predmets.Select(a => new SelectListItem { Value = a.predmetID.ToString(), Text = a.Naziv }).ToList();

        //    DodajPredmetVM p = predmetStudentID == 0 ? new DodajPredmetVM() :
        //       dbContext.predmetOcjenas.Where(x => x.ID == predmetStudentID)
        //       .Select(p => new DodajPredmetVM
        //       {
        //           predmetStudentID=p.ID,
        //           ocjenaID=p.ocjenaID,
        //           studentID=p.studentID,
        //           predmetID=p.predmetID,
        //           Datum=p.datum_polaganja
                   
        //       }).Single();

        //    p.ocjene = ocjenee;
        //    p.studenti = studentii;
        //    p.predmeti = predmeti;
        //    return View(p);
        //}

        //public IActionResult Snimi(DodajPredmetVM s)
        //{
        //    mojDbContext dbContext = new mojDbContext();
        //    PredmetOcjena st;

        //    if (s.predmetStudentID == 0)
        //    {
        //        st = new PredmetOcjena();
        //        dbContext.Add(st);

        //    }
        //    else
        //    {
        //        st = dbContext.predmetOcjenas.Find(s.predmetStudentID);
        //    }
        //    st.predmetID = s.predmetID;
        //    st.ocjenaID = s.ocjenaID;
        //    st.studentID = s.studentID;
        //    st.datum_polaganja = s.Datum;


        //    dbContext.SaveChanges();
        //    return Redirect("/Student/Prikaz");
        //}
        public IActionResult Detalji(int studentID)
        {
            mojDbContext dbContext = new mojDbContext();

            var polozeni = dbContext.predmetOcjenas.Where(x => x.studentID == studentID).
                Select(p => new StudentPredmetPrikaz
                {
                    studentPredmetID = p.ID,
                    NazivPredmeta = p.predmet.Naziv,
                    Ocjena = p.ocjena.ocjena,
                    Datum = p.datum_polaganja
                }).ToList();

            return View(polozeni);
        }

        public IActionResult ObrisiOcjenu(int studentPredmetID)
        {
            mojDbContext mojDb = new mojDbContext();
            PredmetOcjena obrisi = mojDb.predmetOcjenas.Find(studentPredmetID);

            mojDb.Remove(obrisi);
            mojDb.SaveChanges();

            return Redirect("/Student/Prikaz");
        }
        public IActionResult Edit(int studentPredmetID)
        {
            mojDbContext dbContext = new mojDbContext();

            List<SelectListItem> ocjene = dbContext.ocjenas.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.ocjena.ToString() }).ToList();
            EditOcjenaVM editOcjena = dbContext.predmetOcjenas.Where(x => x.ID == studentPredmetID).
                Select(o => new EditOcjenaVM
                {
                    studentPredmetID=o.ID,
                    NazivPredmeta = o.predmet.Naziv,
                    ImeStudenta=o.student.Ime + " " + o.student.Prezime,
                    ocjenaID=o.ocjenaID,
                    
                }).Single();
            editOcjena.ocjene = ocjene;
            return View(editOcjena);
        }
        public IActionResult snimi(EditOcjenaVM x)
        {
            mojDbContext dbContext = new mojDbContext();

            PredmetOcjena ocjenaa = dbContext.predmetOcjenas.Find(x.studentPredmetID);

            ocjenaa.ocjenaID = x.ocjenaID;
            dbContext.SaveChanges();


            return Redirect("/Student/Prikaz");


        }
    }
}
