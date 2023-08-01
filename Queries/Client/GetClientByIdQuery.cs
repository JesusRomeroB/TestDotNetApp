using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Queries
{
    public class GetClientByIdQuery : IRequest<Client>
    {
        public int Id { get; set; }
    }
}
