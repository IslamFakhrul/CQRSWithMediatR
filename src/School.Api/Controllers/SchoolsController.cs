using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Api.Commands.CreateSchool;
using School.Api.Commands.DeleteSchool;
using School.Api.Commands.UpdateSchool;
using School.Api.Queries.GetSchoolDetail;
using School.Api.Queries.GetSchoolsList;
using System.Threading.Tasks;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SchoolsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetSchools")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetSchoolsListQueryResponse>> GetAsync()

        {
            return Ok(await _mediator.Send(new GetSchoolsListQuery()));
        }

        [HttpGet("{refId:int}", Name = "GetSchoolByRefId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetSchoolDetailQueryResponse>> GetByRefIdAsync(int refId)
        {
            return Ok(await _mediator.Send(new GetSchoolDetailQuery { RefId = refId }));
        }

        [HttpPost(Name = "AddSchool")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> CreateAsync([FromBody]CreateSchoolCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut(Name = "UpdateSchool")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync([FromBody]UpdateSchoolCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{refId}", Name = "DeleteSchool")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int refId)
        {
            await _mediator.Send(new DeleteSchoolCommand { RefId = refId });

            return Accepted(refId);
        }
    }
}
