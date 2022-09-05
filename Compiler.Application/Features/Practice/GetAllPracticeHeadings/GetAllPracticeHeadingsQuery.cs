using MediatR;

namespace Compiler.Application.Features.Practice.GetAllPracticeHeadings;

public class GetAllPracticeHeadingsQuery : IRequest<List<PracticeHeadingDto>>
{ }
