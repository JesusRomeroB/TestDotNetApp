using MediatR;
using Microsoft.EntityFrameworkCore;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;
using TestDotNetApp.Queries;

namespace TestDotNetApp.Handlers
{
    public class GetCityByIdHandler : IRequestHandler<GetCityByIdQuery, City>
    {
        private readonly DBContext _dbContext;

        public GetCityByIdHandler(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<City> Handle(GetCityByIdQuery request, CancellationToken cancellationToken) { 
            return await _dbContext.city.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
