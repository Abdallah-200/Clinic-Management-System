using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Specialization { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        public string? ImageUrl { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
    }
}
