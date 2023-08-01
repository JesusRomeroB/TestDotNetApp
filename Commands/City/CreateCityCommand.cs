using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Commands
{
    public class CreateCityCommand : IRequest<City>
    {
        public int Cod { get; set; }
        public string Name { get; set; } 
    }
}
