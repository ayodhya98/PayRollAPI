using PayRoll.Core.Common;
using PayRoll.Core.Enums;

namespace PayRoll.Core.Model
{
    public class EmployeeAllowance : IAuditedEntity
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public string Month { get; set; }
        public decimal Allowance { get; set; }
        public AllowanceStatus Status { get; set; } 
        public DateTime? CreatedAt { get; set; }
        public long? CreatedById { get; set; }
        public DateTime Date { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? UpdatedById { get; set; }
        public DateTime? DeletedAt { get; set; }
        public long? DeletedById { get; set; }

    }
}
