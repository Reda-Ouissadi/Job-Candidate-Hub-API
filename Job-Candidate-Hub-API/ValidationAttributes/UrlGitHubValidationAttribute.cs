using System.ComponentModel.DataAnnotations;

namespace Job_Candidate_Hub_API.ValidationAttributes
{
    public class UrlGitHubValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var url = value as string;

            string GitHub = "https://github.com/";

            if (string.IsNullOrEmpty(url) || (url.StartsWith(GitHub, StringComparison.OrdinalIgnoreCase) && url.Length > GitHub.Length))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? $"The GitHub Url is not a valid fully");
        }
    }
}
