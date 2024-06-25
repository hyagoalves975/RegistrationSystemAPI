using System.ComponentModel.DataAnnotations;

namespace RegistrationSystem.Models
{
    public class Vaccine
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(50)]
        public string Batch { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime ExpirationDate { get; set; }

        public int VaccinationStationId { get; set; }
        public VaccinationStation VaccinationStation { get; set; }
    }
}
