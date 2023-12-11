using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Application.DTOs
{
    public class CreateDepartmentDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
