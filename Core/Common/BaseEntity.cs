using System.ComponentModel.DataAnnotations;

namespace PayRoll.Core.Common
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public long Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
