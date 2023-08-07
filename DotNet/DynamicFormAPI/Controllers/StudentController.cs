using DynamicFormAPI.Features.Studnet.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DynamicFormAPI.Features.Studnet.Commands.StudentCommand;

namespace DynamicFormAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IMediator _Mediator;
        protected IMediator Mediator => _Mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        [Route("AddStudentDetails")]
        public async Task<IActionResult> AddStudentDetails(StudentCommand model)
        {
            return Ok(await Mediator.Send(model));
        }

    }
}
