﻿using MediatR;
using Microsoft.VisualBasic;
using System.Windows.Input;

namespace Compiler.Application.Compiler.RunTests;

public class RunTestCommand : IRequest<CompiledInformationDto>
{
    public string? MainClassText { get; set; }
    public string? TestClassText { get; set; }
}