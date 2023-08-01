using MediatR;
using TestDotNetApp.Models;

namespace TestDotNetApp.Queries
{
    public class GetCityById : IRequest<City>
    {
        public int Id { get; set; }
    }
}
