using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
    }
}
