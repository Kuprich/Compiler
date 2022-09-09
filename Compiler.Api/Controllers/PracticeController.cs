using Compiler.Application.Features.Practice.GetAllPracticeHeadings;
using Compiler.Application.Features.Practice.GetPracticeCard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Compiler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PracticeController(IMediator mediator) => _mediator = mediator;


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPracticeHeadings()
        {
            var query = new GetPracticeHeadingsQuery();

            var allPracticeHeadings = await _mediator.Send(query);

            return Ok(allPracticeHeadings);
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetPractice([FromRoute] Guid practiceCardId)
        {
            var query = new GetPracticeCardQuery() { Id = practiceCardId };

            try
            {
                var practiceCard = await _mediator.Send(query);
                return Ok(practiceCard);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
