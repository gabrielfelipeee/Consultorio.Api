using FluentValidation;

namespace Api.CrossCutting.Helpers
{
    public class ValidationErrorFormatter
    {
        public static object FormatValidationErrors(ValidationException ex, string errorType)
        {
            var errors = ex.Errors
                .GroupBy(e => e.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToList()
                );

            // Convertendo os erros para uma string JSON
            return new
            {
                errorType,
                errors
            };
        }
    }
}
