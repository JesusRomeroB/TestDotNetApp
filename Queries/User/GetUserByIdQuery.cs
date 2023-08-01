using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
