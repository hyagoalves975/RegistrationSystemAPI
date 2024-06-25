using Microsoft.EntityFrameworkCore;
using RegistrationSystem.Data;
using RegistrationSystem.Models;

namespace RegistrationSystem.Repositories
{
    public class VaccinationStationRepository : IVaccinationStationRepository
    {
        private readonly SIDbContext _context;

        public VaccinationStationRepository(SIDbContext sIDbContext)
        {
            _context = sIDbContext;
        }

        public async Task<IEnumerable<VaccinationStation>> GetAllAsync()
        {
            return await _context.VaccinationStation.Include(p => p.Vaccines).ToListAsync();
        }

        public async Task<VaccinationStation> GetByIdAsync(int id)
        {
            return await _context.VaccinationStation.Include(p => p.Vaccines)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<VaccinationStation> AddAsync(VaccinationStation posto)
        {
            _context.VaccinationStation.Add(posto);
            await _context.SaveChangesAsync();
            return posto;
        }

        public async Task<VaccinationStation> UpdateAsync(VaccinationStation posto)
        {
            _context.Entry(posto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return posto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var posto = await _context.VaccinationStation.Include(p => p.Vaccines)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (posto == null || posto.Vaccines.Count > 0)
            {
                return false;
            }

            _context.VaccinationStation.Remove(posto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
