using MediatR;
using TestDotNetApp.Models;

namespace TestDotNetApp.Queries
{
    public class GetAllCities : IRequest<IEnumerable<City>>
    {
    }
}
