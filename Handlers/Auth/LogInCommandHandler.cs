using MediatR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestDotNetApp.Commands;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.DTO;
using TestDotNetApp.Domain.Models;
using TestDotNetApp.Services;

namespace TestDotNetApp.Handlers
{
    public class LogInCommandHandler : IRequestHandler<LogInCommand, Tokens>
    {
        private readonly DBContext _dbContext;
        private readonly CryptoService _cryptoService;
        private readonly IConfiguration _configuration;
        public LogInCommandHandler(DBContext dbContext, IConfiguration iconfiguration, CryptoService cryptoService) { 
            _dbContext = dbContext; 
            _configuration = iconfiguration;
            _cryptoService = cryptoService;
        }
        public async Task<Tokens> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var decryptedPassword = _cryptoService.Encrypt(request.Password);
                if (!_dbContext.user.Any(x => x.Email == request.Email && x.Pass == decryptedPassword))
                {
                    return null;
                }

                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                            {
                                new Claim("Id", Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Sub, request.Email),
                                new Claim(JwtRegisteredClaimNames.Email, request.Email),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                            }),
                        Expires = DateTime.UtcNow.AddMinutes(10),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                    };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new Tokens { Token = tokenHandler.WriteToken(token) };
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
