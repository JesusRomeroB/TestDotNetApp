using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Commands
{
    public class CreateClientCommand : IRequest<Client>
    {
        public int Cod { get; set; }
        public string Name { get; set; }
        public int IdCity { get; set; }
    }
}
