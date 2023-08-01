using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
    }
}
