using ClinicManagementSystem.Data;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.API
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentApiController : Controller
    {
        private readonly ClinicDbContext clinicDb;

        public AppointmentApiController(ClinicDbContext clinicDb)
        {
            this.clinicDb = clinicDb;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await clinicDb.Appointments.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await clinicDb.Appointments.FirstOrDefaultAsync(p => p.Id == id);

            if (data == null)
            {
                return NotFound("Appointment not found ");
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Appointment appointment)
        {
            clinicDb.Appointments.Add(appointment);
            await clinicDb.SaveChangesAsync();
            return Ok("Appointment saved");
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, [FromBody] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest("Invalid ID");
            }
            clinicDb.Appointments.Update(appointment);
            await clinicDb.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var data = await clinicDb.Appointments.FindAsync(id);
            if (data == null)
            {
                return NotFound("Appointment not found");
            }
            clinicDb.Remove(data);
            await clinicDb.SaveChangesAsync();
            return Ok();
        }
    }
}
