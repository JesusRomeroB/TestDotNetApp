using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestDotNetApp.Domain.DTO
{
    public class HttpResponse<T>
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public T Response { get; set; }
    }
}
