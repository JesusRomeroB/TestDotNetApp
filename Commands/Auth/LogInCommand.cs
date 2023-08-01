using MediatR;
using TestDotNetApp.Domain.DTO;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Commands
{
    public class LogInCommand : IRequest<Tokens>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
