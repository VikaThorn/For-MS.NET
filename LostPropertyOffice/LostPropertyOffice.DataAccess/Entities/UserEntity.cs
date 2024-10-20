using System.ComponentModel.DataAnnotations.Schema;

namespace LostPropertyOffice.DataAccess.Entities
{
    [Table("users")]
    public class UserEntity : BaseEntity
    {
        public string Role { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
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