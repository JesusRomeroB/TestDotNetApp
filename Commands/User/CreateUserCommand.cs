using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
    }
}
