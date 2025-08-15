using ClinicManagementSystem.BL.Interface;
using ClinicManagementSystem.Data;
using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.BL.Reposatory
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ClinicDbContext context;

        public PatientRepository(ClinicDbContext context)
        {
            this.context = context;
        }
        public void Add(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();

        }

        public void Delete(int id)
        {
            var data = GetById(id);
            if (data != null)
            {
                context.Patients.Remove(data);
            }
            context.SaveChanges();
        }

        public IEnumerable<Patient> GetAll()
        {
            var data = context.Patients;
            return data;
        }

        public Patient GetById(int id)
        {
            var data = context.Patients.Find(id);
            return data;
        }

        public void Update(Patient patient)
        {
            context.Patients.Update(patient);
            context.SaveChanges();

        }
    }
}
