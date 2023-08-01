using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Commands
{
    public class SignUpCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
    }
}
