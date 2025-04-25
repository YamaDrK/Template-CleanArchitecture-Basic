using System.ComponentModel.DataAnnotations;

namespace Application.Commons.Exceptions
{
    public class ValidationFailureException : Exception
    {
        public IList<string> Errors { get; }

        public ValidationFailureException() : base("One or more validation failures have occurred.") 
            => Errors = [];

        public ValidationFailureException(List<ValidationResult> errors) : this()
        {
            foreach (var error in errors.Select(e => e.ErrorMessage ?? string.Empty))
            {
                Errors.Add(error);
            }
        }
    }
}
