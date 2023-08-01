using MediatR;
using TestDotNetApp.Commands;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Handlers
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, City>
    {
        private readonly DBContext _dbContext;
        public UpdateCityCommandHandler(DBContext dbContext) { _dbContext = dbContext; }
        public async Task<City> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            try { 
                var city = _dbContext.city.FirstOrDefault(p => p.Id == request.Id);

                if (city is null)
                    return default;

                city.Cod = request.Cod;
                city.Name = request.Name;

                await _dbContext.SaveChangesAsync();
                return city;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
