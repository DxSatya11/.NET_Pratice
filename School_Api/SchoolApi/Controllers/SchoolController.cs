using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_Application.Commands.SchoolCommand;
using School_Application.Query;
using School_Application.Query.SchoolQuery;
using School_Application.Response.SchoolResponse;
using School_Domain.IRepository;
using School_Domain.Model;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Schools> _schoolRepository;

        public SchoolController(IMediator mediator, IRepository<Schools> schoolRepository)
        {
            _mediator = mediator;
            _schoolRepository = schoolRepository;
        }


        [HttpGet]
        public async Task<List<Schools>> GetSchllolist()
        {
            var schoollist = await _mediator.Send(new GetSchoolQuery());
            return schoollist.ToList();
        }


        [HttpPost]
        public async Task<ActionResult<AddSchoolResponse>> AddSchool([FromBody] SchoolCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("SchoolById")]
        public async Task<ActionResult<IEnumerable<Schools>>> SchoolById(int id)
        {
            try
            {
                var school = await _mediator.Send(new GetSchoolByIdQuery { id = id });
                if (school == null)
                {
                    return NotFound("School record not found for the given id.");
                }
                return Ok(school);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchool(int id, UpdateSchoolCommand command)
        {
            command.id = id;
            var school = await _mediator.Send(new GetSchoolByIdQuery { id = id });
            if (school == null)
            {
                return NotFound("Please enter a valid School id");
            }
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSchool([FromBody] List<int> ids)
        {
            try
            {
                foreach (int id in ids)
                {
                    var school = await _schoolRepository.GetByIdAsync(id);
                    if (school != null)
                    {
                        await _schoolRepository.DeleteAsync(school);
                    }
                }
                foreach (int id in ids)
                {
                    var Deleted = await _schoolRepository.GetByIdAsync(id);
                   
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
