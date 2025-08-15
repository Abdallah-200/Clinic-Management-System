using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        public int Age { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        public string? Gender { get; set; }

        [MaxLength(500)]
        public string? MedicalHistory { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
