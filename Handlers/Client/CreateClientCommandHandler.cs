using MediatR;
using TestDotNetApp.Commands;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Handlers
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Client>
    {
        private readonly DBContext _dbContext;
        public CreateClientCommandHandler(DBContext dbContext) { _dbContext = dbContext; }
        public async Task<Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var client = new Client
                {
                    Cod = request.Cod,
                    Name = request.Name,
                    IdCity = request.IdCity,
                };

                _dbContext.client.Add(client);
                await _dbContext.SaveChangesAsync();
                return client;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
