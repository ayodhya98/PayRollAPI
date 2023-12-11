using PayRoll.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Application.DTOs
{
    public class AllowanceDTO
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public string Month { get; set; }
        public decimal Allowance { get; set; }
        public AllowanceStatus Status { get; set; }
    }
}
