using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Application.Commands.DepartmentCommand;
using School_Application.Commands.SchoolCommand;
using School_Application.Query.DepartmentQuery;
using School_Application.Query.SchoolQuery;
using School_Application.Response.DepartmentResponse;
using School_Application.Response.SchoolResponse;
using School_Domain.IRepository;
using School_Domain.Model;
using System.ComponentModel;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IMediator _mediator;
        public DepartmentController(IMediator mediator, IRepository<Department> departmentRepository)
        {
            _mediator = mediator;
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<List<Department>> GetDepartment()
        {
            var departmentlist = await _mediator.Send(new GetDepartmentQuery());
            return departmentlist.ToList();
        }


        [HttpPost]
        public async Task<ActionResult<AddDepartmentResponse>> AddDepartment([FromBody] CreateDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("DepartmentById")]
        public async Task<ActionResult<IEnumerable<Department>>> DepartmentById(int id)
        {
            try
            {
                var dipartment = await _mediator.Send(new GetDepartmentByIdQuery { id = id });
                if (dipartment == null)
                {
                    return NotFound("Department record not found for the given id.");
                }
                return Ok(dipartment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentCommand command)
        {
            command.Id = id;
            var dipartment = await _mediator.Send(new GetDepartmentByIdQuery { id = id });

            if (dipartment == null)
            {
                return NotFound("Department not exist please enter a valid Department id");
            }
            return Ok(await _mediator.Send(command));
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment([FromBody] List<int> ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var company = await _departmentRepository.GetByIdAsync(id);
                    if (company != null)
                    {
                        await _departmentRepository.DeleteAsync(company);
                    }
                }
                foreach (int id in ids)
                {
                    var Deleted = await _departmentRepository.GetByIdAsync(id);
                 

                }

                return Ok(ids);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());

            }
        }
    }
}
