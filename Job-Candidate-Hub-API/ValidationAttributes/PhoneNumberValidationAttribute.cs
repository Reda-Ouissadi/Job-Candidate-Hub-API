using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Job_Candidate_Hub_API.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class PhoneNumberValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var phoneNumber = value as string;
            var phoneNumberPattern = @"^\+?[1-9]\d{1,14}$";

            if (string.IsNullOrEmpty(phoneNumber) || Regex.IsMatch(phoneNumber, phoneNumberPattern))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? "The PhoneNumber field is not a valid phone number.");
        }
    }
}