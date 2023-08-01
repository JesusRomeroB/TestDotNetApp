using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Queries
{
    public class GetAllClientsQuery : IRequest<IEnumerable<Client>>
    {
    }
}
