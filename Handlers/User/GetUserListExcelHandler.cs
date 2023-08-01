using MediatR;
using Microsoft.EntityFrameworkCore;
using TestDotNetApp.Data;
using TestDotNetApp.Domain.Models;
using TestDotNetApp.Queries;
using TestDotNetApp.Services;

namespace TestDotNetApp.Handlers
{
    public class GetUserListExcelHandler : IRequestHandler<GetUserListExcelQuery, byte[]>
    {
        private readonly DBContext _dbContext;
        private readonly ExcelGeneratorService _excelGeneratorService;

        public GetUserListExcelHandler(DBContext dbcontext, ExcelGeneratorService excelGeneratorService)
        {
            _dbContext = dbcontext;
            _excelGeneratorService = excelGeneratorService;
        }

        public async Task<byte[]> Handle(GetUserListExcelQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<User> users = await _dbContext.user.ToListAsync();
                var excelBytes = _excelGeneratorService.ExportUsersToExcel(users);

                return excelBytes;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
