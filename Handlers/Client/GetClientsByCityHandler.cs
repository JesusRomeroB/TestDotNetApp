using MediatR;
using Microsoft.EntityFrameworkCore;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;
using TestDotNetApp.Queries;

namespace TestDotNetApp.Handlers
{
    public class GetClientsByCityHandler : IRequestHandler<GetClientsByCityQuery, IEnumerable<Client>>
    {
        private readonly DBContext _dbContext;
        public GetClientsByCityHandler(DBContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public async Task<IEnumerable<Client>> Handle(GetClientsByCityQuery request, CancellationToken cancellationToken)
        {
            try
            {
                int recordsToSkip = (request.PageIndex - 1) * request.PageSize;

                return await _dbContext.client.Where(c => c.IdCity == request.IdCity)
                                            .OrderBy(c => c.Id)
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
