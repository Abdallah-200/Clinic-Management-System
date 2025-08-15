using ClinicManagementSystem.Data;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.API
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorApiController : Controller
    {
        private readonly ClinicDbContext clinicDb;

        public DoctorApiController(ClinicDbContext clinicDb)
        {
            this.clinicDb = clinicDb;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await clinicDb.Doctors.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await clinicDb.Doctors.FirstOrDefaultAsync(p => p.Id == id);

            if (data == null)
            {
                return NotFound("Doctor not found ");
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Doctor doctor)
        {
            clinicDb.Doctors.Add(doctor);
            await clinicDb.SaveChangesAsync();
            return Ok("Doctor saved");
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, [FromBody] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest("Invalid ID");
            }
            clinicDb.Doctors.Update(doctor);
            await clinicDb.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await clinicDb.Doctors.FindAsync(id);
            if (data == null)
            {
                return NotFound("doctor not found");
            }
            clinicDb.Remove(data);
            await clinicDb.SaveChangesAsync();
            return Ok();
        }
        
    }
}
