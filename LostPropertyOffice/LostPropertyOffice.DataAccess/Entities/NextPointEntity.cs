using System.ComponentModel.DataAnnotations.Schema;

namespace LostPropertyOffice.DataAccess.Entities
{
    [Table("next_points")]
    public class NextPointEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}