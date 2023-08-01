using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Commands
{
    public class UpdateCityCommand : IRequest<City>
    {
        public int Id { get; set; }
        public int Cod { get; set; }
        public string Name { get; set; }
    }
}
