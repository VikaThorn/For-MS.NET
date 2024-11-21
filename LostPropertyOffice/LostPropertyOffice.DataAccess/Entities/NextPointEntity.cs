using System.ComponentModel.DataAnnotations.Schema;

namespace LostPropertyOffice.DataAccess.Entities
{
    [Table("next_points")]
    public class NextPointEntity : BaseEntity // Эти сущности имелись в виду, что их не хватало?
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}