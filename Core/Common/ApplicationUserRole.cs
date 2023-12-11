using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Common
{
    public class ApplicationUserRole : IdentityRole<int>
    {
        public ApplicationUserRole() : base()
        {
        }
        public ApplicationUserRole(string roleName) : base(roleName)
        {
        }
    }
}
