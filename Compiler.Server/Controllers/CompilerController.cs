﻿using Compiler.Application.Features.Compiler.RunAllTests;
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
    public async Task<IActionResult> RunAllTests([FromBody] RunAllTestsCommand command)
    {
        var compiledInformationDto = await _mediator.Send(command);

        return Ok(compiledInformationDto);
    }
}
