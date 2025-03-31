using PatientMS.Models;

namespace PatientMS
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAll();
        Task<Patient> GetById(int id);
        Task<bool> Delete(int Id);
        Task<Patient> Add(Patient Patient);
        Task<Patient> Update(Patient Patient);
    }
}
