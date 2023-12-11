using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayRoll.Application.DTOs;
using PayRoll.Application.Repository;
using PayRoll.Application.Repository.IRepository;
using PayRoll.Core.Model;

namespace PayRollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseAPIController
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmployeeDTO>>> GetAllEmployees()
        {
            List<Employee> employeeList = await _employeeRepository.GetAllAsync();
            List<EmployeeDTO> employeeDTOList = _mapper.Map<List<EmployeeDTO>>(employeeList);
            return Ok(employeeDTOList);
        }

        [HttpGet("{id:long}", Name = "GetEmployee")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(long id)
        {

            if (id == 0)
            {

                return BadRequest();
            }
            var employee = await _employeeRepository.GetAsync(u => u.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EmployeeDTO>(employee));
        }


        [HttpPost]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DepartmentDTO>> CreateEmployee([FromBody] CreateEmployeeDTO createDTO)
        {

            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }

            Employee model = _mapper.Map<Employee>(createDTO);
            await _employeeRepository.CreateAsync(model);
            return CreatedAtRoute("GetEmployee", new { id = model.Id }, model);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id:long}", Name = "DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var employee = await _employeeRepository.GetAsync(u => u.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            await _employeeRepository.RemoveAsync(employee);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id:long}", Name = "EditEmployee")]
        public async Task<IActionResult> EditEmployee(long id, [FromBody] EmployeeDTO updateDTO)
        {
            if (updateDTO == null || id != updateDTO.Id)
            {
                return BadRequest();
            }

            Employee model = _mapper.Map<Employee>(updateDTO);

            await _employeeRepository.EditAsync(model);
            return NoContent();
        }


    }
}
