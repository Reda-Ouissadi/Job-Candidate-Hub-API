using System.ComponentModel.DataAnnotations;

namespace Job_Candidate_Hub_API.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class UrlLinkedInValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var url = value as string;

            string LinkedIn = "https://www.linkedin.com/in/";

            if (string.IsNullOrEmpty(url) || (url.StartsWith(LinkedIn, StringComparison.OrdinalIgnoreCase) && url.Length > LinkedIn.Length))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? $"The Linkedin Url is not a valid.");
        }
    }
}
