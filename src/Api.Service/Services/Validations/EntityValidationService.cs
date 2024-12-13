using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Service.Services.Validations
{
    public class EntityValidationService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public EntityValidationService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task ValidateIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("O ID deve ser maior que 0.");
        }

        public async Task ValidateEntityExistsAsync(int id)
        {
            var entity = await _repository.SelectByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"A entidade não existe.");
        }
    }
}
