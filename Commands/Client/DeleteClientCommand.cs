using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Commands
{
    public class DeleteClientCommand : IRequest<Client>
    {
        public int Id { get; set; }
    }
}
