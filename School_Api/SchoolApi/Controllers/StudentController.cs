using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using School_Application.Commands.SchoolCommand;
using School_Application.Commands.StudentCommand;
using School_Application.Query.SchoolQuery;
using School_Application.Query.StudentQuery;
using School_Application.Response.SchoolResponse;
using School_Application.Response.StudentResponse;
using School_Domain.IRepository;
using School_Domain.Model;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]
    [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")]
    public class StudentController : ControllerBase
    {
        public IMediator _mediator;
        private readonly IRepository<Student> _studentRepository;
        public StudentController(IMediator mediator, IRepository<Student> studentRepository)
        {
            _mediator = mediator;
            _studentRepository = studentRepository;
        }
       
        [HttpGet]
        public async Task<List<Student>> GetStudents()
        {
            var studnetlist = await _mediator.Send(new GetStudentQuery());
            return studnetlist.ToList();

        }


        [HttpPost]
        public async Task<ActionResult<AddStudentResponse>> AddStudent([FromBody] CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddStudentResponse>>> StudentById(int id)
        {
            try
            {
                var school = await _mediator.Send(new GetStudentByIdQuery { Id = id });
                if (school == null)
                {
                    return NotFound("Student record not found for the given id.");
                }
                return Ok(school);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentCommand command)
        {
            command.Id = id;
            var school = await _mediator.Send(new GetStudentByIdQuery { Id = id });
            if (school == null)
            {
                return NotFound("Please enter a valid student id");
            }
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudents([FromBody] List<int> ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var teacher = await _studentRepository.GetByIdAsync(id);
                    if (teacher != null)
                    {
                        await _studentRepository.DeleteAsync(teacher);
                    }
                }
                foreach (int id in ids)
                {
                    var Deleted = await _studentRepository.GetByIdAsync(id);


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


