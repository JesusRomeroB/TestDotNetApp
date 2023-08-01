using MediatR;
using Microsoft.EntityFrameworkCore;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;
using TestDotNetApp.Queries;

namespace TestDotNetApp.Handlers
{
    public class GetAllCitiesHandler : IRequestHandler<GetAllCitiesQuery, IEnumerable<City>>
    {
        private readonly DBContext _dbContext;

        public GetAllCitiesHandler(DBContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<City>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                int recordsToSkip = (request.PageIndex - 1) * request.PageSize;

                return await _dbContext.city.OrderBy(c => c.Id) 
                                            .Skip(recordsToSkip)
                                            .Take(request.PageSize)
                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
