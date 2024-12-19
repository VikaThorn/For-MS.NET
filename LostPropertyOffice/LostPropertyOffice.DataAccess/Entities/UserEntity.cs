using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LostPropertyOffice.DataAccess.Entities
{
    [Table("users")]
    public class UserEntity : IdentityUser
    {
        public string Role { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public Guid ExternalId { get; set; } 
        public DateTime CreationTime { get; set; }  
        public DateTime? ModificationTime { get; set; }
    }

    public class VisitorEntity : UserEntity
    {
        public string EmailAddress { get; set; }
    }

    public class EmployeeEntity : UserEntity
    {
        public string Position { get; set; }
    }
}