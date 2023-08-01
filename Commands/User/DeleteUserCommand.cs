using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Commands
{
    public class DeleteUserCommand : IRequest<User>
    {
        public int Id { get; set; }
    }
}
