using PayRoll.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace PayRoll.Core.Model
{
    public class Department : BaseEntity, IAuditedEntity
    {
        [Required]
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? UpdatedById { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? DeletedById { get; set; }

        //Relationship
        public ICollection<Employee> Employees { get; set; }

    }
}
