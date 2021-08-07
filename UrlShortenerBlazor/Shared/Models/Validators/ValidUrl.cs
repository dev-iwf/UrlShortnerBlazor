using System;
using System.ComponentModel.DataAnnotations;

namespace UrlShortenerBlazor.Shared.Models.Validators
{
    public class ValidUrl : ValidationAttribute
    {
        public string GetErrorMessage() => "Not a valid URL";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var fullUrl = (string)value;

            if (!Uri.IsWellFormedUriString(fullUrl, UriKind.Absolute))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
