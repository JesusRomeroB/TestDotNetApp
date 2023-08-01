using MediatR;
using TestDotNetApp.Commands;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly DBContext _dbContext;
        public CreateUserCommandHandler(DBContext dbContext) { _dbContext = dbContext; }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            { 
                var user = new User
                {
                    Name = request.Name,
                    Pass = request.Pass,
                    Email = request.Email,
                    Photo = request.Photo,
                };

                _dbContext.user.Add(user);
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
