using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Queries
{
    public class GetAllCitiesQuery : IRequest<IEnumerable<City>>
    {
    }
}
