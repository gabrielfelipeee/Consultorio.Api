using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPatients()
        {
            try
            {
                var result = await _patientService.GetAllAsync();

                if (result == null || !result.Any())
                {
                    return Ok(new List<object>());
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Ocorreu um erro interno." });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPatientById(int id)
        {
            try
            {
                var result = await _patientService.GetByIdAsync(id);

                if (result == null)
                {
                    return NotFound(new { error = "Paciente não encontrado." });
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Ocorreu um erro interno." });
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostPatient(PatientEntity patient)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var result = await _patientService.PostAsync(patient);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Ocorreu um erro interno." });
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutPatient(PatientEntity patient)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var result = await _patientService.PutAsync(patient);
                if (result == null)
                {
                    return NotFound(new { error = "Paciente não encontrado." });
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Ocorreu um erro interno." });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            try
            {
                var result = await _patientService.DeleteAsync(id);
                if (!result)
                {
                    return NotFound(new { error = "Paciente não encontrado." });
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Ocorreu um erro interno." });
            }
        }
    }
}
