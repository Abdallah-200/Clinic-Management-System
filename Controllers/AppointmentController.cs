using ClinicManagementSystem.BL.Interface;
using ClinicManagementSystem.Data;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRpository iappointment;
        private readonly ClinicDbContext clinicDb;

        public AppointmentController(IAppointmentRpository iappointment ,ClinicDbContext clinicDb)
        {
            this.iappointment = iappointment;
            this.clinicDb = clinicDb;
        }
        public IActionResult Index()
        {
            var doctors = clinicDb.Doctors.ToList();
            var patients = clinicDb.Patients.ToList();

            ViewBag.Doctors = new SelectList(doctors, "Id", "Name");
            ViewBag.Patients = new SelectList(patients, "Id", "Name");

            var data = iappointment.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            var doctors = clinicDb.Doctors.ToList();
            var patients = clinicDb.Patients.ToList();

            ViewBag.Doctors = new SelectList(doctors, "Id", "Name");
            ViewBag.Patients = new SelectList(patients, "Id", "Name");

            return View();  
        }
        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            if (ModelState.IsValid) 
            {
                iappointment.Add(appointment);
                return RedirectToAction("Index");
            }

            ViewBag.Doctors = new SelectList(clinicDb.Doctors, "Id", "Name");
            ViewBag.Patients = new SelectList(clinicDb.Patients, "Id", "Name");

            return View(appointment);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var doctors = clinicDb.Doctors.ToList();
            var patients = clinicDb.Patients.ToList();

            ViewBag.Doctors = new SelectList(doctors, "Id", "Name");
            ViewBag.Patients = new SelectList(patients, "Id", "Name");


            var data = iappointment.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                iappointment.Update(appointment);
                return RedirectToAction("Index");
            }

            ViewBag.Doctors = new SelectList(clinicDb.Doctors, "Id", "Name");
            ViewBag.Patients = new SelectList(clinicDb.Patients, "Id", "Name");

            return View(appointment);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var doctors = clinicDb.Doctors.ToList();
            var patients = clinicDb.Patients.ToList();

            ViewBag.Doctors = new SelectList(doctors, "Id", "Name");
            ViewBag.Patients = new SelectList(patients, "Id", "Name");


            var data = iappointment.GetById(id);

            return View(data);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteAppoient(int id)
        {


                iappointment.Delete(id);
                return RedirectToAction("Index");
        }
    }
}
