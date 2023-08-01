using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Queries
{
    public class GetCityByIdQuery : IRequest<City>
    {
        public int Id { get; set; }
    }
}
