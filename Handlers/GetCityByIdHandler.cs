using MediatR;
using Microsoft.EntityFrameworkCore;
using TestDotNetApp.Data;
using TestDotNetApp.Models;
using TestDotNetApp.Queries;

namespace TestDotNetApp.Handlers
{
    public class GetCityByIdHandler : IRequestHandler<GetCityById, City>
    {
        private readonly DBContext _dbContext;

        public GetCityByIdHandler(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<City> Handle(GetCityById request, CancellationToken cancellationToken) { 
            return await _dbContext.city.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
