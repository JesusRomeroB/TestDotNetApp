using MediatR;
using Microsoft.EntityFrameworkCore;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;
using TestDotNetApp.Queries;

namespace TestDotNetApp.Handlers
{
    public class GetAllCitiesHandler : IRequestHandler<GetAllCities, IEnumerable<City>>
    {
        private readonly DBContext _dbContext;

        public GetAllCitiesHandler(DBContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<City>> Handle(GetAllCities request, CancellationToken cancellationToken)
        {
            return await _dbContext.city.ToListAsync();
        }
    }
}
