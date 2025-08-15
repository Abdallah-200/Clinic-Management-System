using ClinicManagementSystem.Models;

namespace ClinicManagementSystem.BL.Interface
{
    public interface IAppointmentRpository
    {
        IEnumerable<Appointment> GetAll();
        Appointment GetById(int id);
        void Add(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(int id);
    }
}
