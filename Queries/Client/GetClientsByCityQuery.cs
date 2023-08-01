using MediatR;
using TestDotNetApp.Domain.Models;
using TestDotNetApp.Domain.DTO;

namespace TestDotNetApp.Queries
{
    public class GetClientsByCityQuery : Pagination, IRequest<IEnumerable<Client>>
    {
        public int? IdCity { get; set; }
    }
}
