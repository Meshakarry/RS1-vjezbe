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
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Prikaz(string q = null)
        {
            mojDbContext mojDb = new mojDbContext();

            List<studentPrikazVM.Row> students = mojDb.students
            .Where(x => (x.Ime + " " + x.Prezime).StartsWith(q) || (x.Prezime + " " + x.Ime).StartsWith(q) || q == null)
                .Select(a => new studentPrikazVM.Row
                {
                    studentID = a.studentID,
                    Ime = a.Ime,
                    Prezime = a.Prezime,
                    Br_Ind = a.Br_Ind,
                    Fakultet = a.Fakultet.Naziv,
                    Opstina = a.Opstina.Naziv

                }).ToList();
            studentPrikazVM s = new studentPrikazVM();
            s.studenti = students;
            s.query = q;

            return View(s);
        }

        public IActionResult Obrisi(int studentID)
        {
            mojDbContext mojDb = new mojDbContext();

            Student s = mojDb.students.Find(studentID);

            mojDb.Remove(s);
            mojDb.SaveChanges();

            return Redirect("/Student/Prikaz");
        }

        public IActionResult Edit(int studentID)
        {
            mojDbContext dbContext = new mojDbContext();

            List<SelectListItem> fakulteti = dbContext.fakultets.Select(a => new SelectListItem { Value = a.ID.ToString(), Text = a.Naziv }).ToList();
            List<SelectListItem> opstine = dbContext.opstinas.Select(a => new SelectListItem { Value = a.ID.ToString(), Text = a.Naziv }).ToList();

            DodajStudentaVM s = studentID == 0 ? s = new DodajStudentaVM() : dbContext.students.Where(x => x.studentID == studentID).
                Select(a => new DodajStudentaVM
                {
                    studentID = a.studentID,
                    Ime = a.Ime,
                    Prezime = a.Prezime,
                    Br_Ind = a.Br_Ind,
                    fakultetID = a.fakultetID,
                    opstinaID = a.opstinaID

                }).Single();

            s.fakulteti = fakulteti;
            s.opstine = opstine;


            return View(s);
        }

        public IActionResult Snimi(DodajStudentaVM s)
        {
            mojDbContext dbContext = new mojDbContext();
            Student st;

            if (s.studentID == 0)
            {
                st = new Student();
                dbContext.Add(st);

            }
            else
            {
                st = dbContext.students.Find(s.studentID);
            }
            st.Ime = s.Ime;
            st.Prezime = s.Prezime;
            st.Br_Ind = s.Br_Ind;
            st.fakultetID = s.fakultetID;
            st.opstinaID = s.opstinaID;


            dbContext.SaveChanges();
            return Redirect("/Student/Prikaz");
        }


        




        public IActionResult PrikazPrisustva(int studentID)
        {
            mojDbContext dbContext = new mojDbContext();
            var m = new prisustvoPrikazVM();
            Student s = dbContext.students.Find(studentID);
            m.NazivStudenta = s.Ime + " " + s.Prezime;

            m.prisustva = dbContext.prisustvoNaNastavis.Where(x => x.studentID == studentID).Select(
                s => new prisustvoPrikazVM.Zapis
                {
                    
                    Predmet = s.predmet.Naziv,
                    datum = s.datum_prisustva
                }
                ).ToList();




            return View(m);
        }
    }
    



}
