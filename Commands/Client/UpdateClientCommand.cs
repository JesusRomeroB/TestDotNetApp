using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Commands
{
    public class UpdateClientCommand : IRequest<Client>
    {
        public int Id { get; set; }
        public int Cod { get; set; }
        public string Name { get; set; }
        public int IdCity { get; set; }
    }
}
