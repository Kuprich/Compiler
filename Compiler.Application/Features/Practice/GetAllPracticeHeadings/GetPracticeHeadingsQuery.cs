using ErrorOr;
using MediatR;

namespace Compiler.Application.Features.Practice.GetAllPracticeHeadings;

public class GetPracticeHeadingsQuery : IRequest<ErrorOr<PracticeHeadingsDto>>
{ }
