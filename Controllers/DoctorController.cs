using ClinicManagementSystem.BL.Interface;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementSystem.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository idotor;

        public DoctorController(IDoctorRepository idotor)
        {
            this.idotor = idotor;
        }
        public IActionResult Index()
        {
            var data = idotor.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create() 
        { 
           return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor) 
        {
            if (ModelState.IsValid) 
            {
                idotor.Add(doctor);
                return RedirectToAction("Index");
            }
            return View(doctor);
        }
        [HttpGet]
        public IActionResult Edit(int id )
        {
            var data = idotor.GetById(id);
            return View(data);  
        }
        [HttpPost]
        public IActionResult Edit(Doctor doctor)
        {
            if (ModelState.IsValid) 
            {
                idotor.Update(doctor);
                return RedirectToAction("Index");
            }
            return View(doctor);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = idotor.GetById(id);
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteDoctor(int id)
        {
            idotor.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
