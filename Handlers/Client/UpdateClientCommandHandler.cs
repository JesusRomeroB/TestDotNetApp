using MediatR;
using TestDotNetApp.Commands;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Handlers
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Client>
    {
        private readonly DBContext _dbContext;
        public UpdateClientCommandHandler(DBContext dbContext) { _dbContext = dbContext; }
        public async Task<Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var client = _dbContext.client.FirstOrDefault(p => p.Id == request.Id);

                if (client is null)
                    return default;

                client.Cod = request.Cod;
                client.Name = request.Name;
                client.IdCity = request.IdCity;

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
