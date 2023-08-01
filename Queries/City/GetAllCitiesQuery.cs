using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Queries
{
    public class GetAllCitiesQuery : IRequest<IEnumerable<City>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
