using Compiler.API.Models;
using Compiler.Application.Compiler.RunTests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Compiler.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompilerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompilerController(IMediator mediator) => _mediator = mediator;


    [HttpPost("[action]")]
    public async Task<IActionResult> RunTests(RunTestCommand query)
    {
        //TODO: Потом убрать это заполнение данными 
        query.MainClassText = Constants.MainClassText;
        query.TestClassText = Constants.TestClassText;

        CompiledInformationDto compiledInformationDto = await _mediator.Send(query);

        return Ok(compiledInformationDto);
    }
}
