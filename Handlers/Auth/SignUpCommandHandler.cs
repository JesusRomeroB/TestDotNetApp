using MediatR;
using TestDotNetApp.Commands;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;
using TestDotNetApp.Services;

namespace TestDotNetApp.Handlers
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, User>
    {
        private readonly DBContext _dbContext;
        private readonly CryptoService _cryptoService;
        public SignUpCommandHandler(DBContext dbContext, CryptoService cryptoService) 
        { 
            _dbContext = dbContext; 
            _cryptoService = cryptoService;
        }
        public async Task<User> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var encryptedPassword = _cryptoService.Encrypt(request.Password);
                var user = new User
                {
                    Name = request.Name,
                    Pass = encryptedPassword,
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
