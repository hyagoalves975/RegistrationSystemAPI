using Microsoft.AspNetCore.Mvc;
using RegistrationSystem.Models;
using RegistrationSystem.Services;

namespace RegistrationSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VaccinationStationController : ControllerBase
    {
        private readonly IVaccinationStationService _service;

        public VaccinationStationController(IVaccinationStationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccinationStation>>> GetAll()
        {
            var vaccinationStation = await _service.GetAllAsync();
            return Ok(vaccinationStation);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VaccinationStation>> GetById(int id)
        {
            var vaccinationStation = await _service.GetByIdAsync(id);
            if (vaccinationStation == null)
            {
                return NotFound();
            }
            return Ok(vaccinationStation);
        }

        [HttpPost]
        public async Task<ActionResult<VaccinationStation>> Add(VaccinationStation vaccinationStation)
        {
            var createdPosto = await _service.AddAsync(vaccinationStation);
            return CreatedAtAction(nameof(GetById), new { id = createdPosto.Id }, createdPosto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VaccinationStation>> Update(int id, VaccinationStation vaccinationStation)
        {
            if (id != vaccinationStation.Id)
            {
                return BadRequest();
            }

            var updatedVaccinationStation = await _service.UpdateAsync(vaccinationStation);
            return Ok(updatedVaccinationStation);
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