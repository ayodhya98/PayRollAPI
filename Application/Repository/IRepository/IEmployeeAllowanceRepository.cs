using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Application.Repository.IRepository
{
    public interface IEmployeeAllowanceRepository
    {
        void SetAllowance(EmployeeAllowance allowance);
        void ChangeAllowance(EmployeeAllowance allowance);
        void UpdateAllowance(EmployeeAllowance allowance);
        List<EmployeeAllowance> GetAllowanceByMonth(string month);
        List<EmployeeAllowance> GetAllowanceByDate(DateTime startDate, DateTime endDate);
        List<EmployeeAllowance> GetAllowancesByEmployeeId(long employeeId);
        List<EmployeeAllowance> GetAllowancesByDepartmentId(long departmentId);
        
    }
}
