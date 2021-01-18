using System;
using Microsoft.EntityFrameworkCore;
using Podaci.EntityModels;

namespace Podaci
{
    public class mojDbContext:DbContext
    {
        public DbSet<Student> students{ get; set; }
        public DbSet<Fakultet> fakultets{ get; set; }
        public DbSet<Opstina> opstinas{ get; set; }
        public DbSet<Predmet> predmets{ get; set; }
        public DbSet<Ocjena> ocjenas{ get; set; }
        public DbSet<PredmetOcjena> predmetOcjenas{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer(@" Server=DESKTOP-NFLA9OU\MSSQLSERVER_OLAP;

                                            Database=Studentska;

                                            Trusted_Connection=true;

                                            MultipleActiveResultSets=true");

        }

    }
}
