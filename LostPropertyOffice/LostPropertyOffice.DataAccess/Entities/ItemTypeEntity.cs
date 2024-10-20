using System.ComponentModel.DataAnnotations.Schema;

namespace LostPropertyOffice.DataAccess.Entities
{
    [Table("item_types")]
    public class ItemTypeEntity : BaseEntity
    {
        public string TypeName { get; set; }
        public int NextPointId { get; set; }
        public NextPointEntity NextPoint { get; set; }
        public int StoragePeriod { get; set; }
        public decimal StorageCost { get; set; }
        public virtual ICollection<LostItemEntity> LostItems { get; set; }
    }
}