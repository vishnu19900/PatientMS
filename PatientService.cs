using Microsoft.EntityFrameworkCore;
using PatientMS.Data;
using PatientMS.Models;

namespace PatientMS
{
    public class PatientService : IPatient
    {
        PatentMSDBContext database;
        public PatientService(PatentMSDBContext _database) 
        {
            database = _database;
        }
        public async Task<Patient> Add(Patient Patient)
        {
            Patient.CreatedDate = System.DateTime.Now;
            Patient.UpdatedDate = System.DateTime.Now;
            var pat = database.Add(Patient);
            await database.SaveChangesAsync();
            return Patient;
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {

            var pat =   await database.Patients.FirstOrDefaultAsync(x => x.Id == Id);    
            if (pat != null)
            {
                database.Patients.Remove(pat);  
            }
            return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Patient>> GetAll()
        {
            var getPat = await database.Patients.ToListAsync();
            return getPat;
        }

        public  async Task<Patient> GetById(int id)
        {
            var getpat = await database.Patients.FirstOrDefaultAsync(x => x.Id == id);
            return getpat;

        }

        public async Task<Patient> Update(Patient Patient)
        {
            var getpat = await database.Patients.FirstOrDefaultAsync(x => x.Id == Patient.Id);
            if (getpat != null)
            {
                getpat.UpdatedDate = System.DateTime.Now;
                database.Patients.Attach(getpat);
                database.Entry(getpat).State = EntityState.Modified;
                database.SaveChanges();
            }
            return Patient;
        }
    }
}
