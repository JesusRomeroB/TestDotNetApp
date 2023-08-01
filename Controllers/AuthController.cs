using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDotNetApp.Commands;
using TestDotNetApp.Domain.DTO;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Controllers
{
    [Authorize]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator) => _mediator = mediator;
        // POST api/login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> LogIn([FromBody] UserLogin request)
        {
            try
            {
                var command = new LogInCommand()
                {
                    Password = request.Password,
                    Email = request.Email,
                };

                var response = await _mediator.Send(command);
                return response is not null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST api/signup
        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<ActionResult> SignUp([FromBody] User request)
        {
            try
            {
                var command = new SignUpCommand()
                {
                    Password = request.Pass,
                    Email = request.Email,
                    Name = request.Name,
                    Photo = request.Photo,
                };

                var response = await _mediator.Send(command);
                return response is not null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
