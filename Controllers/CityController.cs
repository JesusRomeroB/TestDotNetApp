using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestDotNetApp.Queries;
using TestDotNetApp.Commands;
using System.Text.Json;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator) => _mediator = mediator;

        // GET: api/city
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var cities = await _mediator.Send(new GetAllCitiesQuery());
                return cities is not null ? Ok(cities) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/city/5
        [HttpGet("{id}")]
        public async Task <ActionResult> GetCityById(int id)
        {
            try
            {
                City city = await _mediator.Send(new GetCityByIdQuery() { Id = id});
                return city is not null ? Ok(city) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST api/city
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] City request)
        {
            try
            {
                var command = new CreateCityCommand()
                {
                    Cod = request.Cod,
                    Name = request.Name
                };

                var response = await _mediator.Send(command);
                return response is not null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/city/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] City request)
        {
            try
            {
                var command = new UpdateCityCommand()
                {
                    Id = id,
                    Cod = request.Cod,
                    Name = request.Name
                };

                var response = await _mediator.Send(command);
                return response is not null ? Ok(response) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // DELETE api/city/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var command = new DeleteCityCommand()
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
    }
}
