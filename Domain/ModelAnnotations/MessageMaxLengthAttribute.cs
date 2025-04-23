using System.ComponentModel.DataAnnotations;

namespace Domain.ModelAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class MessageMaxLengthAttribute(int MaxLength) : ValidationAttribute("{0} can't exceed {1} characters")
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string str && str.Length > MaxLength)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, MaxLength);
        }
    }
}
