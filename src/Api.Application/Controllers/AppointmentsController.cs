using Api.Domain.Dtos.Appointment;
using Api.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    public class AppointmentsController : BaseController
    {
        private readonly IAppointmentService _appointment;
        public AppointmentsController(IAppointmentService appointment)
        {
            _appointment = appointment;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAppointments()
        {
            var result = await _appointment.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAppointmentById(int id)
        {
            var result = await _appointment.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> PostAppointment(AppointmentCreateDto appointment)
        {
            var result = await _appointment.PostAsync(appointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = result.Id }, result);
        }

        [HttpPut("id")]
        public async Task<ActionResult> PutAppointment(int id, AppointmentUpdateDto appointment)
        {
            var result = await _appointment.PutAsync(id, appointment);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            await _appointment.DeleteAsync(id);
            return NoContent();
        }
    }
}
