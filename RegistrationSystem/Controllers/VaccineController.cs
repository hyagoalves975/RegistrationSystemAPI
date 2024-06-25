using Microsoft.AspNetCore.Mvc;
using RegistrationSystem.Models;
using RegistrationSystem.Services;

namespace RegistrationSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly IVaccineService _service;

        public VaccineController(IVaccineService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vaccine>>> GetAll()
        {
            var vaccines = await _service.GetAllAsync();
            return Ok(vaccines);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vaccine>> GetById(int id)
        {
            var vaccine = await _service.GetByIdAsync(id);
            if (vaccine == null)
            {
                return NotFound();
            }
            return Ok(vaccine);
        }

        [HttpPost]
        public async Task<ActionResult<Vaccine>> Add(Vaccine vaccine)
        {
            var createdVaccine = await _service.AddAsync(vaccine);
            return CreatedAtAction(nameof(GetById), new { id = createdVaccine.Id }, createdVaccine);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Vaccine>> Update(int id, Vaccine vaccine)
        {
            if (id != vaccine.Id)
            {
                return BadRequest();
            }

            var updatedVaccine = await _service.UpdateAsync(vaccine);
            return Ok(updatedVaccine);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success)
            {
                return BadRequest();
            }
            return Ok(success);
        }
    }
}
