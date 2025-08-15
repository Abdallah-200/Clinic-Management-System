using ClinicManagementSystem.BL.Interface;
using ClinicManagementSystem.Data;
using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.BL.Reposatory
{
    public class AppointmentRpository : IAppointmentRpository
    {
        private readonly ClinicDbContext clinicDb;

        public AppointmentRpository(ClinicDbContext clinicDb)
        {
            this.clinicDb = clinicDb;
        }
        public void Add(Appointment appointment)
        {
            clinicDb.Appointments.Add(appointment);
            clinicDb.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = GetById(id);
            clinicDb.Remove(data);
            clinicDb.SaveChanges();
        }

        public IEnumerable<Appointment> GetAll()
        {
            var data = clinicDb.Appointments.ToList();
            return data;
        }

        public Appointment GetById(int id)
        {
            var data = clinicDb.Appointments.Find(id);
            return data;
        }

        public void Update(Appointment appointment)
        {
            clinicDb.Appointments.Update(appointment);
            clinicDb.SaveChanges();
        }
    }
}
