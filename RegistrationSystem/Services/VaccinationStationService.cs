using RegistrationSystem.Models;
using RegistrationSystem.Repositories;

namespace RegistrationSystem.Services
{
    public class VaccinationStationService : IVaccinationStationService
    {
        private readonly IVaccinationStationRepository _repository;

        public VaccinationStationService(IVaccinationStationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<VaccinationStation>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<VaccinationStation> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<VaccinationStation> AddAsync(VaccinationStation vaccinationStation)
        {
            return await _repository.AddAsync(vaccinationStation);
        }

        public async Task<VaccinationStation> UpdateAsync(VaccinationStation vaccinationStation)
        {
            return await _repository.UpdateAsync(vaccinationStation);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}