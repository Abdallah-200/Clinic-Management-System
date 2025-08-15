using ClinicManagementSystem.Data;
using ClinicManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClinicManagementSystem.API
{
    [ApiController]
    [Route("api/patient")]
    public class PatientApiController : Controller
    {
        private readonly ClinicDbContext clinicDb;

        public PatientApiController(ClinicDbContext clinicDb)
        {
            this.clinicDb = clinicDb;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await clinicDb.Patients.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await clinicDb.Patients.FirstOrDefaultAsync(p => p.Id == id);

            if (data == null)
            {
                return NotFound("patient not found ");
            }
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Patient patient)
        {
            clinicDb.Patients.Add(patient);
            await clinicDb.SaveChangesAsync();
            return Ok("patient saved");
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id,[FromBody] Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest("Invalid ID");
            }
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState); 
            }

            var existing = await clinicDb.Patients.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            if (existing == null) return NotFound("Patient not found");

            clinicDb.Patients.Update(patient);
            await clinicDb.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) 
        {
            var data = await clinicDb.Patients.FindAsync(id);
            if (data == null)
            {
                return NotFound("patient not found");
            }
            clinicDb.Remove(data);
            await clinicDb.SaveChangesAsync();
            return Ok();
        }
    } 
}
