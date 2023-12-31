﻿using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Application.Repository.IRepository
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        Task<Employee> EditAsync(Employee entity);
    }
}
