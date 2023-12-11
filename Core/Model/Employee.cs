using PayRoll.Core.Common;
using PayRoll.Core.Enums;

namespace PayRoll.Core.Model
{
    public class Employee : BaseEntity, IAuditedEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public Gender Gender { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long? CreatedById { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? UpdatedById { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? DeletedById { get; set; }

        //Relationship
        public long DepartmentId { get; set; }
        public Department Departments { get; set; }
    }
}
