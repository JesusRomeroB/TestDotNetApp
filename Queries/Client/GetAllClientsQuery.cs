using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Queries
{
    public class GetAllClientsQuery : IRequest<IEnumerable<Client>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
