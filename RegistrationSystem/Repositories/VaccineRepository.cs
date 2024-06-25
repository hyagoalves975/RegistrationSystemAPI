using Microsoft.EntityFrameworkCore;
using RegistrationSystem.Data;
using RegistrationSystem.Models;

namespace RegistrationSystem.Repositories
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly SIDbContext _context;

        public VaccineRepository(SIDbContext sIDbContext)
        {
            _context = sIDbContext;
        }

        public async Task<IEnumerable<Vaccine>> GetAllAsync()
        {
            return await _context.Vaccine.Include(v => v.VaccinationStation).ToListAsync();
        }

        public async Task<Vaccine> GetByIdAsync(int id)
        {
            return await _context.Vaccine.Include(v => v.VaccinationStation)
            .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Vaccine> AddAsync(Vaccine vacina)
        {
            _context.Vaccine.Add(vacina);
            await _context.SaveChangesAsync();
            return vacina;
        }

        public async Task<Vaccine> UpdateAsync(Vaccine vaccine)
        {
            _context.Entry(vaccine).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return vaccine;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var vaccine = await _context.Vaccine.FindAsync(id);
            if (vaccine == null)
            {
                return false;
            }

            _context.Vaccine.Remove(vaccine);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
