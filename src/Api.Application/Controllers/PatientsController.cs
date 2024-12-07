using Api.CrossCutting.Helpers;
using Api.Domain.Dtos.Patient;
using Api.Domain.Interfaces.Services;
using FluentValidation;
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
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Ocorreu um erro interno." });
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostPatient(PatientCreateDto patient)
        {
            try
            {
                var result = await _patientService.PostAsync(patient);
                return CreatedAtAction(nameof(GetPatientById), new { id = result.Id }, result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ValidationErrorFormatter.FormatValidationErrors(ex, "Validation Error"));
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Ocorreu um erro interno." });
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutPatient(PatientUpdateDto patient)
        {
            try
            {
                var result = await _patientService.PutAsync(patient);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (ValidationException ex)
            {
                return BadRequest(ValidationErrorFormatter.FormatValidationErrors(ex, "Validation Error"));
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
                await _patientService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Ocorreu um erro interno." });
            }
        }
    }
}
