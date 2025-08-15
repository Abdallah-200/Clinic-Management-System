using ClinicManagementSystem.BL.Interface;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository ipatient;

        public PatientController(IPatientRepository ipatient)
        {
            this.ipatient = ipatient;
        }
        public IActionResult Index()
        {
            var patients = ipatient.GetAll();
            return View(patients);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            { 
                ipatient.Add(patient);
                return RedirectToAction("Index");
            }
            return View(patient);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var patient = ipatient.GetById(id);
            return View(patient);
        }
        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                ipatient.Update(patient);
                return RedirectToAction("Index");
            }
            return View(patient);
        }
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var patients = ipatient.GetById(id);
            return View(patients);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePatient(int id )
        {
            ipatient.Delete(id);

            return RedirectToAction("Index");
     
        }

    }
}
