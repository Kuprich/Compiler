using Compiler.Application.Practice.GetAllPractices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Compiler.API.Controllers
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
            var query = new GetAllPracticeHeadingsQuery();

            var allPracticeHeadings = await _mediator.Send(query);

            return Ok(allPracticeHeadings);
        }
    }
}
