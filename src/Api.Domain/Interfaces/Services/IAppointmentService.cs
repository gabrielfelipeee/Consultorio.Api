using Api.Domain.Dtos.Appointment;

namespace Api.Domain.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentDto>> GetAllAsync();
        Task<AppointmentDto> GetByIdAsync(int id);
        Task<AppointmentCreateResultDto> PostAsync(AppointmentCreateDto appointment);
        Task<AppointmentUpdateResultDto> PutAsync(int id, AppointmentUpdateDto appointment);
        Task<bool> DeleteAsync(int id);
    }
}
