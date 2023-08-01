using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestDotNetApp.Commands;
using TestDotNetApp.Domain.DTO;
using TestDotNetApp.Domain.Models;
using TestDotNetApp.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestDotNetApp.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) => _mediator = mediator;

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult> Get([FromBody] Pagination pagination)
        {
            try
            {
                var cities = await _mediator.Send(new GetAllUsersQuery()
                {
                    PageIndex = pagination.PageIndex,
                    PageSize = pagination.PageSize,
                });
                return cities is not null ? Ok(cities) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            try
            {
                User response = await _mediator.Send(new GetUserByIdQuery() { Id = id });
                return response is not null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST api/user
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User request)
        {
            try
            {
                var command = new CreateUserCommand()
                {
                    Name = request.Name,
                    Pass = request.Pass,
                    Email = request.Email,
                    Photo = request.Photo
                };

                var response = await _mediator.Send(command);
                return response is not null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User request)
        {
            try
            {
                var command = new UpdateUserCommand()
                {
                    Id = id,
                    Name = request.Name,
                    Pass = request.Pass,
                    Email = request.Email,
                    Photo = request.Photo
                };

                var response = await _mediator.Send(command);
                return response is not null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteUserCommand()
                {
                    Id = id
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
