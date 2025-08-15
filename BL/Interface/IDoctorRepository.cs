using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.BL.Interface
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
        Doctor GetById(int id);
        void Add(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(int id);
    }
}
