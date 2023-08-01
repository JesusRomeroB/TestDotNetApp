using MediatR;
using TestDotNetApp.Commands;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Handlers
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, City>
    {
        private readonly DBContext _dbContext;

        public DeleteCityCommandHandler(DBContext dbContext) { _dbContext = dbContext; }
        public async Task<City> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = _dbContext.city.FirstOrDefault(p => p.Id == request.Id);

            if (city is null)
                return default;

            _dbContext.Remove(city);
            await _dbContext.SaveChangesAsync();
            return city;
        }
    }
}
