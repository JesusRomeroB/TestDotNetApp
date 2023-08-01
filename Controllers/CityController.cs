using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestDotNetApp.Queries;
using TestDotNetApp.Models;

namespace TestDotNetApp.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator) => _mediator = mediator;

        // GET: api/<CityController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var cities = await _mediator.Send(new GetAllCities());
                return cities is not null ? Ok(cities) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public async Task <ActionResult> GetCityById(int id)
        {
            try
            {
                City city = await _mediator.Send(new GetCityById() { Id = id});
                return city is not null ? Ok(city) : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST api/<CityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
