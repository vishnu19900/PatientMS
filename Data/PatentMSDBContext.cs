using Microsoft.EntityFrameworkCore;
using PatientMS.Models;

namespace PatientMS.Data
{
    public class PatentMSDBContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("datasource=ISHLTP150\\SQL2017; uid=sa; pwd=12345;  ");
            optionsBuilder.UseSqlServer("datasource=ISHLTP150\\SQL2017;");
        }
    }

}