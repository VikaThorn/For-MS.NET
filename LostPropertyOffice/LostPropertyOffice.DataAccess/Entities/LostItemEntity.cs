using System.ComponentModel.DataAnnotations.Schema;

namespace LostPropertyOffice.DataAccess.Entities
{
    [Table("lost_items")]
    public class LostItemEntity : BaseEntity
    {
        public string Name { get; set; }
        public int ItemTypeId { get; set; }
        public ItemTypeEntity ItemType { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public DateTime FoundDate { get; set; }
        public string FoundTime { get; set; }
        public string FoundLocation { get; set; }
        public string Description { get; set; }
        public string ReturnStatus { get; set; }
    }
}