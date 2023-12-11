using Microsoft.AspNetCore.Mvc;
using PayRoll.Application.Repository.IRepository;
using PayRoll.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Application.Repository
{
    public class EmployeeAllowanceRepository : IEmployeeAllowanceRepository
    {
        private readonly List<EmployeeAllowance> _employeesAllowances;

        public EmployeeAllowanceRepository()
        {
            _employeesAllowances = new List<EmployeeAllowance>();
        }

        public void ChangeAllowance(EmployeeAllowance allowance)
        {
            var ExistAllowance = _employeesAllowances.FirstOrDefault(x=>x.EmployeeId == allowance.EmployeeId && x.Month == allowance.Month);
        }

        public void SetAllowance(EmployeeAllowance allowance)
        {
            _employeesAllowances.Add(allowance);
        }

            public void UpdateAllowance(EmployeeAllowance allowance)
            {
            var ExistAllowance = _employeesAllowances.FirstOrDefault(x => x.EmployeeId == allowance.EmployeeId && x.Month == allowance.Month);

                if ( ExistAllowance != null)
                {
                ExistAllowance.Allowance = allowance.Allowance;
                ExistAllowance.Status = allowance.Status;
                }
            }

            public EmployeeAllowance GetEmployeeAllowance(long employeeId, string month)
            {
                return _employeesAllowances.FirstOrDefault(x =>x.EmployeeId == employeeId && x.Month == month);
            }

            public List<EmployeeAllowance> GetAllowanceByMonth(string month)
            {
                return _employeesAllowances.Where(x => x.Month == month).ToList();
            }

            public List<EmployeeAllowance> GetAllowanceByDate(DateTime startDate, DateTime endDate)
            {
                return _employeesAllowances
                    .Where(x => x.Date >= startDate && x.Date <= endDate)
                    .ToList();
            }

            public List<EmployeeAllowance> GetAllowancesByEmployeeId(long employeeId)
            {
                return _employeesAllowances.Where(x => x.EmployeeId == employeeId).ToList();
            }

        public List<EmployeeAllowance> GetAllowancesByDepartmentId(long departmentId)
        {
            return _employeesAllowances.Where(x => x.DepartmentId == departmentId).ToList();
        }

    }
    }

