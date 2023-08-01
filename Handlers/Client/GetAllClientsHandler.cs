using MediatR;
using Microsoft.EntityFrameworkCore;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;
using TestDotNetApp.Queries;

namespace TestDotNetApp.Handlers
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<Client>>
    {
        private readonly DBContext _dbContext;

        public GetAllClientsHandler(DBContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<Client>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.client.ToListAsync();
        }
    }
}
