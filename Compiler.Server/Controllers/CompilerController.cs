using Compiler.Application.Features.Compiler.RunAllTests;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Compiler.Server.Controllers;

public class CompilerController : ApiController
{
    private readonly IMediator _mediator;

    public CompilerController(IMediator mediator) => _mediator = mediator;


    [HttpPost("[action]")]
    public async Task<IActionResult> RunAllTests([FromBody] RunAllTestsCommand command)
    {
        var compiledInformationResult = await _mediator.Send(command);

        return compiledInformationResult.Match(
               compiledInformation => Ok(new CompiledInformationDto() { Errors = compiledInformationResult.Value.Errors, TestResult = compiledInformationResult.Value.TestResult }),
               errors => Problem(errors));
    }
}
