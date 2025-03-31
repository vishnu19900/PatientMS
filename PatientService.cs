using Microsoft.EntityFrameworkCore;
using PatientMS.Data;
using PatientMS.Models;
using System.Collections.Generic;

namespace PatientMS
{
    public class PatientService : IPatientService
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

            var pat =   await database.Patient.FirstOrDefaultAsync(x => x.Id == Id);    
            if (pat != null)
            {
                database.Patient.Remove(pat);  
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
            try
            {
                var getPat = await database.Patient.ToListAsync();
                return getPat;
            }
            catch (Exception ex)
            {
                return new List<Patient>();
            }
        }

        public  async Task<Patient> GetById(int id)
        {
            var getpat = await database.Patient.FirstOrDefaultAsync(x => x.Id == id);
            return getpat;

        }

        public async Task<Patient> Update(Patient Patient)
        {
            var getpat = await database.Patient.FirstOrDefaultAsync(x => x.Id == Patient.Id);
            if (getpat != null)
            {
                getpat.UpdatedDate = System.DateTime.Now;
                database.Patient.Attach(getpat);
                database.Entry(getpat).State = EntityState.Modified;
                database.SaveChanges();
            }
            return Patient;
        }
    }
}
