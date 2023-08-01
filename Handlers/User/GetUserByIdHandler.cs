using MediatR;
using Microsoft.EntityFrameworkCore;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;
using TestDotNetApp.Queries;

namespace TestDotNetApp.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly DBContext _dbContext;

        public GetUserByIdHandler(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.user.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        }
    }
}
