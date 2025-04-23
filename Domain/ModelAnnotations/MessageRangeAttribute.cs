using System.ComponentModel.DataAnnotations;

namespace Domain.ModelAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MessageRangeAttribute(double Minimum, double Maximum) : ValidationAttribute("{0} must be between {1} and {2}")
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is double number && (number < Minimum || number > Maximum))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, Minimum, Maximum);
        }
    }
}
