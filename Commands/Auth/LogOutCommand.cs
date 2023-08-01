using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Commands
{
    public class LogOutCommand : IRequest<User>
    {
    }
}
