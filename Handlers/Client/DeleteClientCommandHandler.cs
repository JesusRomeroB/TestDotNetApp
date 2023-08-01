using MediatR;
using TestDotNetApp.Commands;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Handlers
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Client>
    {
        private readonly DBContext _dbContext;

        public DeleteClientCommandHandler(DBContext dbContext) { _dbContext = dbContext; }
        public async Task<Client> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var client = _dbContext.client.FirstOrDefault(p => p.Id == request.Id);

            if (client is null)
                return default;

            _dbContext.Remove(client);
            await _dbContext.SaveChangesAsync();
            return client;
        }
    }
}
