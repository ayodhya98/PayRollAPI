using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayRoll.Application.DTOs;
using PayRoll.Application.Repository;
using PayRoll.Application.Repository.IRepository;
using PayRoll.Core.Enums;
using PayRoll.Core.Model;

namespace PayRollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAllowanceController : BaseAPIController
    {
        private readonly IEmployeeAllowanceRepository _allowanceRepository;
        public EmployeeAllowanceController(IEmployeeAllowanceRepository allowanceRepository) 
        {
            _allowanceRepository = allowanceRepository;
        }

        [HttpPost]
        public IActionResult SetEmployeeAllowance(EmployeeAllowance allowance)
        {
            _allowanceRepository.SetAllowance(allowance);
            return Ok(allowance);
        }
        [HttpPost]



        [HttpPut]
        public IActionResult ChangeEmployeeAllowance(EmployeeAllowance allowance)
        {
            _allowanceRepository.ChangeAllowance(allowance);
            return Ok(allowance);
        }

        [HttpGet]
        [Route("getbymonth/{month}")]
        public IActionResult GetEmployeeAllowancesByMonth(string month)
        {
            var allowances = _allowanceRepository.GetAllowanceByMonth(month);
            return Ok(allowances);
        }
        [HttpGet]
        [Route("getbydaterange")]
        public IActionResult GetEmployeeAllowancesByDateRange(DateTime startDate, DateTime endDate)
        {
            var allowances = _allowanceRepository.GetAllowanceByDate(startDate, endDate);
            return Ok(allowances);
        }

        [HttpGet]
        [Route("getbyemployeeid/{employeeId}")]
        public IActionResult GetEmployeeAllowancesByEmployeeId(int employeeId)
        {
            var allowances = _allowanceRepository.GetAllowancesByEmployeeId(employeeId);
            return Ok(allowances);
        }

        [HttpGet]
        [Route("getbydepartmentid/{departmentId}")]
        public IActionResult GetEmployeeAllowancesByDepartmentId(int departmentId)
        {
            var allowances = _allowanceRepository.GetAllowancesByDepartmentId(departmentId);
            return Ok(allowances);
        }


    }
}
