using ClinicManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClinicDbContext clinicDb;

        public HomeController(ClinicDbContext clinicDb)
        {
            this.clinicDb = clinicDb;
        }
        public IActionResult Index()
        {
            var doctors = clinicDb.Doctors.Count();
            var patients = clinicDb.Patients.Count();
            var appointments = clinicDb.Appointments.Count();

            ViewBag.Doctors = doctors;
            ViewBag.Patients = patients;
            ViewBag.Appointments = appointments;

            return View();
        }
    }
}
