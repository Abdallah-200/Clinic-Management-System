using ClinicManagementSystem.BL.Interface;
using ClinicManagementSystem.Data;
using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.BL.Reposatory
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicDbContext clinicDb;

        public DoctorRepository(ClinicDbContext clinicDb)
        {
            this.clinicDb = clinicDb;
        }
        public void Add(Doctor doctor)
        {
            clinicDb.Doctors.Add(doctor);
            clinicDb.SaveChanges();

            
        }

        public void Delete(int id)
        {
            var doctor= GetById(id);
            if (doctor != null)
            {
                clinicDb.Remove(doctor);
            }
            clinicDb.SaveChanges();
        }

        public IEnumerable<Doctor> GetAll()
        {
            var doctors = clinicDb.Doctors.ToList();

            return doctors;
        }

        public Doctor GetById(int id)
        {
            var doctor = clinicDb.Doctors.Find(id);
            return doctor;
        }

        public void Update(Doctor doctor)
        {
            clinicDb.Doctors.Update(doctor);
            clinicDb.SaveChanges();
        }
    }
}
