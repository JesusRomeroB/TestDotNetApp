using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
