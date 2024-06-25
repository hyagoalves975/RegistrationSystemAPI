using RegistrationSystem.Models;

namespace RegistrationSystem.Services
{
    public interface IVaccinationStationService
    {
        Task<IEnumerable<VaccinationStation>> GetAllAsync();
        Task<VaccinationStation> GetByIdAsync(int id);
        Task<VaccinationStation> AddAsync(VaccinationStation vaccinationStation);
        Task<VaccinationStation> UpdateAsync(VaccinationStation vaccinationStation);
        Task<bool> DeleteAsync(int id);
    }
}
