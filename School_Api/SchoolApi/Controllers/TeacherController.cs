using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Application.Commands.StudentCommand;
using School_Application.Commands.TeacherCommand;
using School_Application.Query.StudentQuery;
using School_Application.Query.TeacherQuery;
using School_Application.Response.StudentResponse;
using School_Application.Response.TeacherResponse;
using School_Domain.IRepository;
using School_Domain.Model;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Teacher> _techerRepository;

        public TeacherController(IMediator mediator, IRepository<Teacher> techerRepository)
        {
            _mediator = mediator;
            _techerRepository = techerRepository;   
        }

        [HttpGet]
        public async Task<List<Teacher>> GetTeacher()
        {
            var teacherlist = await _mediator.Send(new GetTeacherQuery());
            return teacherlist.ToList();    
        }

        [HttpPost]
        public async Task<ActionResult<AddTeacherResponse>> AddTeacher([FromBody] CreateTeacherCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddTeacherResponse>>> TeacherById(int id)
        {
            try
            {
                var school = await _mediator.Send(new GetTeacherByIdQuery { id = id });
                if (school == null)
                {
                    return NotFound("Teacher record not found for the given id.");
                }
                return Ok(school);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, UpdateTeacherCommand command)
        {
            command.Id = id;
            var techer = await _mediator.Send(new GetTeacherByIdQuery { id = id });
            if(techer == null)
            {
                return NotFound("Please enter a valid Teacher id");
            }
            return Ok(await _mediator.Send(command));  
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteTeacher([FromBody] List<int> ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var teacher = await _techerRepository.GetByIdAsync(id);
                    if (teacher != null)
                    {
                        await _techerRepository.DeleteAsync(teacher);
                    }
                }
                foreach (int id in ids)
                {
                    var Deleted = await _techerRepository.GetByIdAsync(id);


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
