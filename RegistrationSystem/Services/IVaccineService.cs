using RegistrationSystem.Models;

namespace RegistrationSystem.Services
{
    public interface IVaccineService
    {
        Task<IEnumerable<Vaccine>> GetAllAsync();
        Task<Vaccine> GetByIdAsync(int id);
        Task<Vaccine> AddAsync(Vaccine vaccine);
        Task<Vaccine> UpdateAsync(Vaccine vaccine);
        Task<bool> DeleteAsync(int id);
    }
}
