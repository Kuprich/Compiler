using Compiler.API.Compiler;
using Compiler.Application.Compiler.RunTests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Compiler.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompilerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompilerController(IMediator mediator) => _mediator = mediator;


    [HttpPost("[action]")]
    public async Task<IActionResult> RunAllTests([FromBody] RunAllTestsRequest request)
    {
        var command = new RunAllTestsCommand()
        {
            MainClassText = request.MainClassText,
            TestClassText = request.TestClassText
        };

        var compiledInformationDto = await _mediator.Send(command);

        return Ok(compiledInformationDto);
    }
}
