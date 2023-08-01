using MediatR;
using TestDotNetApp.Commands;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly DBContext _dbContext;
        public UpdateUserCommandHandler(DBContext dbContext) { _dbContext = dbContext; }
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try {
                var user = _dbContext.user.FirstOrDefault(p => p.Id == request.Id);

                if (user is null)
                    return default;

                user.Name = request.Name;
                user.Pass = request.Pass;
                user.Email = request.Email;
                user.Photo = request.Photo;

                await _dbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
