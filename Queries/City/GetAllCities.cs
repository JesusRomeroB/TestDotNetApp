using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Queries
{
    public class GetAllCities : IRequest<IEnumerable<City>>
    {
    }
}
