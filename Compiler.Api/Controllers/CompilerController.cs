using Compiler.Api.Contracts.Compiler.RunAllTests;
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
        var command = new RunAllTestsCommand(
            request.MainClassText,
            request.TestClassText);

        var compiledInformationResult = await _mediator.Send(command);

        var t = compiledInformationResult.Value.TestResult
            .Select(result => new Contracts.Compiler.RunAllTests.TestResult(
                result.TestName, result.IsPassed, result.ErrorValue
            )).ToList();

        var success = new RunAllTestsResponse(compiledInformationResult.Value.Errors, t);

        return compiledInformationResult.Match(
               compiledInformation => Ok(success),
               errors => Problem(errors));
    }
}
