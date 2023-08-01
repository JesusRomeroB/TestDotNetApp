using MediatR;
using TestDotNetApp.Commands;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Handlers
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, City>
    {
        private readonly DBContext _dbContext;
        public CreateCityCommandHandler(DBContext dbContext) {  _dbContext = dbContext; }
        public async Task<City> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var city = new City
            {
                Cod = request.Cod,
                Name= request.Name,
            };

            _dbContext.city.Add(city);
            await _dbContext.SaveChangesAsync();
            return city;
        }
    }
}
