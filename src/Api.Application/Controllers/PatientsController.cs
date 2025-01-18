using Api.Domain.Dtos.Patient;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    public class PatientsController : BaseController
    {
        private readonly IPatientService _patientService;
        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPatients()
        {
            var result = await _patientService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPatientById(int id)
        {
            var result = await _patientService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> PostPatient(PatientCreateDto patient)
        {
            var result = await _patientService.PostAsync(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutPatient(int id, PatientUpdateDto patient)
        {
            var result = await _patientService.PutAsync(id, patient);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            await _patientService.DeleteAsync(id);
            return NoContent();
        }
    }
}
