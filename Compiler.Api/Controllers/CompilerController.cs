using Compiler.Api.Contracts.Compiler;
using Compiler.Application.Features.Compiler.RunAllTests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Compiler.Api.Controllers;


public class CompilerController : ApiController
{
    private readonly IMediator _mediator;
    public CompilerController(IMediator mediator) => _mediator = mediator;

    [HttpPost("[action]")]
    public async Task<IActionResult> RunAllTests([FromBody] RunAllTestsRequest request)
    {
        //TODO: возможно использовать маппер.
        var command = new RunAllTestsCommand(
            request.MainClassText,
            request.TestClassText);

        var result = await _mediator.Send(command);

        return Ok(result);

    }
}
