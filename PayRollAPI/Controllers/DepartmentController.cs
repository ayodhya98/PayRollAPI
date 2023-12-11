using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PayRoll.Application.DTOs;
using PayRoll.Application.Repository.IRepository;
using PayRoll.Core.Model;

namespace PayRollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseAPIController
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<DepartmentDTO>>> GetAllDepartments()
        {
            List<Department> departmentList = await _departmentRepository.GetAllAsync();
            List<DepartmentDTO> departmentDTOList = _mapper.Map<List<DepartmentDTO>>(departmentList);
            return Ok(departmentDTOList);
        }

        [HttpGet("{id:long}", Name = "GetDepartment")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<DepartmentDTO>> GetDepartmentById(long id)
        {

            if (id == 0)
            {

                return BadRequest();
            }
            var department = await _departmentRepository.GetAsync(u => u.Id == id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DepartmentDTO>(department));
        }


        [HttpPost]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DepartmentDTO>> CreateDepartment([FromBody] CreateDepartmentDTO createDTO)
        {

            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }

            Department model = _mapper.Map<Department>(createDTO);
            await _departmentRepository.CreateAsync(model);
            return CreatedAtRoute("GetDepartment", new { id = model.Id }, model);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id:long}", Name = "DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var department = await _departmentRepository.GetAsync(u => u.Id == id);

            if (department == null)
            {
                return NotFound();
            }

            await _departmentRepository.RemoveAsync(department);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut("{id:long}", Name = "EditDepartment")]
        public async Task<IActionResult> EditDepartment(long id, [FromBody] DepartmentDTO updateDTO)
        {
            if (updateDTO == null || id != updateDTO.Id)
            {
                return BadRequest();
            }

            Department model = _mapper.Map<Department>(updateDTO);

            await _departmentRepository.EditAsync(model);
            return NoContent();
        }

    }
}
