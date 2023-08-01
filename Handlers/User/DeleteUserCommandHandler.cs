using MediatR;
using TestDotNetApp.Commands;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, User>
    {
        private readonly DBContext _dbContext;

        public DeleteUserCommandHandler(DBContext dbContext) { _dbContext = dbContext; }
        public async Task<User> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _dbContext.user.FirstOrDefault(p => p.Id == request.Id);

            if (user is null)
                return default;

            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
