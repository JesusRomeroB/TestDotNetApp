using MediatR;
using TestDotNetApp.Domain.Models;

namespace TestDotNetApp.Queries
{
    public class GetUserListExcelQuery : IRequest<byte[]>
    {
    }
}
