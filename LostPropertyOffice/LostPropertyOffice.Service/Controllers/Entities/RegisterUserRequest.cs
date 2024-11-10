using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LostPropertyOffice.Service.Controllers.Entities
{
    public class RegisterUserRequest : IValidatableObject
    {
        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        
        public string EmailAddress { get; set; }

        public string Position { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            if (Role != "Visitor" && Role != "Employee")
            {
                errors.Add(new ValidationResult("Invalid role. Role must be either 'Visitor' or 'Employee'."));
            }

            if (!Regex.IsMatch(Login, @"^[a-zA-Z0-9]+$"))
            {
                errors.Add(new ValidationResult("Login contains invalid symbols. Only alphanumeric characters are allowed."));
            }
            
            // Что-то ещё

            return errors;
        }
    }
}