using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestDotNetApp.Commands;
using TestDotNetApp.Domain.DTO;
using TestDotNetApp.Domain.Models;
using TestDotNetApp.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestDotNetApp.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator) => _mediator = mediator;

        // GET: api/client
        [HttpGet]
        public async Task<ActionResult> Get([FromBody] Pagination pagination)
        {
            try
            {
                var cities = await _mediator.Send(new GetAllClientsQuery()
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

        // GET api/client/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetClientById(int id)
        {
            try
            {
                Client response = await _mediator.Send(new GetClientByIdQuery() { Id = id });
                return response is not null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST api/client
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Client request)
        {
            try
            {
                var command = new CreateClientCommand()
                {
                    Cod = request.Cod,
                    Name = request.Name,
                    IdCity = request.IdCity,
                };

                var response = await _mediator.Send(command);
                return response is not null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/client/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Client request)
        {
            try
            {
                var command = new UpdateClientCommand()
                {
                    Id = id,
                    Cod = request.Cod,
                    Name = request.Name,
                    IdCity = request.IdCity,
                };

                var response = await _mediator.Send(command);
                return response is not null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE api/client/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteClientCommand()
                {
                    Id = id
                };

                var response = await _mediator.Send(command);
                return response is not null ? Ok() : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        // GET: api/client/city/1
        [HttpGet("city/{id}")]
        public async Task<ActionResult> GetClientsByCity(int id, [FromBody] Pagination pagination)
        {
            try
            {
                var cities = await _mediator.Send(new GetClientsByCityQuery()
                {
                    IdCity = id,
                    PageIndex = pagination.PageIndex,
                    PageSize = pagination.PageSize
                });
                return cities is not null ? Ok(cities) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
