using System.ComponentModel.DataAnnotations;

namespace Job_Candidate_Hub_API.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class UrlLinkValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var url = value as string;

            if (string.IsNullOrEmpty(url) || (url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || url.StartsWith("https://", StringComparison.OrdinalIgnoreCase) || url.StartsWith("ftp://", StringComparison.OrdinalIgnoreCase))) 
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? $"The {validationContext.DisplayName} field is not a valid fully - qualified http, https, or ftp URL.");
        }
    }
}
