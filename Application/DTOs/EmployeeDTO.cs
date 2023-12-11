using PayRoll.Core.Common;
using PayRoll.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Application.DTOs
{
    public class EmployeeDTO : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNo { get; set; }
        public string EmailAddress { get; set; }
        public Gender Gender { get; set; }
    }
}
