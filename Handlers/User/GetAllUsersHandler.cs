using MediatR;
using Microsoft.EntityFrameworkCore;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;
using TestDotNetApp.Queries;

namespace TestDotNetApp.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly DBContext _dbContext;

        public GetAllUsersHandler(DBContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.user.ToListAsync();
        }
    }
}
