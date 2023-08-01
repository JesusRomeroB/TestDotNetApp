using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Queries
{
    public class GetCityById : IRequest<City>
    {
        public int Id { get; set; }
    }
}
