using System.ComponentModel.DataAnnotations;

namespace RegistrationSystem.Models
{
    public class VaccinationStation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Vaccine> Vaccines { get; set; }
    }
}
