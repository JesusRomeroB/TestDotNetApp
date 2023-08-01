using MediatR;
using Microsoft.EntityFrameworkCore;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;
using TestDotNetApp.Queries;

namespace TestDotNetApp.Handlers
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Client>
    {
        private readonly DBContext _dbContext;

        public GetClientByIdHandler(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.client.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
