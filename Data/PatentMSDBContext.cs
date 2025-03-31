using Microsoft.EntityFrameworkCore;
using PatientMS.Models;

namespace PatientMS.Data
{
    public class PatentMSDBContext : DbContext
    {
        public PatentMSDBContext(DbContextOptions options) : base(options) { }
        public DbSet<Patient> Patient { get; set; }
    }

}