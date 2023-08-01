using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Commands
{
    public class DeleteCityCommand : IRequest<City>
    {
        public int Id { get; set; }
    }
}
