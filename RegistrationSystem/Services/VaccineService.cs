using RegistrationSystem.Models;
using RegistrationSystem.Repositories;

namespace RegistrationSystem.Services
{
    public class VaccineService : IVaccineService
    {
        private readonly IVaccineRepository _repository;

        public VaccineService(IVaccineRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Vaccine>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Vaccine> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Vaccine> AddAsync(Vaccine vaccine)
        {
            return await _repository.AddAsync(vaccine);
        }

        public async Task<Vaccine> UpdateAsync(Vaccine vaccine)
        {
            return await _repository.UpdateAsync(vaccine);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
