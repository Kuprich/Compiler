using Compiler.Application.Practice.GetAllPracticeHeadings;
using MediatR;

namespace Compiler.Application.Practice.GetAllPractices;

public class GetAllPracticeHeadingsQuery : IRequest<List<PracticeHeadingDto>>
{ }
