using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Compiler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController : ControllerBase
    {

    }
}